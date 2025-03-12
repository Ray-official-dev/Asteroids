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

                CreateInput(config);

                GameObject.Instantiate(config.Ship);
            });
        }

        public void CreateInput(GameplayConfig config)
        {
            IShipInput input;

            if (Application.isEditor)
                input = GameObject.Instantiate(config.EditorInput);
            else
                input = GameObject.Instantiate(config.MobileInput);

            SceneContext.Register(input);
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