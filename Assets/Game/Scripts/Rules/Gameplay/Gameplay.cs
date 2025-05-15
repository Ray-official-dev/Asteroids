using System;
using Game.View;
using MPA.Utilits;
using Object = UnityEngine.Object;
using Debug = UnityEngine.Debug;
using UnityEngine;
using Game.Input;

namespace Game.GameplayRules
{
    public class Gameplay //можна використати стейт машину для зменшення осей змін, однак гра мала та працюю над нею я один, тому це буде не раціональною витратою часу
    {
        public event Action MainMenuEnterRequested;
        public event Action<int> LevelChanged;

        public int CurrentLevel => _levelIndex + 1;

        public Lifecycle Lifecycle => _lifecycle;
        public AsteroidsContainer AsteroidsContainer => _asteroidsContainer;
        public AsteroidsSpawner AsteroidsSpawner => _asteroidsSpawner;
        public CountdownTimer RoundTimer => _roundTimer;

        private LevelConfig _currentLevel => _config.Levels[_levelIndex];

        private IInputShip _shipInput;
        private CountdownTimer _roundTimer;

        private AsteroidsContainer _asteroidsContainer;
        private AsteroidsSpawner _asteroidsSpawner;
        private GameplayUI _userInterface;
        private GameplayConfig _config;
        private Lifecycle _lifecycle;
        private Ship _ship;
        private Storage _storage;

        private ResourceProvider _resources;

        private int _levelIndex;

        public void Run(int levelIndex)
        {
            _resources = Context.Get<ResourceProvider>();

            SceneContext.Register(this);

            var configsInstaller = new ConfigsInstaller();
            configsInstaller.Install();

            _storage = Context.Get<Storage>();
            _lifecycle = new Lifecycle();
            _roundTimer = new CountdownTimer();
            _levelIndex = levelIndex;
            _roundTimer.TimerEnded += OnTimeEnded;

            _config = ProjectContext.Get<GameplayConfig>();

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
            _storage.SaveLastLevel(_levelIndex);
            _roundTimer.Start(_currentLevel.Duration);
            CreateLevel();
            LevelChanged?.Invoke(CurrentLevel);
        }

        private void CreateLevel()
        {
            TryCreateUI();
            CreateAsteroids();
            TryCreateInput();
            CreateShip();
        }

        private void TryCreateUI()
        {
            if (_userInterface is not null)
                return;

            _userInterface = Object.Instantiate(_resources.GetPrefab<GameplayUI>());
            _lifecycle.Add(_userInterface);
        }

        private void CreateShip()
        {
            if (_ship is not null)
                Object.Destroy(_ship.gameObject);

            _ship = Object.Instantiate(_resources.GetPrefab<Ship>());
            _lifecycle.Add(_ship);
            _ship.Exploded += OnShipExploded;
        }

        private void OnShipExploded(Ship ship)
        {
            var timer = new CountdownTimer();
            timer.Start(_config.GameOverDelay);
            timer.TimerEnded += ReturnInMainMenu;

            _lifecycle.Add(timer);
        }

        private void TryCreateInput()
        {
            if (_shipInput is not null)
                return;

            _shipInput = Object.Instantiate(_resources.GetPrefab<MobileShipInput>());

            SceneContext.Register(_shipInput);
        }

        public void ReturnInMainMenu()
        {
            MainMenuEnterRequested?.Invoke();
        }
    }
}