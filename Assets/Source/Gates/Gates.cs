using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Gates : MonoBehaviour
{
    private const int PointsToAdd = 1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Ball ball))
        {
            ball.Owner.AddScore(PointsToAdd);
        }
    }
}
