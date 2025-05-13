using System;
using UnityEngine;

namespace Game.Audio
{
    [CreateAssetMenu(menuName = Constans.CONFIGS_PATH + "Audio/ClickSound")]
    public class AudioClickSound : ScriptableObject
    {
        [SerializeField] private SFX _source;

        public void Play()
        {
            _source.Play();
        }
    }
}