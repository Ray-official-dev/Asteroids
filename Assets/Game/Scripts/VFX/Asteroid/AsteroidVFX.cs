using Game.View;
using MPA.Utilits;

namespace Game.VFX
{
    public class AsteroidVFX
    {
        private AsteroidVFXConfig _config;

        public AsteroidVFX(Asteroid asteroid)
        {
            _config = Context.Get<AsteroidVFXConfig>();
            asteroid.Destroying += OnDestroying;
        }

        private void OnDestroying(Asteroid asteroid)
        {
            _config.Explosion.Play(asteroid.transform.position, asteroid.transform.rotation);
        }
    }
}