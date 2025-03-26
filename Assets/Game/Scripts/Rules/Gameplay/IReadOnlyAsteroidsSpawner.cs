using System;

namespace Game.GameplayRules
{
    public interface IReadOnlyAsteroidsSpawner
    {
        event Action<int> AmountSpawned;
    }
}