using UnityEngine;

public class SkinApplier : MonoBehaviour
{
    [SerializeField] private Transform _skinSpawnPoint;

    public void Construct(SkinCustomization skinPrefab)
    {
        Vector3 position = _skinSpawnPoint.position;
        Quaternion rotation = _skinSpawnPoint.rotation;
        SkinCustomization skin = Instantiate(skinPrefab, position, rotation, transform);
        skin.Apply(DataHolder.PlayerData.SkinCustomizationData);
    }
}
