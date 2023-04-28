using UnityEngine;

public class Starter : MonoBehaviour
{
    private DefaultControls _defaultControls;

    private void Start()
    {
        InitInput();
    }

    private void InitInput()
    {
        _defaultControls = new DefaultControls();
        _defaultControls.Enable();
    }
}
