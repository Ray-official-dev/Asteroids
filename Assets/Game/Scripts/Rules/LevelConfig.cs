using UnityEngine;

namespace Game
{
    [CreateAssetMenu(menuName = Constans.CONFIGS_PATH + "Level")]
    public class LevelConfig : ScriptableObject
    {
        public int AsteroidsAmount => _amount;
        public float MinAsteroidsDistanceForShip => _minDisanceForShip;
        public float MaxAsteroidsDistanceForShip => _maxDistanceForShip;

        [SerializeField] private int _amount;
        [SerializeField] private float _maxDistanceForShip;
        [SerializeField] private float _minDisanceForShip;
    }
}