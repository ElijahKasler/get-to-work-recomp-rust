using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using ModestTree.Util;
using UnityEngine;
using Zenject.Internal;

namespace Zenject;

public class DiContainer : IInstantiator
{
	private struct LookupId
	{
		public readonly IProvider Provider;

		public readonly BindingId BindingId;

		public LookupId(IProvider provider, BindingId bindingId)
		{
			Assert.IsNotNull(provider);
			Assert.IsNotNull(bindingId);
			Provider = provider;
			BindingId = bindingId;
		}

		public override int GetHashCode()
		{
			return (17 * 23 + Provider.GetHashCode()) * 23 + BindingId.GetHashCode();
		}
	}

	public class ProviderInfo
	{
		public readonly DiContainer Container;

		public readonly bool NonLazy;

		public readonly IProvider Provider;

		public readonly BindingCondition Condition;

		public ProviderInfo(IProvider provider, BindingCondition condition, bool nonLazy, DiContainer container)
		{
			Provider = provider;
			Condition = condition;
			NonLazy = nonLazy;
			Container = container;
		}
	}

	private readonly Dictionary<Type, IDecoratorProvider> _decorators = new Dictionary<Type, IDecoratorProvider>();

	private readonly Dictionary<BindingId, List<ProviderInfo>> _providers = new Dictionary<BindingId, List<ProviderInfo>>();

	private readonly DiContainer[] _parentContainers = new DiContainer[0];

	private readonly DiContainer[] _ancestorContainers = new DiContainer[0];

	private readonly HashSet<LookupId> _resolvesInProgress = new HashSet<LookupId>();

	private readonly HashSet<LookupId> _resolvesTwiceInProgress = new HashSet<LookupId>();

	private readonly LazyInstanceInjector _lazyInjector;

	private readonly SingletonMarkRegistry _singletonMarkRegistry = new SingletonMarkRegistry();

	private readonly Queue<IBindingFinalizer> _currentBindings = new Queue<IBindingFinalizer>();

	private readonly List<IBindingFinalizer> _childBindings = new List<IBindingFinalizer>();

	private readonly HashSet<Type> _validatedTypes = new HashSet<Type>();

	private readonly List<IValidatable> _validationQueue = new List<IValidatable>();

	private Transform _contextTransform;

	private bool _hasLookedUpContextTransform;

	private Transform _inheritedDefaultParent;

	private Transform _explicitDefaultParent;

	private bool _hasExplicitDefaultParent;

	private ZenjectSettings _settings;

	private bool _hasResolvedRoots;

	private bool _isFinalizingBinding;

	private bool _isValidating;

	private bool _isInstalling;

	public ZenjectSettings Settings
	{
		get
		{
			return _settings;
		}
		set
		{
			_settings = value;
			Rebind<ZenjectSettings>().FromInstance(value);
		}
	}

	internal SingletonMarkRegistry SingletonMarkRegistry => _singletonMarkRegistry;

	public IEnumerable<IProvider> AllProviders => (from x in _providers.Values.SelectMany((List<ProviderInfo> x) => x)
		select x.Provider).Distinct();

	private Transform ContextTransform
	{
		get
		{
			if (!_hasLookedUpContextTransform)
			{
				_hasLookedUpContextTransform = true;
				Context context = TryResolve<Context>();
				if (context != null)
				{
					_contextTransform = context.transform;
				}
			}
			return _contextTransform;
		}
	}

	public bool AssertOnNewGameObjects { get; set; }

	public Transform InheritedDefaultParent => _inheritedDefaultParent;

	public Transform DefaultParent
	{
		get
		{
			return _explicitDefaultParent;
		}
		set
		{
			_explicitDefaultParent = value;
			_hasExplicitDefaultParent = true;
		}
	}

	public IEnumerable<DiContainer> ParentContainers => _parentContainers;

	public bool ChecksForCircularDependencies => true;

	public bool IsValidating => _isValidating;

	public bool IsInstalling
	{
		get
		{
			return _isInstalling;
		}
		set
		{
			_isInstalling = value;
		}
	}

	public IEnumerable<BindingId> AllContracts
	{
		get
		{
			FlushBindings();
			return _providers.Keys;
		}
	}

	public DiContainer(bool isValidating)
	{
		_isValidating = isValidating;
		_lazyInjector = new LazyInstanceInjector(this);
		InstallDefaultBindings();
		FlushBindings();
		Assert.That(_currentBindings.IsEmpty());
		_settings = ZenjectSettings.Default;
	}

	public DiContainer()
		: this(isValidating: false)
	{
	}

	public DiContainer(IEnumerable<DiContainer> parentContainers, bool isValidating)
		: this(isValidating)
	{
		_parentContainers = parentContainers.ToArray();
		_ancestorContainers = FlattenInheritanceChain().ToArray();
		if (!_parentContainers.IsEmpty())
		{
			for (int i = 0; i < _parentContainers.Length; i++)
			{
				_parentContainers[i].FlushBindings();
			}
			_inheritedDefaultParent = _parentContainers.First().DefaultParent;
			foreach (DiContainer item in _ancestorContainers.Distinct())
			{
				foreach (IBindingFinalizer childBinding in item._childBindings)
				{
					if (ShouldInheritBinding(childBinding, item))
					{
						FinalizeBinding(childBinding);
					}
				}
			}
			Assert.That(_currentBindings.IsEmpty());
			Assert.That(_childBindings.IsEmpty());
		}
		ZenjectSettings zenjectSettings = TryResolve<ZenjectSettings>();
		if (zenjectSettings != null)
		{
			_settings = zenjectSettings;
		}
	}

	public DiContainer(DiContainer parentContainer, bool isValidating)
		: this(new DiContainer[1] { parentContainer }, isValidating)
	{
	}

	public DiContainer(DiContainer parentContainer)
		: this(new DiContainer[1] { parentContainer }, isValidating: false)
	{
	}

	private void InstallDefaultBindings()
	{
		Bind(typeof(DiContainer), typeof(IInstantiator)).FromInstance(this);
		Bind(typeof(LazyInject<>)).FromMethodUntyped(CreateLazyBinding).Lazy();
	}

	private object CreateLazyBinding(InjectContext context)
	{
		InjectContext injectContext = context.Clone();
		injectContext.MemberType = context.MemberType.GenericArguments().Single();
		object obj = Activator.CreateInstance(typeof(LazyInject<>).MakeGenericType(injectContext.MemberType), this, injectContext);
		if (_isValidating)
		{
			QueueForValidate((IValidatable)obj);
		}
		return obj;
	}

	public void QueueForValidate(IValidatable validatable)
	{
		if (!_hasResolvedRoots)
		{
			Type type = validatable.GetType();
			if (!_validatedTypes.Contains(type))
			{
				_validatedTypes.Add(type);
				_validationQueue.Add(validatable);
			}
		}
	}

	private bool ShouldInheritBinding(IBindingFinalizer binding, DiContainer ancestorContainer)
	{
		if (binding.BindingInheritanceMethod == BindingInheritanceMethods.CopyIntoAll || binding.BindingInheritanceMethod == BindingInheritanceMethods.MoveIntoAll)
		{
			return true;
		}
		if ((binding.BindingInheritanceMethod == BindingInheritanceMethods.CopyDirectOnly || binding.BindingInheritanceMethod == BindingInheritanceMethods.MoveDirectOnly) && _parentContainers.Contains(ancestorContainer))
		{
			return true;
		}
		return false;
	}

	public DiContainer(IEnumerable<DiContainer> parentContainers)
		: this(parentContainers, isValidating: false)
	{
	}

	public void ResolveRoots()
	{
		Assert.That(!_hasResolvedRoots);
		FlushBindings();
		ResolveDependencyRoots();
		_lazyInjector.LazyInjectAll();
		if (IsValidating)
		{
			FlushValidationQueue();
		}
		Assert.That(!_hasResolvedRoots);
		_hasResolvedRoots = true;
	}

	private void ResolveDependencyRoots()
	{
		List<BindingId> list = new List<BindingId>();
		List<ProviderInfo> list2 = new List<ProviderInfo>();
		foreach (KeyValuePair<BindingId, List<ProviderInfo>> provider in _providers)
		{
			foreach (ProviderInfo item in provider.Value)
			{
				if (item.NonLazy)
				{
					list.Add(provider.Key);
					list2.Add(item);
				}
			}
		}
		Assert.IsEqual(list2.Count, list.Count);
		for (int i = 0; i < list2.Count; i++)
		{
			BindingId bindingId = list[i];
			ProviderInfo providerInfo = list2[i];
			using DisposeBlock disposeBlock = DisposeBlock.Spawn();
			InjectContext injectContext = disposeBlock.Spawn(InjectContext.Pool, this, bindingId.Type);
			injectContext.Identifier = bindingId.Identifier;
			injectContext.SourceType = InjectSources.Local;
			injectContext.Optional = false;
			SafeGetInstances(providerInfo, injectContext);
		}
	}

	private void ValidateFullResolve()
	{
		Assert.That(!_hasResolvedRoots);
		Assert.That(IsValidating);
		using DisposeBlock disposeBlock = DisposeBlock.Spawn();
		foreach (BindingId item in disposeBlock.SpawnList(_providers.Keys))
		{
			if (!item.Type.IsOpenGenericType())
			{
				using InjectContext injectContext = InjectContext.Pool.Spawn(this, item.Type);
				injectContext.Identifier = item.Identifier;
				injectContext.SourceType = InjectSources.Local;
				injectContext.Optional = true;
				ResolveAll(injectContext);
			}
		}
	}

	private void FlushValidationQueue()
	{
		Assert.That(!_hasResolvedRoots);
		Assert.That(IsValidating);
		Assert.That(Application.isEditor);
		using DisposeBlock disposeBlock = DisposeBlock.Spawn();
		List<IValidatable> list = disposeBlock.SpawnList<IValidatable>();
		while (_validationQueue.Any())
		{
			list.Clear();
			list.AddRange(_validationQueue);
			_validationQueue.Clear();
			for (int i = 0; i < list.Count; i++)
			{
				list[i].Validate();
			}
		}
	}

	public DiContainer CreateSubContainer()
	{
		return CreateSubContainer(_isValidating);
	}

	public void QueueForInject(object instance)
	{
		_lazyInjector.AddInstance(instance);
	}

	public T LazyInject<T>(T instance)
	{
		_lazyInjector.LazyInject(instance);
		return instance;
	}

	private DiContainer CreateSubContainer(bool isValidating)
	{
		return new DiContainer(new DiContainer[1] { this }, isValidating);
	}

	public void RegisterProvider(BindingId bindingId, BindingCondition condition, IProvider provider, bool nonLazy)
	{
		ProviderInfo item = new ProviderInfo(provider, condition, nonLazy, this);
		if (!_providers.TryGetValue(bindingId, out var value))
		{
			value = new List<ProviderInfo>();
			_providers.Add(bindingId, value);
		}
		value.Add(item);
	}

	private void GetProviderMatches(InjectContext context, List<ProviderInfo> buffer)
	{
		Assert.IsNotNull(context);
		Assert.That(buffer.IsEmpty());
		using DisposeBlock disposeBlock = DisposeBlock.Spawn();
		List<ProviderInfo> list = disposeBlock.SpawnList<ProviderInfo>();
		GetProvidersForContract(context.BindingId, context.SourceType, list);
		for (int i = 0; i < list.Count; i++)
		{
			ProviderInfo providerInfo = list[i];
			if (providerInfo.Condition == null || providerInfo.Condition(context))
			{
				buffer.Add(providerInfo);
			}
		}
	}

	private ProviderInfo TryGetUniqueProvider(InjectContext context)
	{
		Assert.IsNotNull(context);
		BindingId bindingId = context.BindingId;
		InjectSources sourceType = context.SourceType;
		ForAllContainersToLookup(sourceType, (DiContainer container) =>
		{
			container.FlushBindings();
		});
		using DisposeBlock disposeBlock = DisposeBlock.Spawn();
		List<ProviderInfo> localProviders = disposeBlock.SpawnList<ProviderInfo>();
		ProviderInfo selected = null;
		int selectedDistance = int.MaxValue;
		bool selectedHasCondition = false;
		bool ambiguousSelection = false;
		ForAllContainersToLookup(sourceType, (DiContainer container) =>
		{
			int containerHeirarchyDistance = GetContainerHeirarchyDistance(container);
			if (containerHeirarchyDistance <= selectedDistance)
			{
				localProviders.Clear();
				container.GetLocalProviders(bindingId, localProviders);
				for (int i = 0; i < localProviders.Count; i++)
				{
					ProviderInfo providerInfo = localProviders[i];
					bool flag = providerInfo.Condition != null;
					if (!flag || providerInfo.Condition(context))
					{
						Assert.That(selected == null || selectedDistance == containerHeirarchyDistance);
						if (flag)
						{
							if (selectedHasCondition)
							{
								ambiguousSelection = true;
							}
							else
							{
								ambiguousSelection = false;
							}
						}
						else
						{
							if (selectedHasCondition)
							{
								continue;
							}
							if (selected != null && !selectedHasCondition)
							{
								ambiguousSelection = true;
							}
						}
						if (!ambiguousSelection)
						{
							selectedDistance = containerHeirarchyDistance;
							selectedHasCondition = flag;
							selected = providerInfo;
						}
					}
				}
			}
		});
		if (ambiguousSelection)
		{
			throw Assert.CreateException("Found multiple matches when only one was expected for type '{0}'{1}. \nObject graph:\n {2}", context.MemberType, (context.ObjectType == null) ? "" : " while building object with type '{0}'".Fmt(context.ObjectType), context.GetObjectGraphString());
		}
		return selected;
	}

	private void ForAllContainersToLookup(InjectSources sourceType, Action<DiContainer> action)
	{
		switch (sourceType)
		{
		case InjectSources.Local:
			action(this);
			break;
		case InjectSources.Parent:
		{
			DiContainer[] ancestorContainers = _parentContainers;
			foreach (DiContainer obj2 in ancestorContainers)
			{
				action(obj2);
			}
			break;
		}
		case InjectSources.Any:
		{
			action(this);
			DiContainer[] ancestorContainers = _ancestorContainers;
			foreach (DiContainer obj3 in ancestorContainers)
			{
				action(obj3);
			}
			break;
		}
		case InjectSources.AnyParent:
		{
			DiContainer[] ancestorContainers = _ancestorContainers;
			foreach (DiContainer obj in ancestorContainers)
			{
				action(obj);
			}
			break;
		}
		default:
			throw Assert.CreateException();
		}
	}

	private List<DiContainer> FlattenInheritanceChain()
	{
		List<DiContainer> list = new List<DiContainer>();
		Queue<DiContainer> queue = new Queue<DiContainer>();
		queue.Enqueue(this);
		while (queue.Count > 0)
		{
			DiContainer[] parentContainers = queue.Dequeue()._parentContainers;
			foreach (DiContainer item in parentContainers)
			{
				if (!list.Contains(item))
				{
					list.Add(item);
					queue.Enqueue(item);
				}
			}
		}
		return list;
	}

	private void GetLocalProviders(BindingId bindingId, List<ProviderInfo> buffer)
	{
		if (_providers.TryGetValue(bindingId, out var value))
		{
			buffer.AddRange(value);
		}
		else if (bindingId.Type.IsGenericType() && _providers.TryGetValue(new BindingId(bindingId.Type.GetGenericTypeDefinition(), bindingId.Identifier), out value))
		{
			buffer.AddRange(value);
		}
	}

	private void GetProvidersForContract(BindingId bindingId, InjectSources sourceType, List<ProviderInfo> buffer)
	{
		ForAllContainersToLookup(sourceType, (DiContainer container) =>
		{
			container.FlushBindings();
		});
		ForAllContainersToLookup(sourceType, (DiContainer container) =>
		{
			container.GetLocalProviders(bindingId, buffer);
		});
	}

	public void Install<TInstaller>() where TInstaller : Installer
	{
		Instantiate<TInstaller>().InstallBindings();
	}

	public void Install<TInstaller>(object[] extraArgs) where TInstaller : Installer
	{
		Instantiate<TInstaller>(extraArgs).InstallBindings();
	}

	public IList ResolveAll(InjectContext context)
	{
		using DisposeBlock disposeBlock = DisposeBlock.Spawn();
		List<object> list = disposeBlock.SpawnList<object>();
		ResolveAllInternal(context, list);
		return ReflectionUtil.CreateGenericList(context.MemberType, list);
	}

	private void ResolveAllInternal(InjectContext context, List<object> buffer)
	{
		Assert.IsNotNull(context);
		FlushBindings();
		CheckForInstallWarning(context);
		using DisposeBlock disposeBlock = DisposeBlock.Spawn();
		List<ProviderInfo> list = disposeBlock.SpawnList<ProviderInfo>();
		GetProviderMatches(context, list);
		if (list.IsEmpty())
		{
			if (!context.Optional)
			{
				throw Assert.CreateException("Could not find required dependency with type '{0}' \nObject graph:\n {1}", context.MemberType, context.GetObjectGraphString());
			}
			return;
		}
		List<object> list2 = disposeBlock.SpawnList<object>();
		for (int i = 0; i < list.Count; i++)
		{
			ProviderInfo providerInfo = list[i];
			List<object> list3 = SafeGetInstances(providerInfo, context);
			for (int j = 0; j < list3.Count; j++)
			{
				list2.Add(list3[j]);
			}
		}
		if (list2.Count == 0 && !context.Optional)
		{
			throw Assert.CreateException("Could not find required dependency with type '{0}'.  Found providers but they returned zero results!", context.MemberType);
		}
		if (IsValidating)
		{
			for (int k = 0; k < list2.Count; k++)
			{
				if (list2[k] is ValidationMarker)
				{
					list2[k] = context.MemberType.GetDefaultValue();
				}
			}
		}
		buffer.AddRange(list2);
	}

	private void CheckForInstallWarning(InjectContext context)
	{
		if (_settings.DisplayWarningWhenResolvingDuringInstall)
		{
			Assert.IsNotNull(context);
		}
	}

	public Type ResolveType<T>()
	{
		return ResolveType(typeof(T));
	}

	public Type ResolveType(Type type)
	{
		using InjectContext context = InjectContext.Pool.Spawn(this, type);
		return ResolveType(context);
	}

	public Type ResolveType(InjectContext context)
	{
		Assert.IsNotNull(context);
		FlushBindings();
		ProviderInfo providerInfo = TryGetUniqueProvider(context);
		if (providerInfo == null)
		{
			throw Assert.CreateException("Unable to resolve type '{0}'{1}. \nObject graph:\n{2}", context.MemberType.ToString() + ((context.Identifier == null) ? "" : " with ID '{0}'".Fmt(context.Identifier.ToString())), (context.ObjectType == null) ? "" : " while building object with type '{0}'".Fmt(context.ObjectType), context.GetObjectGraphString());
		}
		return providerInfo.Provider.GetInstanceType(context);
	}

	public List<Type> ResolveTypeAll(Type type)
	{
		return ResolveTypeAll(type, null);
	}

	public List<Type> ResolveTypeAll(Type type, object identifier)
	{
		using InjectContext injectContext = InjectContext.Pool.Spawn(this, type);
		injectContext.Identifier = identifier;
		return ResolveTypeAll(injectContext);
	}

	public List<Type> ResolveTypeAll(InjectContext context)
	{
		Assert.IsNotNull(context);
		FlushBindings();
		using DisposeBlock disposeBlock = DisposeBlock.Spawn();
		List<ProviderInfo> list = disposeBlock.SpawnList<ProviderInfo>();
		GetProviderMatches(context, list);
		if (list.Count > 0)
		{
			return (from x in list
				select x.Provider.GetInstanceType(context) into x
				where x != null
				select x).ToList();
		}
		return new List<Type>();
	}

	public object Resolve(BindingId id)
	{
		using InjectContext injectContext = InjectContext.Pool.Spawn(this, id.Type);
		injectContext.Identifier = id.Identifier;
		return Resolve(injectContext);
	}

	public object Resolve(InjectContext context)
	{
		Assert.IsNotNull(context);
		Type memberType = context.MemberType;
		FlushBindings();
		CheckForInstallWarning(context);
		InjectContext injectContext = context;
		if (memberType.IsGenericType() && memberType.GetGenericTypeDefinition() == typeof(LazyInject<>))
		{
			injectContext = context.Clone();
			injectContext.Identifier = null;
			injectContext.SourceType = InjectSources.Local;
			injectContext.Optional = false;
		}
		ProviderInfo providerInfo = TryGetUniqueProvider(injectContext);
		if (providerInfo == null)
		{
			if (memberType.IsArray && memberType.GetArrayRank() == 1)
			{
				Type elementType = memberType.GetElementType();
				InjectContext injectContext2 = context.Clone();
				injectContext2.MemberType = elementType;
				injectContext2.Optional = true;
				using DisposeBlock disposeBlock = DisposeBlock.Spawn();
				List<object> list = disposeBlock.SpawnList<object>();
				ResolveAllInternal(injectContext2, list);
				return ReflectionUtil.CreateArray(injectContext2.MemberType, list);
			}
			if (memberType.IsGenericType() && (memberType.GetGenericTypeDefinition() == typeof(List<>) || memberType.GetGenericTypeDefinition() == typeof(IList<>) || memberType.GetGenericTypeDefinition() == typeof(IReadOnlyList<>) || memberType.GetGenericTypeDefinition() == typeof(IEnumerable<>)))
			{
				Type memberType2 = memberType.GenericArguments().Single();
				InjectContext injectContext3 = context.Clone();
				injectContext3.MemberType = memberType2;
				injectContext3.Optional = true;
				return ResolveAll(injectContext3);
			}
			if (context.Optional)
			{
				return context.FallBackValue;
			}
			throw Assert.CreateException("Unable to resolve type '{0}'{1}. \nObject graph:\n{2}", memberType.ToString() + ((context.Identifier == null) ? "" : " with ID '{0}'".Fmt(context.Identifier.ToString())), (context.ObjectType == null) ? "" : " while building object with type '{0}'".Fmt(context.ObjectType), context.GetObjectGraphString());
		}
		List<object> list2 = SafeGetInstances(providerInfo, context);
		if (list2.IsEmpty())
		{
			if (context.Optional)
			{
				return context.FallBackValue;
			}
			throw Assert.CreateException("Unable to resolve type '{0}'{1}. \nObject graph:\n{2}", memberType.ToString() + ((context.Identifier == null) ? "" : " with ID '{0}'".Fmt(context.Identifier.ToString())), (context.ObjectType == null) ? "" : " while building object with type '{0}'".Fmt(context.ObjectType), context.GetObjectGraphString());
		}
		if (list2.Count() > 1)
		{
			throw Assert.CreateException("Provider returned multiple instances when only one was expected!  While resolving type '{0}'{1}. \nObject graph:\n{2}", memberType.ToString() + ((context.Identifier == null) ? "" : " with ID '{0}'".Fmt(context.Identifier.ToString())), (context.ObjectType == null) ? "" : " while building object with type '{0}'".Fmt(context.ObjectType), context.GetObjectGraphString());
		}
		return list2.First();
	}

	private List<object> SafeGetInstances(ProviderInfo providerInfo, InjectContext context)
	{
		Assert.IsNotNull(context);
		IProvider provider = providerInfo.Provider;
		if (ChecksForCircularDependencies)
		{
			LookupId item = new LookupId(provider, context.BindingId);
			DiContainer container = providerInfo.Container;
			if (container._resolvesTwiceInProgress.Contains(item))
			{
				throw Assert.CreateException("Circular dependency detected! \nObject graph:\n {0}", context.GetObjectGraphString());
			}
			bool flag = false;
			if (!container._resolvesInProgress.Add(item))
			{
				Assert.That(container._resolvesTwiceInProgress.Add(item));
				flag = true;
			}
			try
			{
				return GetDecoratedInstances(provider, context);
			}
			finally
			{
				if (flag)
				{
					Assert.That(container._resolvesTwiceInProgress.Remove(item));
				}
				else
				{
					Assert.That(container._resolvesInProgress.Remove(item));
				}
			}
		}
		return GetDecoratedInstances(provider, context);
	}

	public DecoratorToChoiceFromBinder<TContract> Decorate<TContract>()
	{
		BindInfo bindInfo = new BindInfo();
		bindInfo.ContractTypes.Add(typeof(IFactory<TContract, TContract>));
		FactoryBindInfo factoryBindInfo = new FactoryBindInfo(typeof(PlaceholderFactory<TContract, TContract>));
		StartBinding().SubFinalizer = new PlaceholderFactoryBindingFinalizer<TContract>(bindInfo, factoryBindInfo);
		Guid guid = Guid.NewGuid();
		bindInfo.Identifier = guid;
		if (!_decorators.TryGetValue(typeof(TContract), out var value))
		{
			value = new DecoratorProvider<TContract>(this);
			_decorators.Add(typeof(TContract), value);
		}
		((DecoratorProvider<TContract>)value).AddFactoryId(guid);
		return new DecoratorToChoiceFromBinder<TContract>(this, bindInfo, factoryBindInfo);
	}

	private List<object> GetDecoratedInstances(IProvider provider, InjectContext context)
	{
		IDecoratorProvider decoratorProvider = TryGetDecoratorProvider(context.BindingId.Type);
		if (decoratorProvider != null)
		{
			return decoratorProvider.GetAllInstances(provider, context);
		}
		return provider.GetAllInstances(context);
	}

	private IDecoratorProvider TryGetDecoratorProvider(Type contractType)
	{
		if (_decorators.TryGetValue(contractType, out var value))
		{
			return value;
		}
		for (int i = 0; i < _ancestorContainers.Length; i++)
		{
			if (_ancestorContainers[i]._decorators.TryGetValue(contractType, out value))
			{
				return value;
			}
		}
		return null;
	}

	private int GetContainerHeirarchyDistance(DiContainer container)
	{
		return GetContainerHeirarchyDistance(container, 0).Value;
	}

	private int? GetContainerHeirarchyDistance(DiContainer container, int depth)
	{
		if (container == this)
		{
			return depth;
		}
		int? result = null;
		DiContainer[] parentContainers = _parentContainers;
		for (int i = 0; i < parentContainers.Length; i++)
		{
			int? containerHeirarchyDistance = parentContainers[i].GetContainerHeirarchyDistance(container, depth + 1);
			if (containerHeirarchyDistance.HasValue && (!result.HasValue || containerHeirarchyDistance.Value < result.Value))
			{
				result = containerHeirarchyDistance;
			}
		}
		return result;
	}

	public IEnumerable<Type> GetDependencyContracts<TContract>()
	{
		return GetDependencyContracts(typeof(TContract));
	}

	public IEnumerable<Type> GetDependencyContracts(Type contract)
	{
		FlushBindings();
		foreach (InjectableInfo allInjectable in TypeAnalyzer.GetInfo(contract).AllInjectables)
		{
			yield return allInjectable.MemberType;
		}
	}

	private object InstantiateInternal(Type concreteType, bool autoInject, InjectArgs args)
	{
		Assert.That(!concreteType.DerivesFrom<Component>(), "Error occurred while instantiating object of type '{0}'. Instantiator should not be used to create new mono behaviours.  Must use InstantiatePrefabForComponent, InstantiatePrefab, or InstantiateComponent.", concreteType);
		Assert.That(!concreteType.IsAbstract(), "Expected type '{0}' to be non-abstract", concreteType);
		FlushBindings();
		CheckForInstallWarning(args.Context);
		ZenjectTypeInfo info = TypeAnalyzer.GetInfo(concreteType);
		bool flag = TypeAnalyzer.ShouldAllowDuringValidation(concreteType);
		object obj;
		if (concreteType.DerivesFrom<ScriptableObject>())
		{
			Assert.That(info.ConstructorInjectables.IsEmpty(), "Found constructor parameters on ScriptableObject type '{0}'.  This is not allowed.  Use an [Inject] method or fields instead.");
			obj = ((!(!IsValidating | flag)) ? ((object)new ValidationMarker(concreteType)) : ((object)ScriptableObject.CreateInstance(concreteType)));
		}
		else
		{
			Assert.IsNotNull(info.InjectConstructor, "More than one (or zero) constructors found for type '{0}' when creating dependencies.  Use one [Inject] attribute to specify which to use.", concreteType);
			List<object> list = new List<object>();
			foreach (InjectableInfo constructorInjectable in info.ConstructorInjectables)
			{
				if (!InjectUtil.PopValueWithType(args.ExtraArgs, constructorInjectable.MemberType, out var value))
				{
					using InjectContext context = constructorInjectable.SpawnInjectContext(this, args.Context, null, args.ConcreteIdentifier);
					value = Resolve(context);
				}
				if (value is ValidationMarker)
				{
					Assert.That(IsValidating);
					list.Add(constructorInjectable.MemberType.GetDefaultValue());
				}
				else
				{
					list.Add(value);
				}
			}
			if (!IsValidating | flag)
			{
				try
				{
					obj = info.InjectConstructor.Invoke(list.ToArray());
				}
				catch (Exception innerException)
				{
					throw Assert.CreateException(innerException, "Error occurred while instantiating object with type '{0}'", concreteType);
				}
			}
			else
			{
				obj = new ValidationMarker(concreteType);
			}
		}
		if (autoInject)
		{
			InjectExplicit(obj, concreteType, args);
			if (!args.ExtraArgs.IsEmpty())
			{
				throw Assert.CreateException("Passed unnecessary parameters when injecting into type '{0}'. \nExtra Parameters: {1}\nObject graph:\n{2}", obj.GetType(), string.Join(",", args.ExtraArgs.Select((TypeValuePair x) => x.Type.PrettyName()).ToArray()), args.Context.GetObjectGraphString());
			}
		}
		return obj;
	}

	public void InjectExplicit(object injectable, List<TypeValuePair> extraArgs)
	{
		Type type = ((!(injectable is ValidationMarker)) ? injectable.GetType() : ((ValidationMarker)injectable).MarkedType);
		InjectExplicit(injectable, type, new InjectArgs
		{
			ExtraArgs = extraArgs,
			Context = new InjectContext(this, type, null)
		});
	}

	public void InjectExplicit(object injectable, Type injectableType, InjectArgs args)
	{
		if (IsValidating)
		{
			if (injectable is ValidationMarker { InstantiateFailed: not false })
			{
				return;
			}
			if (_settings.ValidationErrorResponse != ValidationErrorResponses.Throw)
			{
				try
				{
					InjectExplicitInternal(injectable, injectableType, args);
					return;
				}
				catch (Exception e)
				{
					Log.ErrorException(e);
					return;
				}
			}
			InjectExplicitInternal(injectable, injectableType, args);
		}
		else
		{
			InjectExplicitInternal(injectable, injectableType, args);
		}
	}

	private void InjectExplicitInternal(object injectable, Type injectableType, InjectArgs args)
	{
		Assert.That(injectable != null);
		ZenjectTypeInfo info = TypeAnalyzer.GetInfo(injectableType);
		bool flag = TypeAnalyzer.ShouldAllowDuringValidation(injectableType);
		bool flag2 = IsValidating && !flag;
		if (!flag2)
		{
			Assert.IsEqual(injectable.GetType(), injectableType);
		}
		Assert.That(injectableType != typeof(GameObject), "Use InjectGameObject to Inject game objects instead of Inject method");
		FlushBindings();
		CheckForInstallWarning(args.Context);
		foreach (InjectableInfo item in info.FieldInjectables.Concat(info.PropertyInjectables))
		{
			if (InjectUtil.PopValueWithType(args.ExtraArgs, item.MemberType, out var value))
			{
				if (!flag2)
				{
					if (value is ValidationMarker)
					{
						Assert.That(IsValidating);
					}
					else
					{
						item.Setter(injectable, value);
					}
				}
				continue;
			}
			using (InjectContext context = item.SpawnInjectContext(this, args.Context, injectable, args.ConcreteIdentifier))
			{
				value = Resolve(context);
			}
			if ((!item.Optional || value != null) && !flag2)
			{
				if (value is ValidationMarker)
				{
					Assert.That(IsValidating);
				}
				else
				{
					item.Setter(injectable, value);
				}
			}
		}
		foreach (PostInjectableInfo postInjectMethod in info.PostInjectMethods)
		{
			List<object> list = new List<object>();
			foreach (InjectableInfo item2 in postInjectMethod.InjectableInfo)
			{
				if (!InjectUtil.PopValueWithType(args.ExtraArgs, item2.MemberType, out var value2))
				{
					using InjectContext context2 = item2.SpawnInjectContext(this, args.Context, injectable, args.ConcreteIdentifier);
					value2 = Resolve(context2);
				}
				if (value2 is ValidationMarker)
				{
					Assert.That(IsValidating);
					list.Add(item2.MemberType.GetDefaultValue());
				}
				else
				{
					list.Add(value2);
				}
			}
			if (!flag2)
			{
				if (postInjectMethod.MethodInfo.ReturnType == typeof(IEnumerator))
				{
					StartCoroutine(injectable, postInjectMethod, list);
				}
				else
				{
					postInjectMethod.MethodInfo.Invoke(injectable, list.ToArray());
				}
			}
		}
		if (!args.ExtraArgs.IsEmpty())
		{
			throw Assert.CreateException("Passed unnecessary parameters when injecting into type '{0}'. \nExtra Parameters: {1}\nObject graph:\n{2}", injectableType, string.Join(",", args.ExtraArgs.Select((TypeValuePair x) => x.Type.PrettyName()).ToArray()), args.Context.GetObjectGraphString());
		}
	}

	private void StartCoroutine(object injectable, PostInjectableInfo method, List<object> paramValues)
	{
		MonoBehaviour monoBehaviour = injectable as MonoBehaviour;
		if (monoBehaviour == null)
		{
			monoBehaviour = TryResolve<Context>();
		}
		if (monoBehaviour == null)
		{
			throw Assert.CreateException("Unable to find a suitable MonoBehaviour to start the '{0}.{1}' coroutine on.", method.MethodInfo.DeclaringType, method.MethodInfo.Name);
		}
		IEnumerator routine = method.MethodInfo.Invoke(injectable, paramValues.ToArray()) as IEnumerator;
		monoBehaviour.StartCoroutine(routine);
	}

	internal GameObject CreateAndParentPrefabResource(string resourcePath, GameObjectCreationParameters gameObjectBindInfo, InjectContext context, out bool shouldMakeActive)
	{
		GameObject gameObject = (GameObject)Resources.Load(resourcePath);
		Assert.IsNotNull(gameObject, "Could not find prefab at resource location '{0}'".Fmt(resourcePath));
		return CreateAndParentPrefab(gameObject, gameObjectBindInfo, context, out shouldMakeActive);
	}

	private GameObject GetPrefabAsGameObject(UnityEngine.Object prefab)
	{
		if (prefab is GameObject)
		{
			return (GameObject)prefab;
		}
		Assert.That(prefab is Component, "Invalid type given for prefab. Given object name: '{0}'", prefab.name);
		return ((Component)prefab).gameObject;
	}

	internal GameObject CreateAndParentPrefab(UnityEngine.Object prefab, GameObjectCreationParameters gameObjectBindInfo, InjectContext context, out bool shouldMakeActive)
	{
		Assert.That(prefab != null, "Null prefab found when instantiating game object");
		Assert.That(!AssertOnNewGameObjects, "Given DiContainer does not support creating new game objects");
		FlushBindings();
		GameObject prefabAsGameObject = GetPrefabAsGameObject(prefab);
		bool flag = (shouldMakeActive = prefabAsGameObject.activeSelf);
		Transform transformGroup = GetTransformGroup(gameObjectBindInfo, context);
		if (flag)
		{
			prefabAsGameObject.SetActive(value: false);
		}
		Transform parent = ((!(transformGroup != null)) ? ContextTransform : transformGroup);
		GameObject gameObject = ((gameObjectBindInfo.Position.HasValue && gameObjectBindInfo.Rotation.HasValue) ? UnityEngine.Object.Instantiate(prefabAsGameObject, gameObjectBindInfo.Position.Value, gameObjectBindInfo.Rotation.Value, parent) : (gameObjectBindInfo.Position.HasValue ? UnityEngine.Object.Instantiate(prefabAsGameObject, gameObjectBindInfo.Position.Value, prefabAsGameObject.transform.rotation, parent) : ((!gameObjectBindInfo.Rotation.HasValue) ? UnityEngine.Object.Instantiate(prefabAsGameObject, parent) : UnityEngine.Object.Instantiate(prefabAsGameObject, prefabAsGameObject.transform.position, gameObjectBindInfo.Rotation.Value, parent))));
		if (flag)
		{
			prefabAsGameObject.SetActive(value: true);
		}
		if (gameObject.transform.parent != transformGroup)
		{
			gameObject.transform.SetParent(transformGroup, worldPositionStays: false);
		}
		if (gameObjectBindInfo.Name != null)
		{
			gameObject.name = gameObjectBindInfo.Name;
		}
		return gameObject;
	}

	public GameObject CreateEmptyGameObject(string name)
	{
		return CreateEmptyGameObject(new GameObjectCreationParameters
		{
			Name = name
		}, null);
	}

	public GameObject CreateEmptyGameObject(GameObjectCreationParameters gameObjectBindInfo, InjectContext context)
	{
		Assert.That(!AssertOnNewGameObjects, "Given DiContainer does not support creating new game objects");
		FlushBindings();
		GameObject gameObject = new GameObject(gameObjectBindInfo.Name ?? "GameObject");
		Transform transformGroup = GetTransformGroup(gameObjectBindInfo, context);
		if (transformGroup == null)
		{
			gameObject.transform.SetParent(ContextTransform, worldPositionStays: false);
			gameObject.transform.SetParent(null, worldPositionStays: false);
		}
		else
		{
			gameObject.transform.SetParent(transformGroup, worldPositionStays: false);
		}
		return gameObject;
	}

	private Transform GetTransformGroup(GameObjectCreationParameters gameObjectBindInfo, InjectContext context)
	{
		Assert.That(!AssertOnNewGameObjects, "Given DiContainer does not support creating new game objects");
		if (gameObjectBindInfo.ParentTransform != null)
		{
			Assert.IsNull(gameObjectBindInfo.GroupName);
			Assert.IsNull(gameObjectBindInfo.ParentTransformGetter);
			return gameObjectBindInfo.ParentTransform;
		}
		if (gameObjectBindInfo.ParentTransformGetter != null && !IsValidating)
		{
			Assert.IsNull(gameObjectBindInfo.GroupName);
			if (context == null)
			{
				context = new InjectContext
				{
					Container = this
				};
			}
			return gameObjectBindInfo.ParentTransformGetter(context);
		}
		string groupName = gameObjectBindInfo.GroupName;
		Transform transform = (_hasExplicitDefaultParent ? _explicitDefaultParent : _inheritedDefaultParent);
		if (transform == null)
		{
			if (groupName == null)
			{
				return null;
			}
			return (GameObject.Find("/" + groupName) ?? CreateTransformGroup(groupName)).transform;
		}
		if (groupName == null)
		{
			return transform;
		}
		foreach (Transform item in transform)
		{
			if (item.name == groupName)
			{
				return item;
			}
		}
		Transform transform3 = new GameObject(groupName).transform;
		transform3.SetParent(transform, worldPositionStays: false);
		return transform3;
	}

	private GameObject CreateTransformGroup(string groupName)
	{
		GameObject gameObject = new GameObject(groupName);
		gameObject.transform.SetParent(ContextTransform, worldPositionStays: false);
		gameObject.transform.SetParent(null, worldPositionStays: false);
		return gameObject;
	}

	public T Instantiate<T>()
	{
		return Instantiate<T>(new object[0]);
	}

	public T Instantiate<T>(IEnumerable<object> extraArgs)
	{
		object obj = Instantiate(typeof(T), extraArgs);
		if (IsValidating && !(obj is T))
		{
			Assert.That(obj is ValidationMarker);
			return default;
		}
		return (T)obj;
	}

	public object Instantiate(Type concreteType)
	{
		return Instantiate(concreteType, new object[0]);
	}

	public object Instantiate(Type concreteType, IEnumerable<object> extraArgs)
	{
		Assert.That(!extraArgs.ContainsItem(null), "Null value given to factory constructor arguments when instantiating object with type '{0}'. In order to use null use InstantiateExplicit", concreteType);
		return InstantiateExplicit(concreteType, InjectUtil.CreateArgList(extraArgs));
	}

	public TContract InstantiateComponent<TContract>(GameObject gameObject) where TContract : Component
	{
		return InstantiateComponent<TContract>(gameObject, new object[0]);
	}

	public TContract InstantiateComponent<TContract>(GameObject gameObject, IEnumerable<object> extraArgs) where TContract : Component
	{
		return (TContract)InstantiateComponent(typeof(TContract), gameObject, extraArgs);
	}

	public Component InstantiateComponent(Type componentType, GameObject gameObject)
	{
		return InstantiateComponent(componentType, gameObject, new object[0]);
	}

	public Component InstantiateComponent(Type componentType, GameObject gameObject, IEnumerable<object> extraArgs)
	{
		return InstantiateComponentExplicit(componentType, gameObject, InjectUtil.CreateArgList(extraArgs));
	}

	public T InstantiateComponentOnNewGameObject<T>() where T : Component
	{
		return InstantiateComponentOnNewGameObject<T>(typeof(T).Name);
	}

	public T InstantiateComponentOnNewGameObject<T>(IEnumerable<object> extraArgs) where T : Component
	{
		return InstantiateComponentOnNewGameObject<T>(typeof(T).Name, extraArgs);
	}

	public T InstantiateComponentOnNewGameObject<T>(string gameObjectName) where T : Component
	{
		return InstantiateComponentOnNewGameObject<T>(gameObjectName, new object[0]);
	}

	public T InstantiateComponentOnNewGameObject<T>(string gameObjectName, IEnumerable<object> extraArgs) where T : Component
	{
		return InstantiateComponent<T>(CreateEmptyGameObject(gameObjectName), extraArgs);
	}

	public GameObject InstantiatePrefab(UnityEngine.Object prefab)
	{
		return InstantiatePrefab(prefab, GameObjectCreationParameters.Default);
	}

	public GameObject InstantiatePrefab(UnityEngine.Object prefab, Transform parentTransform)
	{
		return InstantiatePrefab(prefab, new GameObjectCreationParameters
		{
			ParentTransform = parentTransform
		});
	}

	public GameObject InstantiatePrefab(UnityEngine.Object prefab, Vector3 position, Quaternion rotation, Transform parentTransform)
	{
		return InstantiatePrefab(prefab, new GameObjectCreationParameters
		{
			ParentTransform = parentTransform,
			Position = position,
			Rotation = rotation
		});
	}

	public GameObject InstantiatePrefab(UnityEngine.Object prefab, GameObjectCreationParameters gameObjectBindInfo)
	{
		FlushBindings();
		GameObject gameObject = CreateAndParentPrefab(prefab, gameObjectBindInfo, null, out var shouldMakeActive);
		InjectGameObject(gameObject);
		if (shouldMakeActive)
		{
			gameObject.SetActive(value: true);
		}
		return gameObject;
	}

	public GameObject InstantiatePrefabResource(string resourcePath)
	{
		return InstantiatePrefabResource(resourcePath, GameObjectCreationParameters.Default);
	}

	public GameObject InstantiatePrefabResource(string resourcePath, Transform parentTransform)
	{
		return InstantiatePrefabResource(resourcePath, new GameObjectCreationParameters
		{
			ParentTransform = parentTransform
		});
	}

	public GameObject InstantiatePrefabResource(string resourcePath, Vector3 position, Quaternion rotation, Transform parentTransform)
	{
		return InstantiatePrefabResource(resourcePath, new GameObjectCreationParameters
		{
			ParentTransform = parentTransform,
			Position = position,
			Rotation = rotation
		});
	}

	public GameObject InstantiatePrefabResource(string resourcePath, GameObjectCreationParameters creationInfo)
	{
		GameObject gameObject = (GameObject)Resources.Load(resourcePath);
		Assert.IsNotNull(gameObject, "Could not find prefab at resource location '{0}'".Fmt(resourcePath));
		return InstantiatePrefab(gameObject, creationInfo);
	}

	public T InstantiatePrefabForComponent<T>(UnityEngine.Object prefab)
	{
		return (T)InstantiatePrefabForComponent(typeof(T), prefab, null, new object[0]);
	}

	public T InstantiatePrefabForComponent<T>(UnityEngine.Object prefab, IEnumerable<object> extraArgs)
	{
		return (T)InstantiatePrefabForComponent(typeof(T), prefab, null, extraArgs);
	}

	public T InstantiatePrefabForComponent<T>(UnityEngine.Object prefab, Transform parentTransform)
	{
		return (T)InstantiatePrefabForComponent(typeof(T), prefab, parentTransform, new object[0]);
	}

	public T InstantiatePrefabForComponent<T>(UnityEngine.Object prefab, Transform parentTransform, IEnumerable<object> extraArgs)
	{
		return (T)InstantiatePrefabForComponent(typeof(T), prefab, parentTransform, extraArgs);
	}

	public T InstantiatePrefabForComponent<T>(UnityEngine.Object prefab, Vector3 position, Quaternion rotation, Transform parentTransform)
	{
		return (T)InstantiatePrefabForComponent(typeof(T), prefab, new object[0], new GameObjectCreationParameters
		{
			ParentTransform = parentTransform,
			Position = position,
			Rotation = rotation
		});
	}

	public T InstantiatePrefabForComponent<T>(UnityEngine.Object prefab, Vector3 position, Quaternion rotation, Transform parentTransform, IEnumerable<object> extraArgs)
	{
		return (T)InstantiatePrefabForComponent(typeof(T), prefab, extraArgs, new GameObjectCreationParameters
		{
			ParentTransform = parentTransform,
			Position = position,
			Rotation = rotation
		});
	}

	public object InstantiatePrefabForComponent(Type concreteType, UnityEngine.Object prefab, Transform parentTransform, IEnumerable<object> extraArgs)
	{
		return InstantiatePrefabForComponent(concreteType, prefab, extraArgs, new GameObjectCreationParameters
		{
			ParentTransform = parentTransform
		});
	}

	public object InstantiatePrefabForComponent(Type concreteType, UnityEngine.Object prefab, IEnumerable<object> extraArgs, GameObjectCreationParameters creationInfo)
	{
		return InstantiatePrefabForComponentExplicit(concreteType, prefab, InjectUtil.CreateArgList(extraArgs), creationInfo);
	}

	public T InstantiatePrefabResourceForComponent<T>(string resourcePath)
	{
		return (T)InstantiatePrefabResourceForComponent(typeof(T), resourcePath, null, new object[0]);
	}

	public T InstantiatePrefabResourceForComponent<T>(string resourcePath, IEnumerable<object> extraArgs)
	{
		return (T)InstantiatePrefabResourceForComponent(typeof(T), resourcePath, null, extraArgs);
	}

	public T InstantiatePrefabResourceForComponent<T>(string resourcePath, Transform parentTransform)
	{
		return (T)InstantiatePrefabResourceForComponent(typeof(T), resourcePath, parentTransform, new object[0]);
	}

	public T InstantiatePrefabResourceForComponent<T>(string resourcePath, Transform parentTransform, IEnumerable<object> extraArgs)
	{
		return (T)InstantiatePrefabResourceForComponent(typeof(T), resourcePath, parentTransform, extraArgs);
	}

	public T InstantiatePrefabResourceForComponent<T>(string resourcePath, Vector3 position, Quaternion rotation, Transform parentTransform)
	{
		return InstantiatePrefabResourceForComponent<T>(resourcePath, position, rotation, parentTransform, new object[0]);
	}

	public T InstantiatePrefabResourceForComponent<T>(string resourcePath, Vector3 position, Quaternion rotation, Transform parentTransform, IEnumerable<object> extraArgs)
	{
		List<TypeValuePair> extraArgs2 = InjectUtil.CreateArgList(extraArgs);
		GameObjectCreationParameters creationInfo = new GameObjectCreationParameters
		{
			ParentTransform = parentTransform,
			Position = position,
			Rotation = rotation
		};
		return (T)InstantiatePrefabResourceForComponentExplicit(typeof(T), resourcePath, extraArgs2, creationInfo);
	}

	public object InstantiatePrefabResourceForComponent(Type concreteType, string resourcePath, Transform parentTransform, IEnumerable<object> extraArgs)
	{
		Assert.That(!extraArgs.ContainsItem(null), "Null value given to factory constructor arguments when instantiating object with type '{0}'. In order to use null use InstantiatePrefabForComponentExplicit", concreteType);
		return InstantiatePrefabResourceForComponentExplicit(concreteType, resourcePath, InjectUtil.CreateArgList(extraArgs), new GameObjectCreationParameters
		{
			ParentTransform = parentTransform
		});
	}

	public T InstantiateScriptableObjectResource<T>(string resourcePath) where T : ScriptableObject
	{
		return InstantiateScriptableObjectResource<T>(resourcePath, new object[0]);
	}

	public T InstantiateScriptableObjectResource<T>(string resourcePath, IEnumerable<object> extraArgs) where T : ScriptableObject
	{
		return (T)InstantiateScriptableObjectResource(typeof(T), resourcePath, extraArgs);
	}

	public object InstantiateScriptableObjectResource(Type scriptableObjectType, string resourcePath)
	{
		return InstantiateScriptableObjectResource(scriptableObjectType, resourcePath, new object[0]);
	}

	public object InstantiateScriptableObjectResource(Type scriptableObjectType, string resourcePath, IEnumerable<object> extraArgs)
	{
		Assert.DerivesFromOrEqual<ScriptableObject>(scriptableObjectType);
		return InstantiateScriptableObjectResourceExplicit(scriptableObjectType, resourcePath, InjectUtil.CreateArgList(extraArgs));
	}

	public void InjectGameObject(GameObject gameObject)
	{
		FlushBindings();
		ZenUtilInternal.AddStateMachineBehaviourAutoInjectersUnderGameObject(gameObject);
		List<MonoBehaviour> list = new List<MonoBehaviour>();
		ZenUtilInternal.GetInjectableMonoBehavioursUnderGameObject(gameObject, list);
		foreach (MonoBehaviour item in list)
		{
			Inject(item);
		}
	}

	public T InjectGameObjectForComponent<T>(GameObject gameObject) where T : Component
	{
		return InjectGameObjectForComponent<T>(gameObject, new object[0]);
	}

	public T InjectGameObjectForComponent<T>(GameObject gameObject, IEnumerable<object> extraArgs) where T : Component
	{
		return (T)InjectGameObjectForComponent(gameObject, typeof(T), extraArgs);
	}

	public object InjectGameObjectForComponent(GameObject gameObject, Type componentType, IEnumerable<object> extraArgs)
	{
		return InjectGameObjectForComponentExplicit(gameObject, componentType, new InjectArgs
		{
			ExtraArgs = InjectUtil.CreateArgList(extraArgs),
			Context = new InjectContext(this, componentType, null)
		});
	}

	public Component InjectGameObjectForComponentExplicit(GameObject gameObject, Type componentType, InjectArgs args)
	{
		if (!componentType.DerivesFrom<MonoBehaviour>() && !args.ExtraArgs.IsEmpty())
		{
			throw Assert.CreateException("Cannot inject into non-monobehaviours!  Argument list must be zero length");
		}
		ZenUtilInternal.AddStateMachineBehaviourAutoInjectersUnderGameObject(gameObject);
		List<MonoBehaviour> list = new List<MonoBehaviour>();
		ZenUtilInternal.GetInjectableMonoBehavioursUnderGameObject(gameObject, list);
		foreach (MonoBehaviour item in list)
		{
			if (item.GetType().DerivesFromOrEqual(componentType))
			{
				InjectExplicit(item, item.GetType(), args);
			}
			else
			{
				Inject(item);
			}
		}
		Component[] componentsInChildren = gameObject.GetComponentsInChildren(componentType, includeInactive: true);
		Assert.That(!componentsInChildren.IsEmpty(), "Expected to find component with type '{0}' when injecting into game object '{1}'", componentType, gameObject.name);
		Assert.That(componentsInChildren.Length == 1, "Found multiple component with type '{0}' when injecting into game object '{1}'", componentType, gameObject.name);
		return componentsInChildren[0];
	}

	public void Inject(object injectable)
	{
		Inject(injectable, new object[0]);
	}

	public void Inject(object injectable, IEnumerable<object> extraArgs)
	{
		InjectExplicit(injectable, InjectUtil.CreateArgList(extraArgs));
	}

	public TContract Resolve<TContract>()
	{
		return (TContract)Resolve(typeof(TContract));
	}

	public object Resolve(Type contractType)
	{
		return ResolveId(contractType, null);
	}

	public TContract ResolveId<TContract>(object identifier)
	{
		return (TContract)ResolveId(typeof(TContract), identifier);
	}

	public object ResolveId(Type contractType, object identifier)
	{
		using InjectContext injectContext = InjectContext.Pool.Spawn(this, contractType);
		injectContext.Identifier = identifier;
		return Resolve(injectContext);
	}

	public TContract TryResolve<TContract>() where TContract : class
	{
		return (TContract)TryResolve(typeof(TContract));
	}

	public object TryResolve(Type contractType)
	{
		return TryResolveId(contractType, null);
	}

	public TContract TryResolveId<TContract>(object identifier) where TContract : class
	{
		return (TContract)TryResolveId(typeof(TContract), identifier);
	}

	public object TryResolveId(Type contractType, object identifier)
	{
		using InjectContext injectContext = InjectContext.Pool.Spawn(this, contractType);
		injectContext.Identifier = identifier;
		injectContext.Optional = true;
		return Resolve(injectContext);
	}

	public List<TContract> ResolveAll<TContract>()
	{
		return (List<TContract>)ResolveAll(typeof(TContract));
	}

	public IList ResolveAll(Type contractType)
	{
		return ResolveIdAll(contractType, null);
	}

	public List<TContract> ResolveIdAll<TContract>(object identifier)
	{
		return (List<TContract>)ResolveIdAll(typeof(TContract), identifier);
	}

	public IList ResolveIdAll(Type contractType, object identifier)
	{
		using InjectContext injectContext = InjectContext.Pool.Spawn(this, contractType);
		injectContext.Identifier = identifier;
		injectContext.Optional = true;
		return ResolveAll(injectContext);
	}

	public void UnbindAll()
	{
		FlushBindings();
		_providers.Clear();
	}

	public bool Unbind<TContract>()
	{
		return Unbind(typeof(TContract));
	}

	public bool Unbind(Type contractType)
	{
		return UnbindId(contractType, null);
	}

	public bool UnbindId<TContract>(object identifier)
	{
		return UnbindId(typeof(TContract), identifier);
	}

	public bool UnbindId(Type contractType, object identifier)
	{
		FlushBindings();
		BindingId key = new BindingId(contractType, identifier);
		return _providers.Remove(key);
	}

	public void UnbindInterfacesTo<TConcrete>()
	{
		UnbindInterfacesTo(typeof(TConcrete));
	}

	public void UnbindInterfacesTo(Type concreteType)
	{
		Type[] array = concreteType.Interfaces();
		foreach (Type contractType in array)
		{
			Unbind(contractType, concreteType);
		}
	}

	public bool Unbind<TContract, TConcrete>()
	{
		return Unbind(typeof(TContract), typeof(TConcrete));
	}

	public bool Unbind(Type contractType, Type concreteType)
	{
		return UnbindId(contractType, concreteType, null);
	}

	public bool UnbindId<TContract, TConcrete>(object identifier)
	{
		return UnbindId(typeof(TContract), typeof(TConcrete), identifier);
	}

	public bool UnbindId(Type contractType, Type concreteType, object identifier)
	{
		FlushBindings();
		BindingId key = new BindingId(contractType, identifier);
		if (!_providers.TryGetValue(key, out var value))
		{
			return false;
		}
		List<ProviderInfo> list = value.Where((ProviderInfo x) => x.Provider.GetInstanceType(new InjectContext(this, contractType, identifier)).DerivesFromOrEqual(concreteType)).ToList();
		if (list.IsEmpty())
		{
			return false;
		}
		foreach (ProviderInfo item in list)
		{
			Assert.That(value.Remove(item));
		}
		return true;
	}

	public bool HasBinding<TContract>()
	{
		return HasBinding(typeof(TContract));
	}

	public bool HasBinding(Type contractType)
	{
		return HasBindingId(contractType, null);
	}

	public bool HasBindingId<TContract>(object identifier)
	{
		return HasBindingId(typeof(TContract), identifier);
	}

	public bool HasBindingId(Type contractType, object identifier)
	{
		return HasBindingId(contractType, identifier, InjectSources.Any);
	}

	public bool HasBindingId(Type contractType, object identifier, InjectSources sourceType)
	{
		using InjectContext injectContext = InjectContext.Pool.Spawn(this, contractType);
		injectContext.Identifier = identifier;
		injectContext.SourceType = sourceType;
		return HasBinding(injectContext);
	}

	public bool HasBinding(InjectContext context)
	{
		Assert.IsNotNull(context);
		FlushBindings();
		using DisposeBlock disposeBlock = DisposeBlock.Spawn();
		List<ProviderInfo> list = disposeBlock.SpawnList<ProviderInfo>();
		GetProviderMatches(context, list);
		return list.Count > 0;
	}

	public void FlushBindings()
	{
		while (_currentBindings.Count > 0)
		{
			IBindingFinalizer bindingFinalizer = _currentBindings.Dequeue();
			if (bindingFinalizer.BindingInheritanceMethod != BindingInheritanceMethods.MoveDirectOnly && bindingFinalizer.BindingInheritanceMethod != BindingInheritanceMethods.MoveIntoAll)
			{
				FinalizeBinding(bindingFinalizer);
			}
			if (bindingFinalizer.BindingInheritanceMethod != BindingInheritanceMethods.None)
			{
				_childBindings.Add(bindingFinalizer);
			}
		}
	}

	private void FinalizeBinding(IBindingFinalizer binding)
	{
		_isFinalizingBinding = true;
		try
		{
			binding.FinalizeBinding(this);
		}
		finally
		{
			_isFinalizingBinding = false;
		}
	}

	public BindFinalizerWrapper StartBinding(string errorContext = null, bool flush = true)
	{
		Assert.That(!_isFinalizingBinding, "Attempted to start a binding during a binding finalizer.  This is not allowed, since binding finalizers should directly use AddProvider instead, to allow for bindings to be inherited properly without duplicates");
		if (flush)
		{
			FlushBindings();
		}
		BindFinalizerWrapper bindFinalizerWrapper = new BindFinalizerWrapper(errorContext);
		_currentBindings.Enqueue(bindFinalizerWrapper);
		return bindFinalizerWrapper;
	}

	public ConcreteBinderGeneric<TContract> Rebind<TContract>()
	{
		return RebindId<TContract>(null);
	}

	public ConcreteBinderGeneric<TContract> RebindId<TContract>(object identifier)
	{
		UnbindId<TContract>(identifier);
		return Bind<TContract>().WithId(identifier);
	}

	public ConcreteBinderNonGeneric Rebind(Type contractType)
	{
		return RebindId(contractType, null);
	}

	public ConcreteBinderNonGeneric RebindId(Type contractType, object identifier)
	{
		UnbindId(contractType, identifier);
		return Bind(contractType).WithId(identifier);
	}

	public ConcreteIdBinderGeneric<TContract> Bind<TContract>()
	{
		return Bind<TContract>(StartBinding());
	}

	public ConcreteIdBinderGeneric<TContract> BindNoFlush<TContract>()
	{
		return Bind<TContract>(StartBinding(null, flush: false));
	}

	private ConcreteIdBinderGeneric<TContract> Bind<TContract>(BindFinalizerWrapper finalizerWrapper)
	{
		BindInfo bindInfo = new BindInfo();
		Assert.That(!typeof(TContract).DerivesFrom<IPlaceholderFactory>(), "You should not use Container.Bind for factory classes.  Use Container.BindFactory instead.");
		Assert.That(!bindInfo.ContractTypes.Contains(typeof(TContract)));
		bindInfo.ContractTypes.Add(typeof(TContract));
		return new ConcreteIdBinderGeneric<TContract>(this, bindInfo, finalizerWrapper);
	}

	public ConcreteIdBinderNonGeneric Bind(params Type[] contractTypes)
	{
		BindInfo bindInfo = new BindInfo();
		bindInfo.ContractTypes.AddRange(contractTypes);
		return BindInternal(bindInfo, StartBinding());
	}

	public ConcreteIdBinderNonGeneric Bind(IEnumerable<Type> contractTypes)
	{
		BindInfo bindInfo = new BindInfo();
		bindInfo.ContractTypes.AddRange(contractTypes);
		return BindInternal(bindInfo, StartBinding());
	}

	private ConcreteIdBinderNonGeneric BindInternal(BindInfo bindInfo, BindFinalizerWrapper bindingFinalizer)
	{
		Assert.That(bindInfo.ContractTypes.All((Type x) => !x.DerivesFrom<IPlaceholderFactory>()), "You should not use Container.Bind for factory classes.  Use Container.BindFactory instead.");
		return new ConcreteIdBinderNonGeneric(this, bindInfo, bindingFinalizer);
	}

	public ConcreteIdBinderNonGeneric Bind(Action<ConventionSelectTypesBinder> generator)
	{
		ConventionBindInfo conventionBindInfo = new ConventionBindInfo();
		generator(new ConventionSelectTypesBinder(conventionBindInfo));
		List<Type> list = conventionBindInfo.ResolveTypes();
		Assert.That(list.All((Type x) => !x.DerivesFrom<IPlaceholderFactory>()), "You should not use Container.Bind for factory classes.  Use Container.BindFactory instead.");
		BindInfo bindInfo = new BindInfo();
		bindInfo.ContractTypes.AddRange(list);
		bindInfo.InvalidBindResponse = InvalidBindResponses.Skip;
		return new ConcreteIdBinderNonGeneric(this, bindInfo, StartBinding());
	}

	public FromBinderNonGeneric BindInterfacesTo<T>()
	{
		return BindInterfacesTo(typeof(T));
	}

	public FromBinderNonGeneric BindInterfacesTo(Type type)
	{
		BindInfo bindInfo = new BindInfo();
		Type[] array = type.Interfaces();
		if (array.IsEmpty())
		{
			Log.Warn("Called BindInterfacesTo for type {0} but no interfaces were found", type);
		}
		bindInfo.ContractTypes.AddRange(array);
		bindInfo.RequireExplicitScope = true;
		return BindInternal(bindInfo, StartBinding()).To(type);
	}

	public FromBinderNonGeneric BindInterfacesAndSelfTo<T>()
	{
		return BindInterfacesAndSelfTo(typeof(T));
	}

	public FromBinderNonGeneric BindInterfacesAndSelfTo(Type type)
	{
		BindInfo bindInfo = new BindInfo();
		bindInfo.ContractTypes.AddRange(type.Interfaces());
		bindInfo.ContractTypes.Add(type);
		bindInfo.RequireExplicitScope = true;
		return BindInternal(bindInfo, StartBinding()).To(type);
	}

	public IdScopeConcreteIdArgConditionCopyNonLazyBinder BindInstance<TContract>(TContract instance)
	{
		BindInfo bindInfo = new BindInfo();
		bindInfo.ContractTypes.Add(typeof(TContract));
		StartBinding().SubFinalizer = new ScopableBindingFinalizer(bindInfo, (DiContainer container, Type type) => new InstanceProvider(type, instance, container));
		return new IdScopeConcreteIdArgConditionCopyNonLazyBinder(bindInfo);
	}

	public void BindInstances(params object[] instances)
	{
		foreach (object obj in instances)
		{
			Assert.That(!ZenUtilInternal.IsNull(obj), "Found null instance provided to BindInstances method");
			Bind(obj.GetType()).FromInstance(obj);
		}
	}

	private FactoryToChoiceIdBinder<TContract> BindFactoryInternal<TContract, TFactoryContract, TFactoryConcrete>() where TFactoryContract : IFactory where TFactoryConcrete : TFactoryContract, IFactory
	{
		BindInfo bindInfo = new BindInfo();
		bindInfo.ContractTypes.Add(typeof(TFactoryContract));
		FactoryBindInfo factoryBindInfo = new FactoryBindInfo(typeof(TFactoryConcrete));
		StartBinding().SubFinalizer = new PlaceholderFactoryBindingFinalizer<TContract>(bindInfo, factoryBindInfo);
		return new FactoryToChoiceIdBinder<TContract>(this, bindInfo, factoryBindInfo);
	}

	public FactoryToChoiceIdBinder<TContract> BindIFactory<TContract>()
	{
		return BindFactoryInternal<TContract, IFactory<TContract>, PlaceholderFactory<TContract>>();
	}

	public FactoryToChoiceIdBinder<TContract> BindFactory<TContract, TFactory>() where TFactory : PlaceholderFactory<TContract>
	{
		return BindFactoryInternal<TContract, TFactory, TFactory>();
	}

	public FactoryToChoiceIdBinder<TContract> BindFactoryCustomInterface<TContract, TFactoryConcrete, TFactoryContract>() where TFactoryConcrete : PlaceholderFactory<TContract>, TFactoryContract where TFactoryContract : IFactory
	{
		return BindFactoryInternal<TContract, TFactoryContract, TFactoryConcrete>();
	}

	public MemoryPoolIdInitialSizeMaxSizeBinder<TItemContract> BindMemoryPool<TItemContract>()
	{
		return BindMemoryPool<TItemContract, MemoryPool<TItemContract>>();
	}

	public MemoryPoolIdInitialSizeMaxSizeBinder<TItemContract> BindMemoryPool<TItemContract, TPool>() where TPool : IMemoryPool
	{
		return BindMemoryPoolCustomInterface<TItemContract, TPool, TPool>();
	}

	public MemoryPoolIdInitialSizeMaxSizeBinder<TItemContract> BindMemoryPoolCustomInterface<TItemContract, TPoolConcrete, TPoolContract>(bool includeConcreteType = false) where TPoolConcrete : TPoolContract, IMemoryPool where TPoolContract : IMemoryPool
	{
		return BindMemoryPoolCustomInterfaceInternal<TItemContract, TPoolConcrete, TPoolContract>(includeConcreteType, StartBinding());
	}

	internal MemoryPoolIdInitialSizeMaxSizeBinder<TItemContract> BindMemoryPoolCustomInterfaceNoFlush<TItemContract, TPoolConcrete, TPoolContract>(bool includeConcreteType = false) where TPoolConcrete : TPoolContract, IMemoryPool where TPoolContract : IMemoryPool
	{
		return BindMemoryPoolCustomInterfaceInternal<TItemContract, TPoolConcrete, TPoolContract>(includeConcreteType, StartBinding(null, flush: false));
	}

	private MemoryPoolIdInitialSizeMaxSizeBinder<TItemContract> BindMemoryPoolCustomInterfaceInternal<TItemContract, TPoolConcrete, TPoolContract>(bool includeConcreteType, BindFinalizerWrapper bindFinalizerWrapper) where TPoolConcrete : TPoolContract, IMemoryPool where TPoolContract : IMemoryPool
	{
		List<Type> list = new List<Type>
		{
			typeof(IDisposable),
			typeof(TPoolContract)
		};
		if (includeConcreteType)
		{
			list.Add(typeof(TPoolConcrete));
		}
		BindInfo bindInfo = new BindInfo();
		bindInfo.ContractTypes.AddRange(list);
		bindInfo.ContractTypes.Add(typeof(IMemoryPool));
		FactoryBindInfo factoryBindInfo = new FactoryBindInfo(typeof(TPoolConcrete));
		MemoryPoolBindInfo poolBindInfo = new MemoryPoolBindInfo();
		bindFinalizerWrapper.SubFinalizer = new MemoryPoolBindingFinalizer<TItemContract>(bindInfo, factoryBindInfo, poolBindInfo);
		return new MemoryPoolIdInitialSizeMaxSizeBinder<TItemContract>(this, bindInfo, factoryBindInfo, poolBindInfo);
	}

	private FactoryToChoiceIdBinder<TParam1, TContract> BindFactoryInternal<TParam1, TContract, TFactoryContract, TFactoryConcrete>() where TFactoryContract : IFactory where TFactoryConcrete : TFactoryContract, IFactory
	{
		BindInfo bindInfo = new BindInfo();
		bindInfo.ContractTypes.Add(typeof(TFactoryContract));
		FactoryBindInfo factoryBindInfo = new FactoryBindInfo(typeof(TFactoryConcrete));
		StartBinding().SubFinalizer = new PlaceholderFactoryBindingFinalizer<TContract>(bindInfo, factoryBindInfo);
		return new FactoryToChoiceIdBinder<TParam1, TContract>(this, bindInfo, factoryBindInfo);
	}

	public FactoryToChoiceIdBinder<TParam1, TContract> BindIFactory<TParam1, TContract>()
	{
		return BindFactoryInternal<TParam1, TContract, IFactory<TParam1, TContract>, PlaceholderFactory<TParam1, TContract>>();
	}

	public FactoryToChoiceIdBinder<TParam1, TContract> BindFactory<TParam1, TContract, TFactory>() where TFactory : PlaceholderFactory<TParam1, TContract>
	{
		return BindFactoryInternal<TParam1, TContract, TFactory, TFactory>();
	}

	public FactoryToChoiceIdBinder<TParam1, TContract> BindFactoryCustomInterface<TParam1, TContract, TFactoryConcrete, TFactoryContract>() where TFactoryConcrete : PlaceholderFactory<TParam1, TContract>, TFactoryContract where TFactoryContract : IFactory
	{
		return BindFactoryInternal<TParam1, TContract, TFactoryContract, TFactoryConcrete>();
	}

	private FactoryToChoiceIdBinder<TParam1, TParam2, TContract> BindFactoryInternal<TParam1, TParam2, TContract, TFactoryContract, TFactoryConcrete>() where TFactoryContract : IFactory where TFactoryConcrete : TFactoryContract, IFactory
	{
		BindInfo bindInfo = new BindInfo();
		bindInfo.ContractTypes.Add(typeof(TFactoryContract));
		FactoryBindInfo factoryBindInfo = new FactoryBindInfo(typeof(TFactoryConcrete));
		StartBinding().SubFinalizer = new PlaceholderFactoryBindingFinalizer<TContract>(bindInfo, factoryBindInfo);
		return new FactoryToChoiceIdBinder<TParam1, TParam2, TContract>(this, bindInfo, factoryBindInfo);
	}

	public FactoryToChoiceIdBinder<TParam1, TParam2, TContract> BindIFactory<TParam1, TParam2, TContract>()
	{
		return BindFactoryInternal<TParam1, TParam2, TContract, IFactory<TParam1, TParam2, TContract>, PlaceholderFactory<TParam1, TParam2, TContract>>();
	}

	public FactoryToChoiceIdBinder<TParam1, TParam2, TContract> BindFactory<TParam1, TParam2, TContract, TFactory>() where TFactory : PlaceholderFactory<TParam1, TParam2, TContract>
	{
		return BindFactoryInternal<TParam1, TParam2, TContract, TFactory, TFactory>();
	}

	public FactoryToChoiceIdBinder<TParam1, TParam2, TContract> BindFactoryCustomInterface<TParam1, TParam2, TContract, TFactoryConcrete, TFactoryContract>() where TFactoryConcrete : PlaceholderFactory<TParam1, TParam2, TContract>, TFactoryContract where TFactoryContract : IFactory
	{
		return BindFactoryInternal<TParam1, TParam2, TContract, TFactoryContract, TFactoryConcrete>();
	}

	private FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TContract> BindFactoryInternal<TParam1, TParam2, TParam3, TContract, TFactoryContract, TFactoryConcrete>() where TFactoryContract : IFactory where TFactoryConcrete : TFactoryContract, IFactory
	{
		BindInfo bindInfo = new BindInfo();
		bindInfo.ContractTypes.Add(typeof(TFactoryContract));
		FactoryBindInfo factoryBindInfo = new FactoryBindInfo(typeof(TFactoryConcrete));
		StartBinding().SubFinalizer = new PlaceholderFactoryBindingFinalizer<TContract>(bindInfo, factoryBindInfo);
		return new FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TContract>(this, bindInfo, factoryBindInfo);
	}

	public FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TContract> BindIFactory<TParam1, TParam2, TParam3, TContract>()
	{
		return BindFactoryInternal<TParam1, TParam2, TParam3, TContract, IFactory<TParam1, TParam2, TParam3, TContract>, PlaceholderFactory<TParam1, TParam2, TParam3, TContract>>();
	}

	public FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TContract> BindFactory<TParam1, TParam2, TParam3, TContract, TFactory>() where TFactory : PlaceholderFactory<TParam1, TParam2, TParam3, TContract>
	{
		return BindFactoryInternal<TParam1, TParam2, TParam3, TContract, TFactory, TFactory>();
	}

	public FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TContract> BindFactoryCustomInterface<TParam1, TParam2, TParam3, TContract, TFactoryConcrete, TFactoryContract>() where TFactoryConcrete : PlaceholderFactory<TParam1, TParam2, TParam3, TContract>, TFactoryContract where TFactoryContract : IFactory
	{
		return BindFactoryInternal<TParam1, TParam2, TParam3, TContract, TFactoryContract, TFactoryConcrete>();
	}

	private FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TParam4, TContract> BindFactoryInternal<TParam1, TParam2, TParam3, TParam4, TContract, TFactoryContract, TFactoryConcrete>() where TFactoryContract : IFactory where TFactoryConcrete : TFactoryContract, IFactory
	{
		BindInfo bindInfo = new BindInfo();
		bindInfo.ContractTypes.Add(typeof(TFactoryContract));
		FactoryBindInfo factoryBindInfo = new FactoryBindInfo(typeof(TFactoryConcrete));
		StartBinding().SubFinalizer = new PlaceholderFactoryBindingFinalizer<TContract>(bindInfo, factoryBindInfo);
		return new FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TParam4, TContract>(this, bindInfo, factoryBindInfo);
	}

	public FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TParam4, TContract> BindIFactory<TParam1, TParam2, TParam3, TParam4, TContract>()
	{
		return BindFactoryInternal<TParam1, TParam2, TParam3, TParam4, TContract, IFactory<TParam1, TParam2, TParam3, TParam4, TContract>, PlaceholderFactory<TParam1, TParam2, TParam3, TParam4, TContract>>();
	}

	public FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TParam4, TContract> BindFactory<TParam1, TParam2, TParam3, TParam4, TContract, TFactory>() where TFactory : PlaceholderFactory<TParam1, TParam2, TParam3, TParam4, TContract>
	{
		return BindFactoryInternal<TParam1, TParam2, TParam3, TParam4, TContract, TFactory, TFactory>();
	}

	public FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TParam4, TContract> BindFactoryCustomInterface<TParam1, TParam2, TParam3, TParam4, TContract, TFactoryConcrete, TFactoryContract>() where TFactoryConcrete : PlaceholderFactory<TParam1, TParam2, TParam3, TParam4, TContract>, TFactoryContract where TFactoryContract : IFactory
	{
		return BindFactoryInternal<TParam1, TParam2, TParam3, TParam4, TContract, TFactoryContract, TFactoryConcrete>();
	}

	private FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TParam4, TParam5, TContract> BindFactoryInternal<TParam1, TParam2, TParam3, TParam4, TParam5, TContract, TFactoryContract, TFactoryConcrete>() where TFactoryContract : IFactory where TFactoryConcrete : TFactoryContract, IFactory
	{
		BindInfo bindInfo = new BindInfo();
		bindInfo.ContractTypes.Add(typeof(TFactoryContract));
		FactoryBindInfo factoryBindInfo = new FactoryBindInfo(typeof(TFactoryConcrete));
		StartBinding().SubFinalizer = new PlaceholderFactoryBindingFinalizer<TContract>(bindInfo, factoryBindInfo);
		return new FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TParam4, TParam5, TContract>(this, bindInfo, factoryBindInfo);
	}

	public FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TParam4, TParam5, TContract> BindIFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TContract>()
	{
		return BindFactoryInternal<TParam1, TParam2, TParam3, TParam4, TParam5, TContract, IFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TContract>, PlaceholderFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TContract>>();
	}

	public FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TParam4, TParam5, TContract> BindFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TContract, TFactory>() where TFactory : PlaceholderFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TContract>
	{
		return BindFactoryInternal<TParam1, TParam2, TParam3, TParam4, TParam5, TContract, TFactory, TFactory>();
	}

	public FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TParam4, TParam5, TContract> BindFactoryCustomInterface<TParam1, TParam2, TParam3, TParam4, TParam5, TContract, TFactoryConcrete, TFactoryContract>() where TFactoryConcrete : PlaceholderFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TContract>, TFactoryContract where TFactoryContract : IFactory
	{
		return BindFactoryInternal<TParam1, TParam2, TParam3, TParam4, TParam5, TContract, TFactoryContract, TFactoryConcrete>();
	}

	private FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TContract> BindFactoryInternal<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TContract, TFactoryContract, TFactoryConcrete>() where TFactoryContract : IFactory where TFactoryConcrete : TFactoryContract, IFactory
	{
		BindInfo bindInfo = new BindInfo();
		bindInfo.ContractTypes.Add(typeof(TFactoryContract));
		FactoryBindInfo factoryBindInfo = new FactoryBindInfo(typeof(TFactoryConcrete));
		StartBinding().SubFinalizer = new PlaceholderFactoryBindingFinalizer<TContract>(bindInfo, factoryBindInfo);
		return new FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TContract>(this, bindInfo, factoryBindInfo);
	}

	public FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TContract> BindIFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TContract>()
	{
		return BindFactoryInternal<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TContract, IFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TContract>, PlaceholderFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TContract>>();
	}

	public FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TContract> BindFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TContract, TFactory>() where TFactory : PlaceholderFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TContract>
	{
		return BindFactoryInternal<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TContract, TFactory, TFactory>();
	}

	public FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TContract> BindFactoryCustomInterface<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TContract, TFactoryConcrete, TFactoryContract>() where TFactoryConcrete : PlaceholderFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TContract>, TFactoryContract where TFactoryContract : IFactory
	{
		return BindFactoryInternal<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TContract, TFactoryContract, TFactoryConcrete>();
	}

	private FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TContract> BindFactoryInternal<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TContract, TFactoryContract, TFactoryConcrete>() where TFactoryContract : IFactory where TFactoryConcrete : TFactoryContract, IFactory
	{
		BindInfo bindInfo = new BindInfo();
		bindInfo.ContractTypes.Add(typeof(TFactoryContract));
		FactoryBindInfo factoryBindInfo = new FactoryBindInfo(typeof(TFactoryConcrete));
		StartBinding().SubFinalizer = new PlaceholderFactoryBindingFinalizer<TContract>(bindInfo, factoryBindInfo);
		return new FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TContract>(this, bindInfo, factoryBindInfo);
	}

	public FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TContract> BindIFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TContract>()
	{
		return BindFactoryInternal<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TContract, IFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TContract>, PlaceholderFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TContract>>();
	}

	public FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TContract> BindFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TContract, TFactory>() where TFactory : PlaceholderFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TContract>
	{
		return BindFactoryInternal<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TContract, TFactory, TFactory>();
	}

	public FactoryToChoiceIdBinder<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TContract> BindFactoryCustomInterface<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TContract, TFactoryConcrete, TFactoryContract>() where TFactoryConcrete : PlaceholderFactory<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TContract>, TFactoryContract where TFactoryContract : IFactory
	{
		return BindFactoryInternal<TParam1, TParam2, TParam3, TParam4, TParam5, TParam6, TParam7, TParam8, TParam9, TParam10, TContract, TFactoryContract, TFactoryConcrete>();
	}

	public T InstantiateExplicit<T>(List<TypeValuePair> extraArgs)
	{
		return (T)InstantiateExplicit(typeof(T), extraArgs);
	}

	public Lazy<T> InstantiateLazy<T>()
	{
		return InstantiateLazy<T>(typeof(T));
	}

	public Lazy<T> InstantiateLazy<T>(Type concreteType)
	{
		Assert.That(concreteType.DerivesFromOrEqual<T>());
		return new Lazy<T>(() => (T)Instantiate(concreteType));
	}

	public Lazy<T> ResolveLazy<T>()
	{
		return ResolveLazy<T>(typeof(T));
	}

	public Lazy<T> ResolveLazy<T>(Type concreteType)
	{
		Assert.That(concreteType.DerivesFromOrEqual<T>());
		return new Lazy<T>(() => (T)Resolve(concreteType));
	}

	public object InstantiateExplicit(Type concreteType, List<TypeValuePair> extraArgs)
	{
		bool autoInject = true;
		return InstantiateExplicit(concreteType, autoInject, new InjectArgs
		{
			ExtraArgs = extraArgs,
			Context = new InjectContext(this, concreteType, null)
		});
	}

	public object InstantiateExplicit(Type concreteType, bool autoInject, InjectArgs args)
	{
		if (IsValidating)
		{
			if (_settings.ValidationErrorResponse == ValidationErrorResponses.Throw)
			{
				return InstantiateInternal(concreteType, autoInject, args);
			}
			try
			{
				return InstantiateInternal(concreteType, autoInject, args);
			}
			catch (Exception e)
			{
				Log.ErrorException(e);
				return new ValidationMarker(concreteType, instantiateFailed: true);
			}
		}
		return InstantiateInternal(concreteType, autoInject, args);
	}

	public Component InstantiateComponentExplicit(Type componentType, GameObject gameObject, List<TypeValuePair> extraArgs)
	{
		Assert.That(componentType.DerivesFrom<Component>());
		FlushBindings();
		Component component = gameObject.AddComponent(componentType);
		InjectExplicit(component, extraArgs);
		return component;
	}

	public object InstantiateScriptableObjectResourceExplicit(Type scriptableObjectType, string resourcePath, List<TypeValuePair> extraArgs)
	{
		UnityEngine.Object[] array = Resources.LoadAll(resourcePath, scriptableObjectType);
		Assert.That(!array.IsEmpty(), "Could not find resource at path '{0}' with type '{1}'", resourcePath, scriptableObjectType);
		Assert.That(array.Length == 1, "Found multiple scriptable objects at path '{0}' when only 1 was expected with type '{1}'", resourcePath, scriptableObjectType);
		UnityEngine.Object obj = UnityEngine.Object.Instantiate(array.Single());
		InjectExplicit(obj, extraArgs);
		return obj;
	}

	public object InstantiatePrefabResourceForComponentExplicit(Type componentType, string resourcePath, List<TypeValuePair> extraArgs, GameObjectCreationParameters creationInfo)
	{
		return InstantiatePrefabResourceForComponentExplicit(componentType, resourcePath, new InjectArgs
		{
			ExtraArgs = extraArgs,
			Context = new InjectContext(this, componentType, null)
		}, creationInfo);
	}

	public object InstantiatePrefabResourceForComponentExplicit(Type componentType, string resourcePath, InjectArgs args, GameObjectCreationParameters creationInfo)
	{
		GameObject gameObject = (GameObject)Resources.Load(resourcePath);
		Assert.IsNotNull(gameObject, "Could not find prefab at resource location '{0}'".Fmt(resourcePath));
		return InstantiatePrefabForComponentExplicit(componentType, gameObject, args, creationInfo);
	}

	public object InstantiatePrefabForComponentExplicit(Type componentType, UnityEngine.Object prefab, List<TypeValuePair> extraArgs)
	{
		return InstantiatePrefabForComponentExplicit(componentType, prefab, extraArgs, GameObjectCreationParameters.Default);
	}

	public object InstantiatePrefabForComponentExplicit(Type componentType, UnityEngine.Object prefab, List<TypeValuePair> extraArgs, GameObjectCreationParameters gameObjectBindInfo)
	{
		return InstantiatePrefabForComponentExplicit(componentType, prefab, new InjectArgs
		{
			ExtraArgs = extraArgs,
			Context = new InjectContext(this, componentType, null)
		}, gameObjectBindInfo);
	}

	public object InstantiatePrefabForComponentExplicit(Type componentType, UnityEngine.Object prefab, InjectArgs args, GameObjectCreationParameters gameObjectBindInfo)
	{
		Assert.That(!AssertOnNewGameObjects, "Given DiContainer does not support creating new game objects");
		FlushBindings();
		Assert.That(componentType.IsInterface() || componentType.DerivesFrom<Component>(), "Expected type '{0}' to derive from UnityEngine.Component", componentType);
		GameObject gameObject = CreateAndParentPrefab(prefab, gameObjectBindInfo, args.Context, out var shouldMakeActive);
		Component result = InjectGameObjectForComponentExplicit(gameObject, componentType, args);
		if (shouldMakeActive)
		{
			gameObject.SetActive(value: true);
		}
		return result;
	}

	public void BindExecutionOrder<T>(int order)
	{
		BindExecutionOrder(typeof(T), order);
	}

	public void BindExecutionOrder(Type type, int order)
	{
		Assert.That(type.DerivesFrom<ITickable>() || type.DerivesFrom<IInitializable>() || type.DerivesFrom<IDisposable>() || type.DerivesFrom<ILateDisposable>() || type.DerivesFrom<IFixedTickable>() || type.DerivesFrom<ILateTickable>() || type.DerivesFrom<IPoolable>(), "Expected type '{0}' to derive from one or more of the following interfaces: ITickable, IInitializable, ILateTickable, IFixedTickable, IDisposable, ILateDisposable", type);
		if (type.DerivesFrom<ITickable>())
		{
			BindTickableExecutionOrder(type, order);
		}
		if (type.DerivesFrom<IInitializable>())
		{
			BindInitializableExecutionOrder(type, order);
		}
		if (type.DerivesFrom<IDisposable>())
		{
			BindDisposableExecutionOrder(type, order);
		}
		if (type.DerivesFrom<ILateDisposable>())
		{
			BindLateDisposableExecutionOrder(type, order);
		}
		if (type.DerivesFrom<IFixedTickable>())
		{
			BindFixedTickableExecutionOrder(type, order);
		}
		if (type.DerivesFrom<ILateTickable>())
		{
			BindLateTickableExecutionOrder(type, order);
		}
		if (type.DerivesFrom<IPoolable>())
		{
			BindPoolableExecutionOrder(type, order);
		}
	}

	public CopyNonLazyBinder BindTickableExecutionOrder<T>(int order) where T : ITickable
	{
		return BindTickableExecutionOrder(typeof(T), order);
	}

	public CopyNonLazyBinder BindTickableExecutionOrder(Type type, int order)
	{
		Assert.That(type.DerivesFrom<ITickable>(), "Expected type '{0}' to derive from ITickable", type);
		return BindInstance(ValuePair.New(type, order)).WhenInjectedInto<TickableManager>();
	}

	public CopyNonLazyBinder BindInitializableExecutionOrder<T>(int order) where T : IInitializable
	{
		return BindInitializableExecutionOrder(typeof(T), order);
	}

	public CopyNonLazyBinder BindInitializableExecutionOrder(Type type, int order)
	{
		Assert.That(type.DerivesFrom<IInitializable>(), "Expected type '{0}' to derive from IInitializable", type);
		return BindInstance(ValuePair.New(type, order)).WhenInjectedInto<InitializableManager>();
	}

	public CopyNonLazyBinder BindDisposableExecutionOrder<T>(int order) where T : IDisposable
	{
		return BindDisposableExecutionOrder(typeof(T), order);
	}

	public CopyNonLazyBinder BindLateDisposableExecutionOrder<T>(int order) where T : ILateDisposable
	{
		return BindLateDisposableExecutionOrder(typeof(T), order);
	}

	public CopyNonLazyBinder BindDisposableExecutionOrder(Type type, int order)
	{
		Assert.That(type.DerivesFrom<IDisposable>(), "Expected type '{0}' to derive from IDisposable", type);
		return BindInstance(ValuePair.New(type, order)).WhenInjectedInto<DisposableManager>();
	}

	public CopyNonLazyBinder BindLateDisposableExecutionOrder(Type type, int order)
	{
		Assert.That(type.DerivesFrom<ILateDisposable>(), "Expected type '{0}' to derive from ILateDisposable", type);
		return BindInstance(ValuePair.New(type, order)).WithId("Late").WhenInjectedInto<DisposableManager>();
	}

	public CopyNonLazyBinder BindFixedTickableExecutionOrder<T>(int order) where T : IFixedTickable
	{
		return BindFixedTickableExecutionOrder(typeof(T), order);
	}

	public CopyNonLazyBinder BindFixedTickableExecutionOrder(Type type, int order)
	{
		Assert.That(type.DerivesFrom<IFixedTickable>(), "Expected type '{0}' to derive from IFixedTickable", type);
		return Bind<ValuePair<Type, int>>().WithId("Fixed").FromInstance(ValuePair.New(type, order)).WhenInjectedInto<TickableManager>();
	}

	public CopyNonLazyBinder BindLateTickableExecutionOrder<T>(int order) where T : ILateTickable
	{
		return BindLateTickableExecutionOrder(typeof(T), order);
	}

	public CopyNonLazyBinder BindLateTickableExecutionOrder(Type type, int order)
	{
		Assert.That(type.DerivesFrom<ILateTickable>(), "Expected type '{0}' to derive from ILateTickable", type);
		return Bind<ValuePair<Type, int>>().WithId("Late").FromInstance(ValuePair.New(type, order)).WhenInjectedInto<TickableManager>();
	}

	public CopyNonLazyBinder BindPoolableExecutionOrder<T>(int order) where T : IPoolable
	{
		return BindPoolableExecutionOrder(typeof(T), order);
	}

	public CopyNonLazyBinder BindPoolableExecutionOrder(Type type, int order)
	{
		Assert.That(type.DerivesFrom<IPoolable>(), "Expected type '{0}' to derive from IPoolable", type);
		return Bind<ValuePair<Type, int>>().FromInstance(ValuePair.New(type, order)).WhenInjectedInto<PoolableManager>();
	}
}
