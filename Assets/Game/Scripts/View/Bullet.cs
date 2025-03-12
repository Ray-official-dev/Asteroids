using UnityEngine;

namespace Game.View
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private float _speed;
        private Rigidbody2D _rigidbody;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            _rigidbody.linearVelocity = transform.up * _speed * Time.deltaTime;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            //destroyed asteroids
        }
    }
}