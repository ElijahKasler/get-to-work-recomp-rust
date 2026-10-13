using UnityEngine;

namespace Isto.Core.Configuration;

public interface IPlayerStartPointProvider
{
	Transform PlayerSpawnPoint { get; }
}
