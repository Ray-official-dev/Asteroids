using MPA.Utilits;
using UnityEngine;

namespace Game.View
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Mover : MPA.View
    {
        private IInputShip _input;
        private Rigidbody2D _rigidbody;

        [SerializeField] private float _moveForce;

        private const float _moveForceScaler = 100;

        public override void Initialize()
        {
            _input = Context.Get<IInputShip>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public override void OnTick()
        {
            Move();
            Rotate();
        }
 
        private void Rotate()
        {
            var touchPosition = _input.TouchPosition;

            if (touchPosition.x == 0 & touchPosition.y == 0)
                return;

            LookAt(touchPosition);
        }

        private void Move()
        {
            if (_input.IsMoveForward)
                _rigidbody.AddForce(transform.right * _moveForce * _moveForceScaler * Time.deltaTime);

            if (_input.IsMoveBackward)
                _rigidbody.AddForce(-transform.right * _moveForce * _moveForceScaler * Time.deltaTime);
        }

        private void LookAt(Vector3 touchPosition)
        {
            var targetPosition = new Vector3(touchPosition.x, touchPosition.y, transform.position.z);

            var direction = targetPosition - transform.position;

            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}