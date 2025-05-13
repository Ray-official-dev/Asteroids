using System;
using System.Collections.Generic;
using Game.View;
using MPA.Utilits;

namespace Game.GameplayRules
{
    public class AsteroidsContainer
    {
        public event Action Empty;
        public event Action<int> AsteroidsAmountChanged;

        private List<Asteroid> _asteroids;

        private Storage _storage;

        public AsteroidsContainer(AsteroidsSpawner spawner)
        {
            _storage = Context.Get<Storage>();
            _asteroids = new List<Asteroid>();
            spawner.Spawned += OnSpawned;
        }
   
        private void OnSpawned(Asteroid asteroid)
        {
            _asteroids.Add(asteroid);
            AsteroidsAmountChanged?.Invoke(_asteroids.Count);
            asteroid.Destroying += OnDestroying;
            asteroid.AsteroidsSpawned += OnSpawned;
        }

        private void OnDestroying(Asteroid asteroid)
        {
            _storage.AddDestroyedAsteroid();
            _asteroids.Remove(asteroid);
            AsteroidsAmountChanged?.Invoke(_asteroids.Count);

            if (_asteroids.Count == 0)
                Empty?.Invoke();
        }

        public void Clear()
        {
            foreach (var asteroid in _asteroids)
                asteroid.Destroy();

            AsteroidsAmountChanged?.Invoke(_asteroids.Count);
            Empty?.Invoke();
        }
    }
}