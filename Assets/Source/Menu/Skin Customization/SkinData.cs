using System;

[Serializable]
public class SkinData
{
    public int ColorIndex;
    public int AccessoriesIndex;
    public int EyesIndex;
    public int GlovesIndex;
    public int HeadIndex;
    public int MouthIndex;
    public int NoseIndex;
    public int TailIndex;

    public void Reset()
    {
        ColorIndex = 0;
        AccessoriesIndex = 0;
        EyesIndex = 0;
        GlovesIndex = 0;
        HeadIndex = 0;
        MouthIndex = 0;
        NoseIndex = 0;
        TailIndex = 0;
    }
}
