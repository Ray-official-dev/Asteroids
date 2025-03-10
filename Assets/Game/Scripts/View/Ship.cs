using MPA;
using MPA.Utilits;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Ship : View
{
    private IInputControl _input;
    private Rigidbody2D _rigidbody;

    public override void Initialize()
    {
        _input = Context.Get<IInputControl>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }


}

public interface IInputControl
{

}