using UnityEngine;

namespace Game.SFX
{
    [CreateAssetMenu(menuName = Constans.CONFIGS_PATH + "SFX/AsteroidsConfig")]
    public class AsteroidsSFXConfig : ScriptableObject
    {
        public SFX DestroySound => _destroySound;
        [SerializeField] private SFX _destroySound;
    }
}