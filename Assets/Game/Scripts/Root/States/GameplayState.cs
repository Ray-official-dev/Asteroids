using Game.GameplayRules;
using MPA.Utilits;

namespace Game.Root
{
    public class GameplayState : State
    {
        public GameplayState(StateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter(IArguments enteredArgs)
        {
            var scenes = ProjectContext.Get<ScenesLoader>();
            var args = enteredArgs as Arguments;

            scenes.Load(Scenes.GAMEPLAY, () =>
            {
                Gameplay gameplay = new Gameplay();
                gameplay.Start(args.LevelIndex);
            });
        }

        public class Arguments : IArguments
        {
            public int LevelIndex { get; }

            public Arguments(int level)
            {
                LevelIndex = level;
            }
        }
    }
}