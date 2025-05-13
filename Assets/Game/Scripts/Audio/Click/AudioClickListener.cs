using MPA.Utilits;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Audio
{
    [AddComponentMenu("Audio/Audio Click Listener")]
    [RequireComponent(typeof(Button))]
    public class AudioClickListener : MonoBehaviour
    {
        private AudioClickHandler _handler => Context.Get<AudioClickHandler>();
        private Button _source;

        private void Awake()
        {
            _source = GetComponent<Button>();
        }

        private void OnEnable()
        {
            _source.onClick.AddListener(_handler.OnClicked);
        }

        private void OnDisable()
        {
            try
            {
                _source.onClick.RemoveListener(_handler.OnClicked);
            }
            catch { }
        }
    }
}