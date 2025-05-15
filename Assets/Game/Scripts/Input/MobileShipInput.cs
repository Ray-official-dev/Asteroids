using UnityEngine;
using System;
using Utilits;
using MPA.Utilits;

namespace Game.Input
{
    public class MobileShipInput : MonoBehaviour, IInputShip, IPrefab
    {
        public bool IsMoveForward => _moveForwardButton.IsPressed;
        public bool IsMoveBackward => _moveBackwardButton.IsPressed;
        public bool IsShoot => _shootButton.IsPressed;
        public Vector3 TouchPosition { get; private set; }

        [SerializeField] private ButtonPressedHandler _moveForwardButton;
        [SerializeField] private ButtonPressedHandler _moveBackwardButton;
        [SerializeField] private ButtonPressedHandler _shootButton;
        [SerializeField] private TouchHandler _touchZone;
      
        private void Awake()
        {
            if (_moveBackwardButton is null)
                throw new NullReferenceException(nameof(_moveBackwardButton));

            if (_moveForwardButton is null)
                throw new NullReferenceException(nameof(_moveForwardButton));
        }

        private void Update()
        {
            TouchPosition = Vector3.zero;

            if (!_touchZone.IsTouched)
                return;

            var position = _touchZone.TouchPosition;
            var worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(position.x, position.y, 10));
            TouchPosition = worldPosition;
        }
    }
}