using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ModestTree;

namespace Zenject;

public class InjectContext : IDisposable
{
	public static readonly StaticMemoryPool<DiContainer, Type, InjectContext> Pool = new StaticMemoryPool<DiContainer, Type, InjectContext>(OnSpawned, OnDespawned);

	private readonly BindingId _bindingId = new BindingId();

	private Type _objectType;

	private InjectContext _parentContext;

	private object _objectInstance;

	private string _memberName;

	private bool _optional;

	private InjectSources _sourceType;

	private object _fallBackValue;

	private object _concreteIdentifier;

	private DiContainer _container;

	public BindingId BindingId => _bindingId;

	public Type ObjectType
	{
		get
		{
			return _objectType;
		}
		set
		{
			_objectType = value;
		}
	}

	public InjectContext ParentContext
	{
		get
		{
			return _parentContext;
		}
		set
		{
			_parentContext = value;
		}
	}

	public object ObjectInstance
	{
		get
		{
			return _objectInstance;
		}
		set
		{
			_objectInstance = value;
		}
	}

	public object Identifier
	{
		get
		{
			return _bindingId.Identifier;
		}
		set
		{
			_bindingId.Identifier = value;
		}
	}

	public string MemberName
	{
		get
		{
			return _memberName;
		}
		set
		{
			_memberName = value;
		}
	}

	public Type MemberType
	{
		get
		{
			return _bindingId.Type;
		}
		set
		{
			_bindingId.Type = value;
		}
	}

	public bool Optional
	{
		get
		{
			return _optional;
		}
		set
		{
			_optional = value;
		}
	}

	public InjectSources SourceType
	{
		get
		{
			return _sourceType;
		}
		set
		{
			_sourceType = value;
		}
	}

	public object ConcreteIdentifier
	{
		get
		{
			return _concreteIdentifier;
		}
		set
		{
			_concreteIdentifier = value;
		}
	}

	public object FallBackValue
	{
		get
		{
			return _fallBackValue;
		}
		set
		{
			_fallBackValue = value;
		}
	}

	public DiContainer Container
	{
		get
		{
			return _container;
		}
		set
		{
			_container = value;
		}
	}

	public IEnumerable<InjectContext> ParentContexts
	{
		get
		{
			if (ParentContext == null)
			{
				yield break;
			}
			yield return ParentContext;
			foreach (InjectContext parentContext in ParentContext.ParentContexts)
			{
				yield return parentContext;
			}
		}
	}

	public IEnumerable<InjectContext> ParentContextsAndSelf
	{
		get
		{
			yield return this;
			foreach (InjectContext parentContext in ParentContexts)
			{
				yield return parentContext;
			}
		}
	}

	public IEnumerable<Type> AllObjectTypes
	{
		get
		{
			foreach (InjectContext item in ParentContextsAndSelf)
			{
				if (item.ObjectType != null)
				{
					yield return item.ObjectType;
				}
			}
		}
	}

	public InjectContext()
	{
		SetDefaults();
	}

	private static void OnSpawned(DiContainer container, Type memberType, InjectContext that)
	{
		Assert.IsNull(that._container);
		that._container = container;
		that._bindingId.Type = memberType;
	}

	private static void OnDespawned(InjectContext that)
	{
		that.SetDefaults();
	}

	public InjectContext(DiContainer container, Type memberType)
		: this()
	{
		Container = container;
		MemberType = memberType;
	}

	public InjectContext(DiContainer container, Type memberType, object identifier)
		: this(container, memberType)
	{
		Identifier = identifier;
	}

	public InjectContext(DiContainer container, Type memberType, object identifier, bool optional)
		: this(container, memberType, identifier)
	{
		Optional = optional;
	}

	public void Dispose()
	{
		Pool.Despawn(this);
	}

	private void SetDefaults()
	{
		_objectType = null;
		_parentContext = null;
		_objectInstance = null;
		_memberName = "";
		_bindingId.Identifier = null;
		_bindingId.Type = null;
		_optional = false;
		_sourceType = InjectSources.Any;
		_fallBackValue = null;
		_container = null;
	}

	public InjectContext CreateSubContext(Type memberType)
	{
		return CreateSubContext(memberType, null);
	}

	public InjectContext CreateSubContext(Type memberType, object identifier)
	{
		return new InjectContext
		{
			ParentContext = this,
			Identifier = identifier,
			MemberType = memberType,
			ConcreteIdentifier = null,
			MemberName = "",
			FallBackValue = null,
			ObjectType = ObjectType,
			ObjectInstance = ObjectInstance,
			Optional = Optional,
			SourceType = SourceType,
			Container = Container
		};
	}

	public InjectContext Clone()
	{
		return new InjectContext
		{
			ObjectType = ObjectType,
			ParentContext = ParentContext,
			ConcreteIdentifier = ConcreteIdentifier,
			ObjectInstance = ObjectInstance,
			Identifier = Identifier,
			MemberType = MemberType,
			MemberName = MemberName,
			Optional = Optional,
			SourceType = SourceType,
			FallBackValue = FallBackValue,
			Container = Container
		};
	}

	public string GetObjectGraphString()
	{
		StringBuilder stringBuilder = new StringBuilder();
		foreach (InjectContext item in ParentContextsAndSelf.Reverse())
		{
			if (!(item.ObjectType == null))
			{
				stringBuilder.AppendLine(item.ObjectType.PrettyName());
			}
		}
		return stringBuilder.ToString();
	}
}
