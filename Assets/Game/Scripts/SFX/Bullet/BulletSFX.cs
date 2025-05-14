using Game.View;
using MPA.Utilits;
using UnityEngine;

namespace Game.SFX
{
    public class BulletSFX
    {
        private BulletSFXConfig _config;

        public BulletSFX(Bullet bullet)
        {
            _config = Context.Get<BulletSFXConfig>();
            bullet.Collision += OnCollision;
        }

        private void OnCollision(Collision2D col)
        {
            if (!col.gameObject.TryGetComponent<Asteroid>(out _))
                return;

            _config.Hit.Play();
        }
    }
}