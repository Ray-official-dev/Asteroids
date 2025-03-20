using System;
using System.Collections.Generic;
using Game.View;

namespace Game.GameplayRules
{
    public class AsteroidsContainer
    {
        public event Action Empty;
        private List<Asteroid> _asteroids;

        public AsteroidsContainer(AsteroidsSpawner spawner)
        {
            _asteroids = new List<Asteroid>();
            spawner.Spawned += OnSpawned;
        }

        private void OnSpawned(Asteroid asteroid)
        {
            _asteroids.Add(asteroid);
            asteroid.Destroying += OnDestroying;
            asteroid.AsteroidsSpawned += OnSpawned;
        }

        private void OnDestroying(Asteroid asteroid)
        {
            _asteroids.Remove(asteroid);

            if (_asteroids.Count == 0)
                Empty?.Invoke();
        }

        public void Clear()
        {
            foreach (var asteroid in _asteroids)
                asteroid.Destroy();

            Empty?.Invoke();
        }
    }
}