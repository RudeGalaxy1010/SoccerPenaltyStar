using System;

public class MapPicker
{
    private const int MapPrefabsCount = 4;
    private const string MapPrefabsCountExceptionMessage = "Map prefabs count is wrong!";

    private const int MaxRatingForMap1 = 1100;
    private const int MaxRatingForMap2 = 1200;
    private const int MaxRatingForMap3 = 1300;

    public Map GetMapPrefab(Map[] mapPrefabs, int rating)
    {
        if (mapPrefabs.Length != MapPrefabsCount)
        {
            throw new ArgumentException(MapPrefabsCountExceptionMessage);
        }

        if (rating >= MaxRatingForMap3)
        {
            return mapPrefabs[3];
        }
        else if (rating >= MaxRatingForMap2)
        {
            return mapPrefabs[2];
        }
        else if (rating >= MaxRatingForMap1)
        {
            return mapPrefabs[1];
        }
        else
        {
            return mapPrefabs[0];
        }
    }
}
