using System;
using Game.View;
using MPA.Utilits;
using Object = UnityEngine.Object;
using Debug = UnityEngine.Debug;
using UnityEngine;

namespace Game.GameplayRules
{
    public class Gameplay //можна використати стейт машину для зменшення осей змін, однак гра мала та працюю над нею я один, тому це буде не раціональною витратою часу
    {
        public event Action MainMenuEnterRequested;

        public Lifecycle Lifecycle => _lifecycle;
        public AsteroidsContainer AsteroidsContainer => _asteroidsContainer;
        public AsteroidsSpawner AsteroidsSpawner => _asteroidsSpawner;
        public CountdownTimer RoundTimer => _roundTimer;

        private LevelConfig _currentLevel => _config.Levels[_levelIndex];

        private IInputShip _shipInput;
        private CountdownTimer _roundTimer;

        private AsteroidsContainer _asteroidsContainer;
        private AsteroidsSpawner _asteroidsSpawner;
        private View.GameplayUI _userInterface;
        private GameplayConfig _config;
        private Lifecycle _lifecycle;
        private Ship _ship;

        private int _levelIndex;

        public void Run(int levelIndex)
        {
            SceneContext.Register(this);

            _lifecycle = new Lifecycle();
            _roundTimer = new CountdownTimer();
            _levelIndex = levelIndex;
            _roundTimer.TimerEnded += OnTimeEnded;

            InstallConfigs();

            _asteroidsSpawner = new AsteroidsSpawner();
            _asteroidsContainer = new AsteroidsContainer(_asteroidsSpawner);
            _asteroidsContainer.Empty += OnAsteroidsDestroyed;

            _lifecycle.Add(_roundTimer);
            _lifecycle.Run();

            CreateLevel();

            _roundTimer.Start(_currentLevel.Duration);
        }

        public void Pause()
        {
            _lifecycle.Pause();
            Time.timeScale = _config.PausedTimeScale;
        }

        public void Resume()
        {
            _lifecycle?.Unpause();
            Time.timeScale = 1;
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
            _lifecycle.Add(_userInterface);
        }

        private void TryCreateShip()
        {
            if (_ship is not null)
                _ship.Delete();

            _ship = Object.Instantiate(_config.Ship);
            _lifecycle.Add(_ship);
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