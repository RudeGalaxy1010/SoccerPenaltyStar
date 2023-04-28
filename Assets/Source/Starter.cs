using UnityEngine;

public class Starter : MonoBehaviour
{
    private DefaultControls _defaultControls;
    private MapPicker _mapPicker;

    private void Start()
    {
        InitInput();
        InitMap();
    }

    private void InitMap()
    {
        _mapPicker = new MapPicker();
        _mapPicker.CreateMap(0);
    }

    private void InitInput()
    {
        _defaultControls = new DefaultControls();
        _defaultControls.Enable();
    }
}
