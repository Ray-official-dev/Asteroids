using System;
using MPA.Utilits;
using UnityEngine;

namespace Game.View
{
    public class Shooter : MonoBehaviour
    {
        private IShipInput _input;

        [Tooltip("In seconds")]
        [SerializeField] private float _fireCooldown;
        [SerializeField] private Transform _bulletPoint;
        [SerializeField] private Bullet _bulletPrefab;

        private float _timeSinceLastFire;

        private void Awake()
        {
            _input = Context.Get<IShipInput>();
        }

        private void Update()
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
            Instantiate(_bulletPrefab, _bulletPoint.position, _bulletPoint.rotation);
        }
    }
}