using UnityEngine;

namespace Game.Audio
{
    [CreateAssetMenu(menuName = Constans.CONFIGS_PATH + "Audio/AsteroidsSounds")]
    public class AsteroidsSFXConfig : ScriptableObject
    {
        public SFX DestroySound => _destroySound;
        [SerializeField] private SFX _destroySound;
    }
}