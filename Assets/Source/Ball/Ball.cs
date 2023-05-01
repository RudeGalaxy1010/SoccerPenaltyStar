using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider), typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    //private Controls _controls;

    //public void Construct(Controls controls)
    //{
    //    _controls = controls;
    //    _controls.DefaultActionMap.LeftMouseButtonPress.started += (ctx) => OnLeftMouseButtonPressStarted();
    //}

    //private void OnLeftMouseButtonPressStarted()
    //{
    //    ResetMove();
    //}

    public void ResetMove()
    {
        _rigidbody.Sleep();
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.WakeUp();
    }

    public void AddForce(Vector3 force)
    {
        ResetMove();
        _rigidbody.AddForce(force, ForceMode.Impulse);
    }
}
