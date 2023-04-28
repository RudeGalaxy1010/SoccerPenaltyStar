using System.Linq;
using UnityEngine;

public class MapPicker
{
    private const string MapPrefabsFolderPath = "MapPrefabs";
    private const int MaxRatingForMap1 = 1200;
    private const int MaxRatingForMap2 = 1500;
    private const int MaxRatingForMap3 = 2000;

    private Map[] _mapPrefabs;

    public MapPicker()
    {
        _mapPrefabs = LoadMapPrefabs();
    }

    public Map CreateMap(int rating)
    {
        Map prefab = GetMapPrefab(rating);
        return Object.Instantiate(prefab);
    }

    private Map GetMapPrefab(int rating)
    {
        switch (rating)
        {
            case >= MaxRatingForMap3: return _mapPrefabs[3];
            case >= MaxRatingForMap2: return _mapPrefabs[2];
            case >= MaxRatingForMap1: return _mapPrefabs[1];
            default: return _mapPrefabs[0];
        }
    }

    private Map[] LoadMapPrefabs()
    {
        return Resources.LoadAll<GameObject>(MapPrefabsFolderPath).Select(m => m.GetComponent<Map>()).ToArray();
    }
}
