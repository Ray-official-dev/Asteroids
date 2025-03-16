using UnityEngine;

public interface IInputShip
{
    public Vector3 TouchPosition { get; }
    public bool IsMoveForward { get; }
    public bool IsMoveBackward { get; }
    public bool IsShoot { get; }
}