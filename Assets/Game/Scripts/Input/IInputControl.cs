using UnityEngine;

public interface IInputControl
{
    public Vector3 TouchPosition { get; }
    public bool IsMoveForward { get; }
    public bool IsMoveBackward { get; }
}