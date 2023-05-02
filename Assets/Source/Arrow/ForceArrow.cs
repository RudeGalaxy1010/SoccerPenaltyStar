using UnityEngine;

public class ForceArrow : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private GameObject _arrowSprite;

    private Transform _startPoint;
    private BallLauncher _ballLauncher;

    public void Construct(Transform startPoint, BallLauncher ballLauncher)
    {
        _startPoint = startPoint;
        _ballLauncher = ballLauncher;
    }

    private void Update()
    {
        if (_ballLauncher == null)
        {
            return;
        }

        if (_ballLauncher.IsHolding == true)
        {
            DrawArrow(_ballLauncher.Force);
        }
        else
        {
            ResetArrow();
        }
    }

    public void DrawArrow(Vector3 force)
    {
        RenderLine(force);
        RenderArrow(force);
    }

    private void RenderArrow(Vector3 force)
    {
        _arrowSprite.SetActive(true);
        _arrowSprite.transform.position = GetLineEndPoint(force);
        _arrowSprite.transform.LookAt(_arrowSprite.transform.position + force, Vector3.up);
    }

    private void RenderLine(Vector3 force)
    {
        _lineRenderer.positionCount = 2;
        Vector3[] positions = new Vector3[] { _startPoint.position, GetLineEndPoint(force) };
        _lineRenderer.SetPositions(positions);
    }

    private Vector3 GetLineEndPoint(Vector3 force)
    {
        return _startPoint.position + force;
    }

    public void ResetArrow()
    {
        _lineRenderer.positionCount = 0;
        _arrowSprite.SetActive(false);
    }
}
