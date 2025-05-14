using System;
using UnityEngine;

namespace Game.SFX
{
    [Serializable]
    public class SFX
    {
        [SerializeField] private AudioClip _clip;
        [SerializeField, Range(0, 1)]
        private float _volume;

        private AudioSource _source;

        public void Play()
        {
            if (_source == null)
                CreateSource();
            else if (_source.gameObject == null)
                CreateSource();

            _source.Play();
        }

        private void CreateSource()
        {
            GameObject tempObject = new GameObject("Audio");
            tempObject.hideFlags = HideFlags.HideInHierarchy;
            _source = tempObject.AddComponent<AudioSource>();
            _source.clip = _clip;
            _source.volume = _volume;
        }
    }
}