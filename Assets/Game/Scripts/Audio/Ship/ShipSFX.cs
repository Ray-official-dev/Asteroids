using Game.View;
using MPA.Utilits;
using TMPro;
using UnityEngine;

namespace Game.Audio
{
    public class ShipSFX
    {
        private ShipSFXConfig _config;

        public ShipSFX(Ship ship)
        {
            _config = Context.Get<ShipSFXConfig>();
            ship.Shooted += OnShooted;
        }

        private void OnShooted(Vector3 pos, Quaternion rot)
        {
            _config.ShootSound.Play();
        }
    }
}