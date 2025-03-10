using UnityEngine;
using System;

public class MobileInputControl : MonoBehaviour, IInputControl
{
    public bool IsMoveForward => _moveForwardButton.IsPressed;
    public bool IsMoveBackward => _moveBackwardButton.IsPressed;

    [SerializeField] private ButtonPressedHandler _moveForwardButton;
    [SerializeField] private ButtonPressedHandler _moveBackwardButton;

    public void Awake()
    {
        if (_moveBackwardButton is null)
            throw new NullReferenceException(nameof(_moveBackwardButton));

        if (_moveForwardButton is null)
            throw new NullReferenceException(nameof(_moveForwardButton));
    }
}