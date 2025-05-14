using UnityEngine;
using Game.View;

namespace Game.GameplayRules
{
    [CreateAssetMenu(menuName = Constans.CONFIGS_PATH + "Asteroid/SpawnerRulesConfig")]
    public class AsteroidsSpawnerConfig : ScriptableObject
    {
        public Asteroid Prefab => _prefab;
        public AsteroidConfig[] Configs => _configs;
       
        [SerializeField] private Asteroid _prefab;
        [SerializeField] private AsteroidConfig[] _configs;
    }
}