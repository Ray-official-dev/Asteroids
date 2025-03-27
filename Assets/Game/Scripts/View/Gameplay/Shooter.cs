using System;
using Game.GameplayRules;
using MPA.Utilits;
using UnityEngine;

namespace Game.View
{
    public class Shooter : MPA.View
    {
        private IInputShip _input;

        [Tooltip("In seconds")]
        [SerializeField] private float _fireCooldown;
        [SerializeField] private Transform _bulletPoint;
        [SerializeField] private Bullet _bulletPrefab;
        private Lifecycle _lifecycle;

        private float _timeSinceLastFire;

        public override void Initialize()
        {
            _input = Context.Get<IInputShip>();
            _lifecycle = Context.Get<Gameplay>().Lifecycle;
        }

        public override void OnTick()
        {
            _timeSinceLastFire += Time.deltaTime;

            if (!_input.IsShoot)
                return;

            if (_timeSinceLastFire < _fireCooldown)
                return;

            Shoot();
            _timeSinceLastFire = 0;
        }

        private void Shoot()
        {
            var bullet = Instantiate(_bulletPrefab, _bulletPoint.position, _bulletPoint.rotation);
            _lifecycle.Add(bullet);
        }
    }
}