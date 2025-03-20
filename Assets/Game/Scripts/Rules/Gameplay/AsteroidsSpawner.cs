using System;
using Game.View;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.GameplayRules
{
    public class AsteroidsSpawner
    {
        public event Action<Asteroid> Spawned;
        private AsteroidsSpawnerConfig _config;

        public AsteroidsSpawner(AsteroidsSpawnerConfig config)
        {
            _config = config;
        }

        public void Spawn(LevelConfig level)
        {
            for (int i = 0; i < level.AsteroidsAmount; i++)
            {
                float minDistance = level.MinAsteroidsDistanceForShip; // Мінімальна відстань від корабля
                float maxDistance = level.MaxAsteroidsDistanceForShip; // Максимальна відстань (радіус зони спавну)

                float distance = UnityEngine.Random.Range(minDistance, maxDistance); // Випадкова відстань у заданому діапазоні
                Vector2 randomDirection = UnityEngine.Random.insideUnitCircle.normalized; // Випадковий напрямок

                Vector3 randomPosition = new Vector3(randomDirection.x, randomDirection.y, 0) * distance; // Генерація координат у 2D

                Quaternion randomRotation = Quaternion.identity; // Орієнтація (можна додати обертання, якщо потрібно)

                Asteroid asteroid = Object.Instantiate(_config.Prefab, randomPosition, randomRotation);
                asteroid.Construct(_config.Configs[0]);
                Spawned?.Invoke(asteroid);
            }
        }
    }
}