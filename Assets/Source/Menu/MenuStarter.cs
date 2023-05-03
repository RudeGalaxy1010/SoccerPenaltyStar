using UnityEngine;

public class MenuStarter : MonoBehaviour
{
    [SerializeField] private Transform _skinSpawnPoint;
    [SerializeField] private SkinButtons _skinButtons;

    private void Start()
    {
        SkinPicker skinPicker = new SkinPicker();
        skinPicker.Construct(_skinSpawnPoint);
        _skinButtons.Construct(skinPicker);
    }
}
