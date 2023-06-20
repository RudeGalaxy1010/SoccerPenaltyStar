using UnityEngine;

public class ForceArrow : MonoBehaviour
{
    private const float MaxLength = 6f;

    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private GameObject _arrowSprite;

    private Transform _startPoint;
    private PlayerBallLauncher _ballLauncher;

    public void Construct(Transform startPoint, PlayerBallLauncher ballLauncher)
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
        force = new Vector3(force.x/10,force.y/10,force.z/10);
        Vector3 endPoint = _startPoint.position + NormalizeForceMagnitude(force);
        return endPoint;
    }

    private Vector3 NormalizeForceMagnitude(Vector3 force)
    {
        float forceScale = (BallLauncher.MaxForce - BallLauncher.MinForce) * BallLauncher.ForceScale;
        float minForceMagnitude = BallLauncher.MinForce * BallLauncher.ForceScale;
        float normalizedForceMagnitude = (force.magnitude - minForceMagnitude) / forceScale;
        return force.normalized * normalizedForceMagnitude * MaxLength;
    }

    public void ResetArrow()
    {
        _lineRenderer.positionCount = 0;
        _arrowSprite.SetActive(false);
    }
}
