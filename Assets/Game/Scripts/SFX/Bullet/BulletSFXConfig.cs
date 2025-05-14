using UnityEngine;

namespace Game.SFX
{
    [CreateAssetMenu(menuName = Constans.CONFIGS_PATH + "SFX/BulletConfig")]
    public class BulletSFXConfig : ScriptableObject
    {
        public SFX Hit => _hit;
        [SerializeField] private SFX _hit;
    }
}