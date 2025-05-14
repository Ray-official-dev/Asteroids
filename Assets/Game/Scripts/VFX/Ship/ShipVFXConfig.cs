using UnityEngine;

namespace Game.VFX
{
    [CreateAssetMenu(menuName = Constans.CONFIGS_PATH + "VFX/ShipConfig")]
    public class ShipVFXConfig : ScriptableObject
    {
        public VFX Fire => _fire;
        public VFX Explosion => _exposion;

        [SerializeField] private VFX _fire;
        [SerializeField] private VFX _exposion;
    }
}