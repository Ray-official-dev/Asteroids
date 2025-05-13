using System.Collections.Generic;
using UnityEngine;

namespace Game.Effects
{
    [System.Serializable]
    public class VFX
    {
        [SerializeField] private ParticleSystem _prefab;

        #region NOT TESTED

        private ParticleSystem _optimizedEffect;

        private List<ParticleSystem> _pool = new List<ParticleSystem>();

        /// <summary>
        /// NOT TESTED
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        public void PlayPooled(Vector3 position, Quaternion rotation)
        {
            var effect = GetFreeEffect();

            effect.transform.SetPositionAndRotation(position, rotation);
            effect.Play();
        }

        private ParticleSystem GetFreeEffect()
        {
            foreach (var e in _pool)
            {
                if (!e.isPlaying)
                    return e;
            }

            var newEffect = Object.Instantiate(_prefab);
            _pool.Add(newEffect);
            return newEffect;
        }

        /// <summary>
        /// NOT TESTED
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        public void PlayOptimized(Vector3 position, Quaternion rotation)
        {
            if (!IsComponentExist(_optimizedEffect))
                CreateEffect();

            _optimizedEffect.transform.SetPositionAndRotation(position, rotation);
            _optimizedEffect.Play();
        }

        private void CreateEffect()
        {
            var temp = Object.Instantiate(_prefab);
            _optimizedEffect = temp.GetComponent<ParticleSystem>();
        }

        private bool IsComponentExist(Component component)
        {
            return component != null && component.gameObject != null;
        }

        #endregion

        public void Play(Vector3 position, Quaternion rotation)
        {
            var effect = Object.Instantiate(_prefab, position, rotation);
            effect.Play();

            Object.Destroy(effect.gameObject, effect.main.duration);
        }
    }
}