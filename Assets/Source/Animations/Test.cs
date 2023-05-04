using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    [SerializeField] MoveAnimation _moveAnimation;

    private void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            _moveAnimation.PlayOnce();
        }
    }
}
