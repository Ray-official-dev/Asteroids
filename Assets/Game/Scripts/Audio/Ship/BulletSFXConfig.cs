using UnityEngine;

namespace Game.Audio
{
    [CreateAssetMenu(menuName = Constans.CONFIGS_PATH + "Bullet/SFXConfig")]
    public class BulletSFXConfig : ScriptableObject
    {
        public SFX Collision => _collision;
        [SerializeField] private SFX _collision;
    }
}