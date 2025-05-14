using System;
using UnityEngine;

namespace Game.SFX
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