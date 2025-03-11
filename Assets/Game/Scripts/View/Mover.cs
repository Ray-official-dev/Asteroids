using MPA.Utilits;
using UnityEngine;

namespace Game.View
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MonoBehaviour
    {
        private IInputControl _input;
        private Rigidbody2D _rigidbody;

        [SerializeField] private float _moveForce;

        private const float _moveForceScaler = 100;

        private void Awake()
        {
            _input = Context.Get<IInputControl>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (_input.IsMoveForward)
                _rigidbody.AddForce(transform.right * _moveForce * _moveForceScaler * Time.deltaTime);

            if (_input.IsMoveBackward)
                _rigidbody.AddForce(-transform.right * _moveForce * _moveForceScaler * Time.deltaTime);
        }
    }
}