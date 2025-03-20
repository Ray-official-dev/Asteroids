using Game.MainMenuRules;
using MPA.Utilits;

namespace Game.Root
{
    public class MainMenuState : State
    {
        private ScenesLoader _scenes;

        public MainMenuState(StateMachine stateMachine) : base(stateMachine)
        {

        }

        public override void Enter()
        {
            _scenes = ProjectContext.Get<ScenesLoader>();
            ApplySettings();

            _scenes.TryLoad(Scenes.MAINMENU, () =>
            {
                var menu = new MainMenu();
                menu.EnterGameplayRequested += OnEnterGameplayRequested;
                menu.Create();
            });
        }

        private void ApplySettings()
        {
            var appSettings = ProjectContext.Get<AppSettingsConfig>();
            appSettings.Apply();
        }

        private void OnEnterGameplayRequested(int level)
        {
            _stateMachine.EnterIn<GameplayState>(new GameplayState.Arguments(level));
        }
    }
}