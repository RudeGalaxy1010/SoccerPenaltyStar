using UnityEngine;

public class ForceArrow : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private SpriteRenderer _arrowSprite;

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
        _lineRenderer.positionCount = 2;
        Vector3 endPoint = (_startPoint.position + force);
        Vector3[] positions = new Vector3[] { _startPoint.position, endPoint };

        _arrowSprite.gameObject.SetActive(true);
        _arrowSprite.transform.position = endPoint;
        _lineRenderer.SetPositions(positions);
    }

    public void ResetArrow()
    {
        _lineRenderer.positionCount = 0;
        _arrowSprite.gameObject.SetActive(false);
    }
}
