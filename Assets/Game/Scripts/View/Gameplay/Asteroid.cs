using System;
using Game.GameplayRules;
using MPA.Utilits;
using UnityEngine;

namespace Game.View
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : MPA.View
    {
        public event Action<Asteroid> AsteroidsSpawned;
        public event Action<Asteroid> Destroying;

        [SerializeField] private AsteroidConfig _config;
        private int _healthPoints;
        private Lifecycle _lifecycle;
        private Rigidbody2D _body;
        private float _speed;

        public void Construct(AsteroidConfig config)
        {
            _config = config;
            _lifecycle = Context.Get<Gameplay>().Lifecycle;
            _body = GetComponent<Rigidbody2D>();
        }

        public override void Begin()
        {
            transform.localScale = Vector3.one * _config.Size;
            _healthPoints = _config.MaxHealthPoints;
        }

        public void TakeDamage(int damage)
        {
            _healthPoints -= damage;

            if (_healthPoints <= 0)
            {
                if (_config.NextSpawnAmount > 0)
                    SpawnAsteroids();

                Destroy();
            }
        }

        public void Destroy()
        {
            Destroying?.Invoke(this);
            Destroy(gameObject);
        }

        private void SpawnAsteroids()
        {
            for (int i = 0; i < _config.NextSpawnAmount; i++)
            {
                Vector2 randomDirection = UnityEngine.Random.insideUnitCircle.normalized;

                Vector3 spawnPosition = GetSpawnPosition();
                Asteroid newAsteroid = Instantiate(this, spawnPosition, Quaternion.identity);
                newAsteroid.Construct(_config.NextConfig);
                newAsteroid.SetMove(randomDirection, _speed);
                AsteroidsSpawned?.Invoke(newAsteroid);
                _lifecycle.Add(newAsteroid);
            }
        }

        private Vector3 GetSpawnPosition()
        {
            Vector3 spawnPosition = transform.position + (UnityEngine.Random.insideUnitSphere * _config.SpawnRadius);
            spawnPosition.z = 0;
            return spawnPosition;
        }

        public void SetMove(Vector2 direction, float speed)
        {
            _speed = speed;
            _body.linearVelocity = direction.normalized * speed;
        }
    }
}