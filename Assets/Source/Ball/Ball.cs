using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider), typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    private Player _owner;
    public Player Owner => _owner;

    public void SetOwner(Player owner)
    {
        _owner = owner;
    }

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
