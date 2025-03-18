using UnityEngine;
using Game.View;

namespace Game.Rules
{
    [CreateAssetMenu(menuName = Constans.CONFIGS_PATH + "Asteroids Spawner Config")]
    public class AsteroidsSpawnerConfig : ScriptableObject
    {
        public Asteroid Prefab => _prefab;
        public AsteroidConfig[] Configs => _configs;
       
        [SerializeField] private Asteroid _prefab;
        [SerializeField] private AsteroidConfig[] _configs;
    }
}