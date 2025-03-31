using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = Constans.CONFIGS_PATH + "Level")]
    public class LevelConfig : ScriptableObject
    {
        public float MinAsteroidsDistanceForShip => _minDisanceForShip;
        public float MaxAsteroidsDistanceForShip => _maxDistanceForShip;
        public float MinAsteroidsSpeed => _minAsteroidsSpeed;
        public float MaxAsteroidsSpeed => _maxAsteroidsSpeed;
        public float Duration => _duration;
        public int AsteroidsAmount => _amount;

        [SerializeField] private float _maxDistanceForShip;
        [SerializeField] private float _minDisanceForShip;
        [SerializeField] private float _minAsteroidsSpeed;
        [SerializeField] private float _maxAsteroidsSpeed;
        [SerializeField] private float _duration;
        [SerializeField] private int _amount;
    }
}