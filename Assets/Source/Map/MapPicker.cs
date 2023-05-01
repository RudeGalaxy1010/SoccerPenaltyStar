using System.Linq;
using UnityEngine;

public class MapPicker
{
    private const int MaxRatingForMap1 = 1200;
    private const int MaxRatingForMap2 = 1500;
    private const int MaxRatingForMap3 = 2000;

    private Map[] _mapPrefabs;

    public MapPicker(Map[] mapPrefabs)
    {
        _mapPrefabs = mapPrefabs;
    }

    public Map CreateMap(int rating)
    {
        Map prefab = GetMapPrefab(rating);
        Map map = Object.Instantiate(prefab);
        return map;
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
}
