using System;
using Game.Audio;
using Game.Effects;
using UnityEngine;
using Utilits;

namespace Game.View
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MPA.View
    {
        public event Action<Bullet> OnDeactivated;
        public event Action<Collision2D> Collision;

        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;
        private Timer _timer;
        private Rigidbody2D _rigidbody;

        public override void Initialize()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _timer = new Timer();
            _timer.TimeEnded += Disable;

            var vfx = new BulletVFX(this);
            var sfx = new BulletSFX(this);
        }

        public override void OnTick()
        {
            _rigidbody.linearVelocity = transform.up * _speed * Time.deltaTime;
            _timer.Tick(Time.deltaTime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Asteroid asteroid))
                asteroid.TakeDamage(1);

            Collision?.Invoke(collision);
            Disable();
        }

        public void Enable()
        {
            gameObject.SetActive(true);
            _timer.Start(_lifeTime);
        }

        public void Disable()
        {
            OnDeactivated?.Invoke(this);
            gameObject.SetActive(false);
        }
    }
}