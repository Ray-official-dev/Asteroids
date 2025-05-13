using MPA.Utilits;

namespace Game.Audio
{
    public class AudioClickHandler
    {
        private AudioClickSound _source;

        public AudioClickHandler() 
        {
            _source = Context.Get<SOConfigsProvider>()
                .Get<AudioClickSound>();
        }

        public void OnClicked()
        {
            _source.Play();
        }
    }
}