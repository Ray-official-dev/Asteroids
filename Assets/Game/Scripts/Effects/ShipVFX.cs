using Game.View;
using MPA.Utilits;
using UnityEngine;

namespace Game.Effects
{
    public class ShipVFX
    {
        private ShipVFXConfig _config;

        public ShipVFX(Ship ship)
        {
            _config = Context.Get<ShipVFXConfig>();
            ship.Shooted += OnShooted;
            ship.Exploded += OnExploded;
        }

        private void OnExploded(Ship ship)
        {
            _config.Explosion.Play(ship.transform.position, Quaternion.identity);
        }

        private void OnShooted(Vector3 position, Quaternion rotation)
        {
            _config.Fire.Play(position, rotation);
        }
    }
}