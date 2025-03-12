using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.Input
{
    public class EditorShipInput : MonoBehaviour, IShipInput
    {
        public Vector3 TouchPosition { get; private set; }

        public bool IsMoveForward => Keyboard.current.wKey.isPressed;
        public bool IsMoveBackward => Keyboard.current.sKey.isPressed;
        public bool IsShoot => Mouse.current.leftButton.isPressed;

        private void Update()
        {
            TouchPosition = Vector3.zero;

            if (!Mouse.current.rightButton.IsPressed())
                return;

            var mousePosition = Mouse.current.position.ReadValue();
            var worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 10));
            TouchPosition = worldPosition;
        }
    }
}