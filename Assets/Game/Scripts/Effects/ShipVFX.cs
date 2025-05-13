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
        }

        private void OnShooted(Vector3 position, Quaternion rotation)
        {
            _config.Fire.Play(position, rotation);
        }
    }
}