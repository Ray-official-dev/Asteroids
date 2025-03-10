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
            scenes.Load(Scenes.GAMEPLAY, () => UnityEngine.Debug.Log("Gameplay entered, " + args.Level));
        }

        public class Arguments : IArguments
        {
            public readonly int Level;

            public Arguments(int level)
            {
                Level = level;
            }
        }
    }
}