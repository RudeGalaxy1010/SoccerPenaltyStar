using UnityEngine;

public class SkinApplier : MonoBehaviour
{
    [SerializeField] private Transform _skinSpawnPoint;

    public void Construct(Skin skinPrefab, SkinData skinData)
    {
        Vector3 position = _skinSpawnPoint.position;
        Quaternion rotation = _skinSpawnPoint.rotation;
        Skin skin = Instantiate(skinPrefab, position, rotation, transform);
        skin.Apply(skinData);
    }
}
