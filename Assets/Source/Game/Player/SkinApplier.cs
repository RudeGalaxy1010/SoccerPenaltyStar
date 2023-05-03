using UnityEngine;

public class SkinApplier : MonoBehaviour
{
    private const string SkinPrefabsPath = "SkinPrefabs";

    [SerializeField] private Transform _skinSpawnPoint;

    private void Awake()
    {
        LoadSkin();
    }

    private void LoadSkin()
    {
        int skinIndex = DataHolder.PlayerData.PlayerSkinIndex;
        GameObject[] skinPrefabs = Resources.LoadAll<GameObject>(SkinPrefabsPath);
        Instantiate(skinPrefabs[skinIndex], _skinSpawnPoint.position, Quaternion.identity, _skinSpawnPoint);
    }
}
