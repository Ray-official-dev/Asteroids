using UnityEngine;

namespace Game.Effects
{
    [CreateAssetMenu(menuName = Constans.CONFIGS_PATH + "Ship/VFXConfig")]
    public class ShipVFXConfig : ScriptableObject
    {
        public VFX Fire => _fire;
        [SerializeField] private VFX _fire;
    }
}