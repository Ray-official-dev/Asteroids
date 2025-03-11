using MPA.Utilits;
using UnityEngine;
using Game.Rules;

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
                var configs = ProjectContext.Get<SOConfigsProvider>();
                var config = configs.Get<GameplayConfig>();

                var input = GameObject.Instantiate(config.Input);
                SceneContext.Register<IInputControl>(input);

                var ship = GameObject.Instantiate(config.Ship);
            });
        }

        public class Arguments : IArguments
        {
            public int Level { get; }

            public Arguments(int level)
            {
                Level = level;
            }
        }
    }
}