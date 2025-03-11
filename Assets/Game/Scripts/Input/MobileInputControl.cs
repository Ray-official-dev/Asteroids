﻿using UnityEngine;
using System;
using UnityEngine.InputSystem;

namespace Game.Input
{
    public class MobileInputControl : MonoBehaviour, IInputControl
    {
        public bool IsMoveForward => _moveForwardButton.IsPressed;
        public bool IsMoveBackward => _moveBackwardButton.IsPressed;
        public Vector3 TouchPosition { get; private set; }

        [SerializeField] private ButtonPressedHandler _moveForwardButton;
        [SerializeField] private ButtonPressedHandler _moveBackwardButton;

        [Range(0, 1)]
        [SerializeField] private float blockControlAreaPercentage = 0.8f;

        private Rect _blockControlArea;

        private void Awake()
        {
            if (_moveBackwardButton is null)
                throw new NullReferenceException(nameof(_moveBackwardButton));

            if (_moveForwardButton is null)
                throw new NullReferenceException(nameof(_moveForwardButton));

            _blockControlArea = new Rect(0, 0, Screen.width * blockControlAreaPercentage, Screen.height * blockControlAreaPercentage);
        }

        private void Update()
        {
            if (Touchscreen.current is null)
                return;

            var touch = Touchscreen.current.primaryTouch;
            TouchPosition = Vector3.zero;

            if (!touch.press.isPressed)
                return;

            var position = touch.position.ReadValue();

            if (IsTouchInBlockControlArea(position))
                return;

            var worldPosition = Camera.main.ScreenToWorldPoint(new Vector3(position.x, position.y, 10));

            TouchPosition = worldPosition;
        }

        private bool IsTouchInBlockControlArea(Vector2 touchPosition)
        {
            return _blockControlArea.Contains(touchPosition);
        }
    }
}