using System;
using Game.View;
using MPA.Utilits;
using Object = UnityEngine.Object;
using Debug = UnityEngine.Debug;

namespace Game.GameplayRules
{
    public class Gameplay //можна використати стейт машину для зменшення осей змін, однак гра мала та працюю над нею я один, тому це буде не раціональною витратою часу
    {
        public event Action MainMenuEnterRequested;
        public float CurrentRoundTime => _roundTimer.CurrentTime;
        private LevelConfig _currentLevel => _config.Levels[_levelIndex];

        private IInputShip _shipInput;
        private CountdownTimer _roundTimer;

        private AsteroidsContainer _asteroidsContainer;
        private AsteroidsSpawner _asteroidsSpawner;
        private View.Gameplay _userInterface;
        private GameplayConfig _config;
        private Lifecycle _userInterfaceLifecycle;
        private Ship _ship;

        private int _levelIndex;

        public void Run(int levelIndex)
        {
            _userInterfaceLifecycle = new Lifecycle();
            _levelIndex = levelIndex;
            _roundTimer = new CountdownTimer();
            _roundTimer.TimerEnded += OnTimeEnded;

            InstallConfigs();

            _asteroidsSpawner = new AsteroidsSpawner(Context.Get<AsteroidsSpawnerConfig>());
            _asteroidsContainer = new AsteroidsContainer(_asteroidsSpawner);
            _asteroidsContainer.Empty += OnAsteroidsDestroyed;

            InstallDependecies();

            _userInterfaceLifecycle.Add(_roundTimer);
            _userInterfaceLifecycle.Run();
            CreateLevel();

            _roundTimer.Start(_currentLevel.Duration);
        }

        private void OnTimeEnded()
        {
            MainMenuEnterRequested?.Invoke();
            Debug.Log("Time ended");
        }

        private void InstallConfigs()
        {
            var configs = ProjectContext.Get<SOConfigsProvider>();
            _config = ProjectContext.Get<GameplayConfig>();

            SceneContext.Register(configs.Get<AsteroidsSpawnerConfig>());
        }

        private void InstallDependecies()
        {
            SceneContext.Register<IReadOnlyAsteroidsContainer>(_asteroidsContainer);
            SceneContext.Register<IReadOnlyAsteroidsSpawner>(_asteroidsSpawner);
            SceneContext.Register<IReadOnlyCountdownTimer>(_roundTimer);
        }

        private void CreateAsteroids()
        {
            _asteroidsSpawner.Spawn(_currentLevel);
        }

        private void OnAsteroidsDestroyed()
        {
            NextLevel();
        }

        private void NextLevel()
        {
            _levelIndex++;
            _roundTimer.Start(_currentLevel.Duration);
            CreateLevel();
        }

        private void CreateLevel()
        {
            TryCreateUI();
            CreateAsteroids();
            TryCreateInput();
            TryCreateShip();
        }

        private void TryCreateUI()
        {
            if (_userInterface is not null)
                return;

            _userInterface = Object.Instantiate(_config.UserInterface);
            _userInterfaceLifecycle.Add(_userInterface);
        }

        private void TryCreateShip()
        {
            if (_ship is not null)
                _ship.Delete();

            _ship = Object.Instantiate(_config.Ship);
        }

        private void TryCreateInput()
        {
            if (_shipInput is not null)
                return;

            if (GameSettingsWindow.IsEditorInput)
                _shipInput = Object.Instantiate(_config.EditorInput);
            else
                _shipInput = Object.Instantiate(_config.MobileInput);

            SceneContext.Register(_shipInput);
        }
    }
}