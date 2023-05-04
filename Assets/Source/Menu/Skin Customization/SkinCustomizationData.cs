using System;

[Serializable]
public class SkinCustomizationData
{
    public int ColorIndex;
    public int BodyPartsIndex;
    public int EyesIndex;
    public int GlovesIndex;
    public int HeadPartsIndex;
    public int MouthesIndex;
    public int NosesIndex;
    public int HatsIndex;
    public int TailsIndex;

    public void Reset()
    {
        ColorIndex = 0;
        BodyPartsIndex = 0;
        EyesIndex = 0;
        GlovesIndex = 0;
        HeadPartsIndex = 0;
        MouthesIndex = 0;
        NosesIndex = 0;
        HatsIndex = 0;
        TailsIndex = 0;
    }
}
