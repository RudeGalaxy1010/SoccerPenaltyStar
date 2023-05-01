using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceArrow : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;

    private void Start()
    {
        ResetArrow();
    }

    public void DrawArrow(Vector3 direction, float force)
    {
        _lineRenderer.positionCount = 2;
        Vector3[] positions = new Vector3[] { transform.position, direction * force };
        _lineRenderer.SetPositions(positions);
    }

    public void ResetArrow()
    {
        _lineRenderer.positionCount = 0;
    }
}
