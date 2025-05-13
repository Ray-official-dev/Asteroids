using UnityEngine;

namespace Game.Audio
{
    [CreateAssetMenu(menuName = Constans.CONFIGS_PATH + "Audio/ShipSounds")]
    public class ShipSFXConfig : ScriptableObject
    {
        public SFX ShootSound => _shootSound;
        [SerializeField] private SFX _shootSound;
    }
}