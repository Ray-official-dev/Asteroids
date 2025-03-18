using UnityEngine;

namespace Game.View
{
    [CreateAssetMenu(menuName = Constans.CONFIGS_PATH + "New Asteroid")]
    public class AsteroidConfig : ScriptableObject
    {
        public int NextSpawnAmount => _nextSpawnAmount;
        public float SpawnRadius => _spawnRadius;
        public int MaxHealthPoints => _maxHealthPoints;
        public float Size => _size;
        public AsteroidConfig NextConfig => _nextConfig; 

        [SerializeField] private int _nextSpawnAmount = 5;
        [SerializeField] private float _spawnRadius = 1.5f;
        [SerializeField] protected int _maxHealthPoints = 5;
        [SerializeField] private float _size = 1;
        [SerializeField] private AsteroidConfig _nextConfig;
    }
}