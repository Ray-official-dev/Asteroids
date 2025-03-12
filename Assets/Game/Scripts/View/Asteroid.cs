using UnityEngine;

namespace Game.View
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Asteroid : MonoBehaviour
    {
        [SerializeField] private AsteroidConfig _config;
        private int _healthPoints;

        private void Start()
        {
            transform.localScale = Vector3.one * _config.Size;
            _healthPoints = _config.MaxHealthPoints;
        }

        public void Construct(AsteroidConfig config)
        {
            _config = config;
        }

        public void TakeDamage(int damage)
        {
            _healthPoints -= damage;

            if (_healthPoints <= 0)
                Destroy();
        }

        private void Destroy()
        {
            if (_config.NextSpawnAmount > 0)
                SpawnAsteroids();

            Destroy(gameObject);
        }

        protected virtual void SpawnAsteroids()
        {
            for (int i = 0; i < _config.NextSpawnAmount; i++)
            {
                Vector3 spawnPosition = GetSpawnPosition();
                Asteroid newAsteroid = Instantiate(this, spawnPosition, Quaternion.identity);
                newAsteroid.Construct(_config.NextConfig);
            }
        }

        private Vector3 GetSpawnPosition()
        {
            Vector3 spawnPosition = transform.position + (UnityEngine.Random.insideUnitSphere * _config.SpawnRadius);
            spawnPosition.z = 0;
            return spawnPosition;
        }
    }
}