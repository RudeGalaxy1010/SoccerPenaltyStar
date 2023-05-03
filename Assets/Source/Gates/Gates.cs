using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Gates : MonoBehaviour
{
    public event Action<Gates> GoalScored;

    private const int PointsToAdd = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            ball.Owner.Score.AddPoints(PointsToAdd);
            GoalScored?.Invoke(this);
        }
    }
}
