using System;
using UnityEngine;

namespace Zenject;

public class GameObjectCreationParameters
{
	public static readonly GameObjectCreationParameters Default = new GameObjectCreationParameters();

	public string Name { get; set; }

	public string GroupName { get; set; }

	public Transform ParentTransform { get; set; }

	public Func<InjectContext, Transform> ParentTransformGetter { get; set; }

	public Vector3? Position { get; set; }

	public Quaternion? Rotation { get; set; }

	public override int GetHashCode()
	{
		return (((((17 * 29 + ((Name != null) ? Name.GetHashCode() : 0)) * 29 + ((GroupName != null) ? GroupName.GetHashCode() : 0)) * 29 + ((!(ParentTransform == null)) ? ParentTransform.GetHashCode() : 0)) * 29 + ((ParentTransformGetter != null) ? ParentTransformGetter.GetHashCode() : 0)) * 29 + (Position.HasValue ? Position.Value.GetHashCode() : 0)) * 29 + (Rotation.HasValue ? Rotation.Value.GetHashCode() : 0);
	}

	public override bool Equals(object other)
	{
		if (other is GameObjectCreationParameters)
		{
			return (GameObjectCreationParameters)other == this;
		}
		return false;
	}

	public bool Equals(GameObjectCreationParameters that)
	{
		return this == that;
	}

	public static bool operator ==(GameObjectCreationParameters left, GameObjectCreationParameters right)
	{
		if (object.Equals(left.Name, right.Name))
		{
			return object.Equals(left.GroupName, right.GroupName);
		}
		return false;
	}

	public static bool operator !=(GameObjectCreationParameters left, GameObjectCreationParameters right)
	{
		return !left.Equals(right);
	}
}
