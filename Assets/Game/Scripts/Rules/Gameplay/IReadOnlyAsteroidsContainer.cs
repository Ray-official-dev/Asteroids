using System;

namespace Game.GameplayRules
{
    public interface IReadOnlyAsteroidsContainer
    {
        event Action<int> AsteroidsAmountChanged;
    }
}