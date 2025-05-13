using System;
using Game.View;
using MPA.Utilits;
using Object = UnityEngine.Object;
using Debug = UnityEngine.Debug;
using UnityEngine;
using Game.Effects;

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
        private GameplayUI _userInterface;
        private GameplayConfig _config;
        private Lifecycle _lifecycle;
        private Ship _ship;
        private Storage _storage;

        private int _levelIndex;

        public void Run(int levelIndex)
        {
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
            _ship.Destroying += OnShipDestroying;
        }

        private void OnShipDestroying()
        {
            MainMenuEnterRequested?.Invoke();
        }

        private void TryCreateInput()
        {
            if (_shipInput is not null)
                return;

            _shipInput = Object.Instantiate(_config.MobileInput);

            SceneContext.Register(_shipInput);
        }

        public void ReturnInMainMenu()
        {
            MainMenuEnterRequested?.Invoke();
        }
    }
}