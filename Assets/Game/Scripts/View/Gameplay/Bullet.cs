using UnityEngine;

namespace Game.View
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MPA.View
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _lifeTime;
        private Rigidbody2D _rigidbody;

        public override void Initialize()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            Destroy(gameObject, _lifeTime);
        }

        public override void OnTick()
        {
            _rigidbody.linearVelocity = transform.up * _speed * Time.deltaTime;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent(out Asteroid asteroid))
                asteroid.TakeDamage(1);

            Destroy(gameObject);
        }
    }
}