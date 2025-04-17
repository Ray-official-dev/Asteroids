using System;
using Game.GameplayRules;
using MPA.Utilits;
using UnityEngine;
using Utilits;

namespace Game.View
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MPA.View
    {
        public event Action<Bullet> OnDeactivated;

        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;
        private Timer _timer;
        private Rigidbody2D _rigidbody;
        private Lifecycle _lifecycle;

        //private void OnDisable()
        //{
        //    OnDeactivated?.Invoke(this);
        //}

        public override void Initialize()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _lifecycle = Context.Get<Gameplay>().Lifecycle;
            _timer = new Timer();
            _timer.TimeEnded += Disable;
        }

        public override void OnTick()
        {
            _rigidbody.linearVelocity = transform.up * _speed * Time.deltaTime;
            _timer.Tick(Time.deltaTime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Asteroid asteroid))
            {
                asteroid.TakeDamage(1);
                Disable();
            }
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