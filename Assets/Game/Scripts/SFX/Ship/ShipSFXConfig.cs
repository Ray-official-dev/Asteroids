using UnityEngine;

namespace Game.SFX
{
    [CreateAssetMenu(menuName = Constans.CONFIGS_PATH + "SFX/ShipConfig")]
    public class ShipSFXConfig : ScriptableObject
    {
        public SFX ShootSFX => _shootSFX;
        public SFX ExplosionSFX => _explosionSFX;

        [SerializeField] private SFX _shootSFX;
        [SerializeField] private SFX _explosionSFX;
    }
}