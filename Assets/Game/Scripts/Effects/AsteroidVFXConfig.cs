using UnityEngine;

namespace Game.Effects
{
    [CreateAssetMenu(menuName = Constans.CONFIGS_PATH + "Asteroid/VFXConfig")]
    public class AsteroidVFXConfig : ScriptableObject
    {
        public VFX Boom => _boom;
        [SerializeField] private VFX _boom;
    }
}