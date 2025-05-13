using System;
using System.Collections.Generic;
using Game.GameplayRules;
using MPA.Utilits;
using UnityEngine;

namespace Game.View
{
    public class Shooter : MPA.View
    {
        private IInputShip _input;

        public event Action<Vector3, Quaternion> Shooted;

        [Tooltip("In seconds")]
        [SerializeField] private float _fireCooldown;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private int _poolSize = 10;

        private Lifecycle _lifecycle;
        private float _timeSinceLastFire;
        private Queue<Bullet> _bulletPool;

        public override void Initialize()
        {
            _input = Context.Get<IInputShip>();
            _lifecycle = Context.Get<Gameplay>().Lifecycle;
            InitializePool();
        }

        private void InitializePool()
        {
            _bulletPool = new Queue<Bullet>();

            for (int i = 0; i < _poolSize; i++)
            {
                var bullet = Instantiate(_bulletPrefab);
                bullet.gameObject.SetActive(false);
                _bulletPool.Enqueue(bullet);
            }
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
            if (_bulletPool.Count > 0)
            {
                var bullet = _bulletPool.Dequeue();
                bullet.transform.position = _firePoint.position;
                bullet.transform.rotation = _firePoint.rotation;
                _lifecycle.Add(bullet);
                bullet.Enable();
                bullet.OnDeactivated += ReturnToPool;

                Shooted?.Invoke(_firePoint.position, _firePoint.rotation);
            }
        }

        private void ReturnToPool(Bullet bullet)
        {
            bullet.OnDeactivated -= ReturnToPool;
            bullet.Disable();
            _bulletPool.Enqueue(bullet);
        }
    }
}