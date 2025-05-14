using UnityEngine;

namespace Game.VFX
{
    [CreateAssetMenu(menuName = Constans.CONFIGS_PATH + "VFX/AsteroidConfig")]
    public class AsteroidVFXConfig : ScriptableObject
    {
        public VFX Explosion => _explosion;
        [SerializeField] private VFX _explosion;
    }
}