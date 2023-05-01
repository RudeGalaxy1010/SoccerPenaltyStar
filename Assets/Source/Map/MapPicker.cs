using System;

public class MapPicker
{
    private const int MapPrefabsCount = 4;
    private const string MapPrefabsCountExceptionMessage = "Map prefabs count is wrong!";

    private const int MaxRatingForMap1 = 1200;
    private const int MaxRatingForMap2 = 1500;
    private const int MaxRatingForMap3 = 2000;

    public Map GetMapPrefab(Map[] mapPrefabs, int rating)
    {
        if (mapPrefabs.Length != MapPrefabsCount)
        {
            throw new ArgumentException(MapPrefabsCountExceptionMessage);
        }

        switch (rating)
        {
            case >= MaxRatingForMap3: return mapPrefabs[3];
            case >= MaxRatingForMap2: return mapPrefabs[2];
            case >= MaxRatingForMap1: return mapPrefabs[1];
            default: return mapPrefabs[0];
        }
    }
}
