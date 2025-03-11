using MPA.Utilits;
using UnityEngine;

namespace Game.View
{
    public class Rotator : MonoBehaviour
    {
        private IInputControl _input;

        private void Awake()
        {
            _input = Context.Get<IInputControl>();
        }

        private void Update()
        {
            var touchPosition = _input.TouchPosition;

            if (touchPosition.x == 0 & touchPosition.y == 0)
                return;
            Debug.Log(touchPosition);

            LookAt(touchPosition);
        }

        private void LookAt(Vector3 touchPosition)
        {
            //Debug.Log("Look at");
            var targetPosition = new Vector3(touchPosition.x, touchPosition.y, transform.position.z);

            var direction = targetPosition - transform.position;

            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}