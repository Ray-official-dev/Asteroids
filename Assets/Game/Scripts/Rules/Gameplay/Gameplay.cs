using Game.View;
using MPA.Utilits;
using UnityEngine;

namespace Game.GameplayRules
{
    public class Gameplay
    {
        private IInputShip _shipInput;

        private AsteroidsContainer _asteroidsContainer;
        private AsteroidsSpawner _asteroidsSpawner;
        private GameplayConfig _config;
        private Ship _ship;

        private int _levelIndex;

        public void Start(int levelIndex)
        {
            _levelIndex = levelIndex;

            InstallConfigs();

            _asteroidsSpawner = new AsteroidsSpawner(Context.Get<AsteroidsSpawnerConfig>());
            _asteroidsContainer = new AsteroidsContainer(_asteroidsSpawner);
            _asteroidsContainer.Empty += OnAsteroidsDestroyed;

            CreateLevel();
        }

        private void InstallConfigs()
        {
            var configs = ProjectContext.Get<SOConfigsProvider>();
            _config = ProjectContext.Get<GameplayConfig>();

            SceneContext.Register(configs.Get<AsteroidsSpawnerConfig>());
        }

        private void CreateAsteroids()
        {
            _asteroidsSpawner.Spawn(_config.Levels[_levelIndex]);
        }

        private void OnAsteroidsDestroyed()
        {
            NextLevel();
        }

        private void NextLevel()
        {
            _levelIndex++;
            CreateLevel();
        }

        private void CreateLevel()
        {
            CreateAsteroids();
            TryCreateInput();
            TryCreateShip();
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