using UnityEngine;

namespace Utilits
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform _target; // Об'єкт, за яким слідкує камера
        [SerializeField] private float _smoothSpeed = 5f; // Швидкість згладжування

        private void LateUpdate()
        {
            if (_target == null) 
                return;

            Vector3 targetPosition = new Vector3(_target.position.x, _target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, _smoothSpeed * Time.deltaTime);
        }

        public void Set(Transform target)
        {
            _target = target;
        }
    }
}