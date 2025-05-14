using Game.View;
using MPA.Utilits;

namespace Game.SFX
{
    public class AsteroidSFX
    {
        private AsteroidsSFXConfig _config;

        public AsteroidSFX(Asteroid asteroid)
        {
            _config = Context.Get<AsteroidsSFXConfig>();
            asteroid.Destroying += OnDestroying;
        }

        private void OnDestroying(Asteroid asteroid)
        {
            _config.DestroySound.Play();
        }
    }
}