using UnityEngine;

namespace Game.Audio
{
    [CreateAssetMenu(menuName = Constans.CONFIGS_PATH + "Audio/ShipSounds")]
    public class ShipSFXConfig : ScriptableObject
    {
        public SFX ShootSFX => _shootSFX;
        public SFX ExplosionSFX => _explosionSFX;

        [SerializeField] private SFX _shootSFX;
        [SerializeField] private SFX _explosionSFX;
    }
}