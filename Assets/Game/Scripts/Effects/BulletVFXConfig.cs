using UnityEngine;

namespace Game.Effects
{
    [CreateAssetMenu(menuName = Constans.CONFIGS_PATH + "Bullet/VFXConfig")]
    public class BulletVFXConfig : ScriptableObject
    {
        public VFX Collision => _collision;
        [SerializeField] private VFX _collision;
    }
}