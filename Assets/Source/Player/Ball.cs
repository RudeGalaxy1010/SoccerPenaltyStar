using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider), typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    public event Action GotInGates;

    [SerializeField] private Rigidbody _rigidbody;

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

    public void GetInGates()
    {
        GotInGates?.Invoke();
    }
}
