using System;
using System.Linq;

[Serializable]
public class UnlockedParts
{
    private const string UnknownPartExceptionMessage = "Unknown part type";

    public int[] UnlockedColorIndexes;
    public int[] UnlockedAccessoriesIndexes;
    public int[] UnlockedEyesIndexes;
    public int[] UnlockedGlovesIndexes;
    public int[] UnlockedHeadIndexes;
    public int[] UnlockedMouthIndexes;
    public int[] UnlockedNoseIndexes;
    public int[] UnlockedTailIndexes;

    public UnlockedParts()
    {
        UnlockedColorIndexes = new int[] { 0 };
        UnlockedAccessoriesIndexes = new int[] { 0 };
        UnlockedEyesIndexes = new int[] { 0 };
        UnlockedGlovesIndexes = new int[] { 0 };
        UnlockedHeadIndexes = new int[] { 0 };
        UnlockedMouthIndexes = new int[] { 0 };
        UnlockedNoseIndexes = new int[] { 0 };
        UnlockedTailIndexes = new int[] { 0 };
    }

    public void UnlockPart(SkinPartType skinPartType, int index)
    {
        switch (skinPartType)
        {
            case SkinPartType.Color: AddIndex(ref UnlockedColorIndexes, index);
                break;
            case SkinPartType.Accessories: AddIndex(ref UnlockedAccessoriesIndexes, index);
                break;
            case SkinPartType.Eyes: AddIndex(ref UnlockedEyesIndexes, index);
                break;
            case SkinPartType.Gloves: AddIndex(ref UnlockedGlovesIndexes, index);
                break;
            case SkinPartType.Head: AddIndex(ref UnlockedHeadIndexes, index);
                break;
            case SkinPartType.Mouth: AddIndex(ref UnlockedMouthIndexes, index);
                break;
            case SkinPartType.Nose: AddIndex(ref UnlockedNoseIndexes, index);
                break;
            case SkinPartType.Tail: AddIndex(ref UnlockedTailIndexes, index);
                break;
            default:
                throw new ArgumentException(UnknownPartExceptionMessage);
        }
    }

    public bool IsUnlocked(SkinPartType customizationPart, int index)
    {
        switch (customizationPart)
        {
            case SkinPartType.Color: return UnlockedColorIndexes.Contains(index);
            case SkinPartType.Accessories: return UnlockedAccessoriesIndexes.Contains(index);
            case SkinPartType.Eyes: return UnlockedEyesIndexes.Contains(index);
            case SkinPartType.Gloves: return UnlockedGlovesIndexes.Contains(index);
            case SkinPartType.Head: return UnlockedHeadIndexes.Contains(index);
            case SkinPartType.Mouth: return UnlockedMouthIndexes.Contains(index);
            case SkinPartType.Nose: return UnlockedNoseIndexes.Contains(index);
            case SkinPartType.Tail: return UnlockedTailIndexes.Contains(index);
            default: throw new ArgumentException(UnknownPartExceptionMessage);
        }
    }

    private void AddIndex(ref int[] array, int index)
    {
        if (array.Contains(index) == true)
        {
            return;
        }

        Array.Resize(ref array, array.Length + 1);
        array[array.Length - 1] = index;
    }
}
