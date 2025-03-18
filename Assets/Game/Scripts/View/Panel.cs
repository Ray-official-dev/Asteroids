using UnityEngine;

namespace Game.View
{
    public abstract class Panel : MPA.View
    {
        [SerializeField] GameObject _source;

        public virtual void Show()
        {
            _source.SetActive(true);
        }

        public virtual void Hide()
        {
            _source.SetActive(false);
        }
    }
}