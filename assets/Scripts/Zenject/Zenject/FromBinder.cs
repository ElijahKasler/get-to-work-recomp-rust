using System;
using System.Collections.Generic;
using System.Linq;
using ModestTree;
using UnityEngine;

namespace Zenject;

public abstract class FromBinder : ScopeConcreteIdArgConditionCopyNonLazyBinder
{
	protected DiContainer BindContainer { get; private set; }

	protected BindFinalizerWrapper FinalizerWrapper { get; private set; }

	protected IBindingFinalizer SubFinalizer
	{
		set
		{
			FinalizerWrapper.SubFinalizer = value;
		}
	}

	protected IEnumerable<Type> AllParentTypes => base.BindInfo.ContractTypes.Concat(base.BindInfo.ToTypes);

	protected IEnumerable<Type> ConcreteTypes
	{
		get
		{
			if (base.BindInfo.ToChoice == ToChoices.Self)
			{
				return base.BindInfo.ContractTypes;
			}
			Assert.IsNotEmpty(base.BindInfo.ToTypes);
			return base.BindInfo.ToTypes;
		}
	}

	public FromBinder(DiContainer bindContainer, BindInfo bindInfo, BindFinalizerWrapper finalizerWrapper)
		: base(bindInfo)
	{
		FinalizerWrapper = finalizerWrapper;
		BindContainer = bindContainer;
	}

	public ScopeConcreteIdArgConditionCopyNonLazyBinder FromNew()
	{
		BindingUtil.AssertTypesAreNotComponents(ConcreteTypes);
		BindingUtil.AssertTypesAreNotAbstract(ConcreteTypes);
		return this;
	}

	public ScopeConcreteIdArgConditionCopyNonLazyBinder FromResolve()
	{
		return FromResolve(null);
	}

	public ScopeConcreteIdArgConditionCopyNonLazyBinder FromResolve(object subIdentifier)
	{
		return FromResolve(subIdentifier, InjectSources.Any);
	}

	public ScopeConcreteIdArgConditionCopyNonLazyBinder FromResolve(object subIdentifier, InjectSources source)
	{
		return FromResolveInternal(subIdentifier, matchAll: false, source);
	}

	public ScopeConcreteIdArgConditionCopyNonLazyBinder FromResolveAll()
	{
		return FromResolveAll(null);
	}

	public ScopeConcreteIdArgConditionCopyNonLazyBinder FromResolveAll(object subIdentifier)
	{
		return FromResolveAll(subIdentifier, InjectSources.Any);
	}

	public ScopeConcreteIdArgConditionCopyNonLazyBinder FromResolveAll(object subIdentifier, InjectSources source)
	{
		return FromResolveInternal(subIdentifier, matchAll: true, source);
	}

	private ScopeConcreteIdArgConditionCopyNonLazyBinder FromResolveInternal(object subIdentifier, bool matchAll, InjectSources source)
	{
		base.BindInfo.RequireExplicitScope = false;
		base.BindInfo.MarkAsCreationBinding = false;
		SubFinalizer = new ScopableBindingFinalizer(base.BindInfo, (DiContainer container, Type type) => new ResolveProvider(type, container, subIdentifier, isOptional: false, source, matchAll));
		return new ScopeConcreteIdArgConditionCopyNonLazyBinder(base.BindInfo);
	}

	public SubContainerBinder FromSubContainerResolveAll()
	{
		return FromSubContainerResolveAll(null);
	}

	public SubContainerBinder FromSubContainerResolveAll(object subIdentifier)
	{
		return FromSubContainerResolveInternal(subIdentifier, resolveAll: true);
	}

	public SubContainerBinder FromSubContainerResolve()
	{
		return FromSubContainerResolve(null);
	}

	public SubContainerBinder FromSubContainerResolve(object subIdentifier)
	{
		return FromSubContainerResolveInternal(subIdentifier, resolveAll: false);
	}

	private SubContainerBinder FromSubContainerResolveInternal(object subIdentifier, bool resolveAll)
	{
		base.BindInfo.RequireExplicitScope = true;
		base.BindInfo.MarkAsCreationBinding = false;
		return new SubContainerBinder(base.BindInfo, FinalizerWrapper, subIdentifier, resolveAll);
	}

	protected ScopeConcreteIdArgConditionCopyNonLazyBinder FromIFactoryBase<TContract>(Action<ConcreteBinderGeneric<IFactory<TContract>>> factoryBindGenerator)
	{
		Guid factoryId = Guid.NewGuid();
		ConcreteBinderGeneric<IFactory<TContract>> concreteBinderGeneric = BindContainer.BindNoFlush<IFactory<TContract>>().WithId(factoryId);
		factoryBindGenerator(concreteBinderGeneric);
		base.BindInfo.RequireExplicitScope = false;
		base.BindInfo.MarkAsCreationBinding = false;
		SubFinalizer = new ScopableBindingFinalizer(base.BindInfo, (DiContainer container, Type type) => new IFactoryProvider<TContract>(container, factoryId));
		ScopeConcreteIdArgConditionCopyNonLazyBinder scopeConcreteIdArgConditionCopyNonLazyBinder = new ScopeConcreteIdArgConditionCopyNonLazyBinder(base.BindInfo);
		scopeConcreteIdArgConditionCopyNonLazyBinder.AddSecondaryCopyBindInfo(concreteBinderGeneric.BindInfo);
		return scopeConcreteIdArgConditionCopyNonLazyBinder;
	}

	public ScopeConcreteIdArgConditionCopyNonLazyBinder FromComponentsOn(GameObject gameObject)
	{
		BindingUtil.AssertIsValidGameObject(gameObject);
		BindingUtil.AssertIsComponent(ConcreteTypes);
		BindingUtil.AssertTypesAreNotAbstract(ConcreteTypes);
		base.BindInfo.RequireExplicitScope = true;
		SubFinalizer = new ScopableBindingFinalizer(base.BindInfo, (DiContainer container, Type type) => new GetFromGameObjectComponentProvider(type, gameObject, matchSingle: false));
		return new ScopeConcreteIdArgConditionCopyNonLazyBinder(base.BindInfo);
	}

	public ScopeConcreteIdArgConditionCopyNonLazyBinder FromComponentOn(GameObject gameObject)
	{
		BindingUtil.AssertIsValidGameObject(gameObject);
		BindingUtil.AssertIsComponent(ConcreteTypes);
		BindingUtil.AssertTypesAreNotAbstract(ConcreteTypes);
		base.BindInfo.RequireExplicitScope = true;
		SubFinalizer = new ScopableBindingFinalizer(base.BindInfo, (DiContainer container, Type type) => new GetFromGameObjectComponentProvider(type, gameObject, matchSingle: true));
		return new ScopeConcreteIdArgConditionCopyNonLazyBinder(base.BindInfo);
	}

	public ScopeConcreteIdArgConditionCopyNonLazyBinder FromComponentsOn(Func<InjectContext, GameObject> gameObjectGetter)
	{
		BindingUtil.AssertIsComponent(ConcreteTypes);
		BindingUtil.AssertTypesAreNotAbstract(ConcreteTypes);
		base.BindInfo.RequireExplicitScope = false;
		SubFinalizer = new ScopableBindingFinalizer(base.BindInfo, (DiContainer container, Type type) => new GetFromGameObjectGetterComponentProvider(type, gameObjectGetter, matchSingle: false));
		return new ScopeConcreteIdArgConditionCopyNonLazyBinder(base.BindInfo);
	}

	public ScopeConcreteIdArgConditionCopyNonLazyBinder FromComponentOn(Func<InjectContext, GameObject> gameObjectGetter)
	{
		BindingUtil.AssertIsComponent(ConcreteTypes);
		BindingUtil.AssertTypesAreNotAbstract(ConcreteTypes);
		base.BindInfo.RequireExplicitScope = false;
		SubFinalizer = new ScopableBindingFinalizer(base.BindInfo, (DiContainer container, Type type) => new GetFromGameObjectGetterComponentProvider(type, gameObjectGetter, matchSingle: true));
		return new ScopeConcreteIdArgConditionCopyNonLazyBinder(base.BindInfo);
	}

	public ScopeConcreteIdArgConditionCopyNonLazyBinder FromComponentsOnRoot()
	{
		return FromComponentsOn((InjectContext ctx) => BindContainer.Resolve<Context>().gameObject);
	}

	public ScopeConcreteIdArgConditionCopyNonLazyBinder FromComponentOnRoot()
	{
		return FromComponentOn((InjectContext ctx) => BindContainer.Resolve<Context>().gameObject);
	}

	public ScopeConcreteIdArgConditionCopyNonLazyBinder FromNewComponentOn(GameObject gameObject)
	{
		BindingUtil.AssertIsValidGameObject(gameObject);
		BindingUtil.AssertIsComponent(ConcreteTypes);
		BindingUtil.AssertTypesAreNotAbstract(ConcreteTypes);
		base.BindInfo.RequireExplicitScope = true;
		SubFinalizer = new ScopableBindingFinalizer(base.BindInfo, (DiContainer container, Type type) => new AddToExistingGameObjectComponentProvider(gameObject, container, type, base.BindInfo.Arguments, base.BindInfo.ConcreteIdentifier, base.BindInfo.InstantiatedCallback));
		return new ScopeConcreteIdArgConditionCopyNonLazyBinder(base.BindInfo);
	}

	public ScopeConcreteIdArgConditionCopyNonLazyBinder FromNewComponentOn(Func<InjectContext, GameObject> gameObjectGetter)
	{
		BindingUtil.AssertIsComponent(ConcreteTypes);
		BindingUtil.AssertTypesAreNotAbstract(ConcreteTypes);
		base.BindInfo.RequireExplicitScope = true;
		SubFinalizer = new ScopableBindingFinalizer(base.BindInfo, (DiContainer container, Type type) => new AddToExistingGameObjectComponentProviderGetter(gameObjectGetter, container, type, base.BindInfo.Arguments, base.BindInfo.ConcreteIdentifier, base.BindInfo.InstantiatedCallback));
		return new ScopeConcreteIdArgConditionCopyNonLazyBinder(base.BindInfo);
	}

	public ScopeConcreteIdArgConditionCopyNonLazyBinder FromNewComponentSibling()
	{
		BindingUtil.AssertIsComponent(ConcreteTypes);
		BindingUtil.AssertTypesAreNotAbstract(ConcreteTypes);
		base.BindInfo.RequireExplicitScope = true;
		SubFinalizer = new SingleProviderBindingFinalizer(base.BindInfo, (DiContainer container, Type type) => new AddToCurrentGameObjectComponentProvider(container, type, base.BindInfo.Arguments, base.BindInfo.ConcreteIdentifier, base.BindInfo.InstantiatedCallback));
		return new ScopeConcreteIdArgConditionCopyNonLazyBinder(base.BindInfo);
	}

	public ScopeConcreteIdArgConditionCopyNonLazyBinder FromNewComponentOnRoot()
	{
		return FromNewComponentOn((InjectContext ctx) => BindContainer.Resolve<Context>().gameObject);
	}

	public NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder FromNewComponentOnNewGameObject()
	{
		return FromNewComponentOnNewGameObject(new GameObjectCreationParameters());
	}

	internal NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder FromNewComponentOnNewGameObject(GameObjectCreationParameters gameObjectInfo)
	{
		BindingUtil.AssertIsComponent(ConcreteTypes);
		BindingUtil.AssertTypesAreNotAbstract(ConcreteTypes);
		base.BindInfo.RequireExplicitScope = true;
		SubFinalizer = new ScopableBindingFinalizer(base.BindInfo, (DiContainer container, Type type) => new AddToNewGameObjectComponentProvider(container, type, base.BindInfo.Arguments, gameObjectInfo, base.BindInfo.ConcreteIdentifier, base.BindInfo.InstantiatedCallback));
		return new NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder(base.BindInfo, gameObjectInfo);
	}

	public NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder FromNewComponentOnNewPrefabResource(string resourcePath)
	{
		return FromNewComponentOnNewPrefabResource(resourcePath, new GameObjectCreationParameters());
	}

	internal NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder FromNewComponentOnNewPrefabResource(string resourcePath, GameObjectCreationParameters gameObjectInfo)
	{
		BindingUtil.AssertIsValidResourcePath(resourcePath);
		BindingUtil.AssertIsComponent(ConcreteTypes);
		BindingUtil.AssertTypesAreNotAbstract(ConcreteTypes);
		base.BindInfo.RequireExplicitScope = true;
		SubFinalizer = new PrefabResourceBindingFinalizer(base.BindInfo, gameObjectInfo, resourcePath, (Type contractType, IPrefabInstantiator instantiator) => new InstantiateOnPrefabComponentProvider(contractType, instantiator));
		return new NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder(base.BindInfo, gameObjectInfo);
	}

	public NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder FromNewComponentOnNewPrefab(UnityEngine.Object prefab)
	{
		return FromNewComponentOnNewPrefab(prefab, new GameObjectCreationParameters());
	}

	internal NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder FromNewComponentOnNewPrefab(UnityEngine.Object prefab, GameObjectCreationParameters gameObjectInfo)
	{
		BindingUtil.AssertIsValidPrefab(prefab);
		BindingUtil.AssertIsComponent(ConcreteTypes);
		BindingUtil.AssertTypesAreNotAbstract(ConcreteTypes);
		base.BindInfo.RequireExplicitScope = true;
		SubFinalizer = new PrefabBindingFinalizer(base.BindInfo, gameObjectInfo, prefab, (Type contractType, IPrefabInstantiator instantiator) => new InstantiateOnPrefabComponentProvider(contractType, instantiator));
		return new NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder(base.BindInfo, gameObjectInfo);
	}

	public NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder FromComponentInNewPrefab(UnityEngine.Object prefab)
	{
		return FromComponentInNewPrefab(prefab, new GameObjectCreationParameters());
	}

	internal NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder FromComponentInNewPrefab(UnityEngine.Object prefab, GameObjectCreationParameters gameObjectInfo)
	{
		BindingUtil.AssertIsValidPrefab(prefab);
		BindingUtil.AssertIsInterfaceOrComponent(AllParentTypes);
		base.BindInfo.RequireExplicitScope = true;
		SubFinalizer = new PrefabBindingFinalizer(base.BindInfo, gameObjectInfo, prefab, (Type contractType, IPrefabInstantiator instantiator) => new GetFromPrefabComponentProvider(contractType, instantiator, matchSingle: true));
		return new NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder(base.BindInfo, gameObjectInfo);
	}

	public NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder FromComponentsInNewPrefab(UnityEngine.Object prefab)
	{
		return FromComponentsInNewPrefab(prefab, new GameObjectCreationParameters());
	}

	internal NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder FromComponentsInNewPrefab(UnityEngine.Object prefab, GameObjectCreationParameters gameObjectInfo)
	{
		BindingUtil.AssertIsValidPrefab(prefab);
		BindingUtil.AssertIsInterfaceOrComponent(AllParentTypes);
		base.BindInfo.RequireExplicitScope = true;
		SubFinalizer = new PrefabBindingFinalizer(base.BindInfo, gameObjectInfo, prefab, (Type contractType, IPrefabInstantiator instantiator) => new GetFromPrefabComponentProvider(contractType, instantiator, matchSingle: false));
		return new NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder(base.BindInfo, gameObjectInfo);
	}

	public NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder FromComponentInNewPrefabResource(string resourcePath)
	{
		return FromComponentInNewPrefabResource(resourcePath, new GameObjectCreationParameters());
	}

	internal NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder FromComponentInNewPrefabResource(string resourcePath, GameObjectCreationParameters gameObjectInfo)
	{
		BindingUtil.AssertIsValidResourcePath(resourcePath);
		BindingUtil.AssertIsInterfaceOrComponent(AllParentTypes);
		base.BindInfo.RequireExplicitScope = true;
		SubFinalizer = new PrefabResourceBindingFinalizer(base.BindInfo, gameObjectInfo, resourcePath, (Type contractType, IPrefabInstantiator instantiator) => new GetFromPrefabComponentProvider(contractType, instantiator, matchSingle: true));
		return new NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder(base.BindInfo, gameObjectInfo);
	}

	public NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder FromComponentsInNewPrefabResource(string resourcePath)
	{
		return FromComponentsInNewPrefabResource(resourcePath, new GameObjectCreationParameters());
	}

	internal NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder FromComponentsInNewPrefabResource(string resourcePath, GameObjectCreationParameters gameObjectInfo)
	{
		BindingUtil.AssertIsValidResourcePath(resourcePath);
		BindingUtil.AssertIsInterfaceOrComponent(AllParentTypes);
		base.BindInfo.RequireExplicitScope = true;
		SubFinalizer = new PrefabResourceBindingFinalizer(base.BindInfo, gameObjectInfo, resourcePath, (Type contractType, IPrefabInstantiator instantiator) => new GetFromPrefabComponentProvider(contractType, instantiator, matchSingle: false));
		return new NameTransformScopeConcreteIdArgConditionCopyNonLazyBinder(base.BindInfo, gameObjectInfo);
	}

	public ScopeConcreteIdArgConditionCopyNonLazyBinder FromNewScriptableObjectResource(string resourcePath)
	{
		return FromScriptableObjectResourceInternal(resourcePath, createNew: true);
	}

	public ScopeConcreteIdArgConditionCopyNonLazyBinder FromScriptableObjectResource(string resourcePath)
	{
		return FromScriptableObjectResourceInternal(resourcePath, createNew: false);
	}

	private ScopeConcreteIdArgConditionCopyNonLazyBinder FromScriptableObjectResourceInternal(string resourcePath, bool createNew)
	{
		BindingUtil.AssertIsValidResourcePath(resourcePath);
		BindingUtil.AssertIsInterfaceOrScriptableObject(AllParentTypes);
		base.BindInfo.RequireExplicitScope = true;
		SubFinalizer = new ScopableBindingFinalizer(base.BindInfo, (DiContainer container, Type type) => new ScriptableObjectResourceProvider(resourcePath, type, container, base.BindInfo.Arguments, createNew, base.BindInfo.ConcreteIdentifier, base.BindInfo.InstantiatedCallback));
		return new ScopeConcreteIdArgConditionCopyNonLazyBinder(base.BindInfo);
	}

	public ScopeConcreteIdArgConditionCopyNonLazyBinder FromResource(string resourcePath)
	{
		BindingUtil.AssertDerivesFromUnityObject(ConcreteTypes);
		base.BindInfo.RequireExplicitScope = false;
		SubFinalizer = new ScopableBindingFinalizer(base.BindInfo, (DiContainer _, Type type) => new ResourceProvider(resourcePath, type, matchSingle: true));
		return new ScopeConcreteIdArgConditionCopyNonLazyBinder(base.BindInfo);
	}

	public ScopeConcreteIdArgConditionCopyNonLazyBinder FromResources(string resourcePath)
	{
		BindingUtil.AssertDerivesFromUnityObject(ConcreteTypes);
		base.BindInfo.RequireExplicitScope = false;
		SubFinalizer = new ScopableBindingFinalizer(base.BindInfo, (DiContainer _, Type type) => new ResourceProvider(resourcePath, type, matchSingle: false));
		return new ScopeConcreteIdArgConditionCopyNonLazyBinder(base.BindInfo);
	}

	public ScopeConcreteIdArgConditionCopyNonLazyBinder FromMethodUntyped(Func<InjectContext, object> method)
	{
		base.BindInfo.RequireExplicitScope = false;
		base.BindInfo.MarkAsCreationBinding = false;
		SubFinalizer = new ScopableBindingFinalizer(base.BindInfo, (DiContainer container, Type type) => new MethodProviderUntyped(method, container));
		return this;
	}

	public ScopeConcreteIdArgConditionCopyNonLazyBinder FromMethodMultipleUntyped(Func<InjectContext, IEnumerable<object>> method)
	{
		base.BindInfo.RequireExplicitScope = false;
		base.BindInfo.MarkAsCreationBinding = false;
		SubFinalizer = new ScopableBindingFinalizer(base.BindInfo, (DiContainer container, Type type) => new MethodMultipleProviderUntyped(method, container));
		return this;
	}

	protected ScopeConcreteIdArgConditionCopyNonLazyBinder FromMethodBase<TConcrete>(Func<InjectContext, TConcrete> method)
	{
		BindingUtil.AssertIsDerivedFromTypes(typeof(TConcrete), AllParentTypes);
		base.BindInfo.RequireExplicitScope = false;
		base.BindInfo.MarkAsCreationBinding = false;
		SubFinalizer = new ScopableBindingFinalizer(base.BindInfo, (DiContainer container, Type type) => new MethodProvider<TConcrete>(method, container));
		return this;
	}

	protected ScopeConcreteIdArgConditionCopyNonLazyBinder FromMethodMultipleBase<TConcrete>(Func<InjectContext, IEnumerable<TConcrete>> method)
	{
		BindingUtil.AssertIsDerivedFromTypes(typeof(TConcrete), AllParentTypes);
		base.BindInfo.RequireExplicitScope = false;
		base.BindInfo.MarkAsCreationBinding = false;
		SubFinalizer = new ScopableBindingFinalizer(base.BindInfo, (DiContainer container, Type type) => new MethodProviderMultiple<TConcrete>(method, container));
		return this;
	}

	protected ScopeConcreteIdArgConditionCopyNonLazyBinder FromResolveGetterBase<TObj, TResult>(object identifier, Func<TObj, TResult> method, InjectSources source, bool matchMultiple)
	{
		BindingUtil.AssertIsDerivedFromTypes(typeof(TResult), AllParentTypes);
		base.BindInfo.RequireExplicitScope = false;
		base.BindInfo.MarkAsCreationBinding = false;
		SubFinalizer = new ScopableBindingFinalizer(base.BindInfo, (DiContainer container, Type type) => new GetterProvider<TObj, TResult>(identifier, method, container, source, matchMultiple));
		return new ScopeConcreteIdArgConditionCopyNonLazyBinder(base.BindInfo);
	}

	protected ScopeConcreteIdArgConditionCopyNonLazyBinder FromInstanceBase(object instance)
	{
		BindingUtil.AssertInstanceDerivesFromOrEqual(instance, AllParentTypes);
		base.BindInfo.RequireExplicitScope = false;
		base.BindInfo.MarkAsCreationBinding = false;
		SubFinalizer = new ScopableBindingFinalizer(base.BindInfo, (DiContainer container, Type type) => new InstanceProvider(type, instance, container));
		return new ScopeConcreteIdArgConditionCopyNonLazyBinder(base.BindInfo);
	}
}
