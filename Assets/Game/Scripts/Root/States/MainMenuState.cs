using MPA.Utilits;

namespace Game.Root
{
    public class MainMenuState : State
    {
        public MainMenuState(StateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void Enter()
        {
            var scenes = ProjectContext.Get<ScenesLoader>();

            var appSettings = ProjectContext.Get<AppSettingsConfig>();
            appSettings.Apply();

            IArguments args = new GameplayState.Arguments(0);
            scenes.TryLoad(Scenes.MAINMENU, () => _stateMachine.EnterIn<GameplayState>(args));
        }
    }
}