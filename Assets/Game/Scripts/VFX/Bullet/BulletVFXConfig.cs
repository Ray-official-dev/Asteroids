using UnityEngine;

namespace Game.VFX
{
    [CreateAssetMenu(menuName = Constans.CONFIGS_PATH + "VFX/BulletConfig")]
    public class BulletVFXConfig : ScriptableObject
    {
        public VFX Hit => _hit;
        [SerializeField] private VFX _hit;
    }
}