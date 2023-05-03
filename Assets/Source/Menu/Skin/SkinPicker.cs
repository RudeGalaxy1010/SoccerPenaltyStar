using System.Collections.Generic;
using UnityEngine;

public class SkinPicker
{
    private const string SkinPrefabsPath = "SkinPrefabs";

    private Transform _skinSpawnPoint;
    private List<GameObject> _skins;
    private int _currentSkinIndex;

    public void Construct(Transform skinSpawnPoint)
    {
        _skinSpawnPoint = skinSpawnPoint;
        _skins = LoadSkins();
        _currentSkinIndex = 0;
        SetSkin(_currentSkinIndex);
    }

    public void SetNextSkin()
    {
        _currentSkinIndex++;

        if (_currentSkinIndex >= _skins.Count)
        {
            _currentSkinIndex = 0;
        }

        SetSkin(_currentSkinIndex);
    }

    public void SetPreviousSkin()
    {
        _currentSkinIndex--;

        if (_currentSkinIndex < 0)
        {
            _currentSkinIndex = _skins.Count - 1;
        }

        SetSkin(_currentSkinIndex);
    }

    private List<GameObject> LoadSkins()
    {
        List<GameObject> skins = new List<GameObject>();
        GameObject[] skinPrefabs = Resources.LoadAll<GameObject>(SkinPrefabsPath);

        for (int i = 0; i < skinPrefabs.Length; i++)
        {
            GameObject skin = Object.Instantiate(skinPrefabs[i], _skinSpawnPoint.position, _skinSpawnPoint.rotation);
            skins.Add(skin);
        }

        return skins;
    }

    private void SetSkin(int index)
    {
        for (int i = 0; i < _skins.Count; i++)
        {
            if (i == index)
            {
                _skins[i].SetActive(true);
                continue;
            }

            _skins[i].SetActive(false);
        }
    }
}
