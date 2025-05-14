using Game.View;
using MPA.Utilits;
using UnityEngine;

namespace Game.VFX
{
    public class BulletVFX
    {
        private BulletVFXConfig _config;

        public BulletVFX(Bullet bullet)
        {
            _config = Context.Get<BulletVFXConfig>();
            bullet.Collision += OnCollision;
        }

        private void OnCollision(Collision2D col)
        {
            if (!col.gameObject.TryGetComponent<Asteroid>(out _))
                return;

            var contact = col.contacts[0];
            Vector2 position = contact.point;
            Vector2 normal = contact.normal;
            Quaternion rotation = Quaternion.FromToRotation(Vector3.right, normal);
            _config.Hit.Play(position, rotation);
        }
    }
}