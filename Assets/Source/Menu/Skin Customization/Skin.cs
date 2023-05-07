using System;
using UnityEngine;

public class Skin : MonoBehaviour
{
    public event Action Changed;

    public SkinParts ColorSkinParts;
    public SkinParts AccessoriesSkinParts;
    public SkinParts EyesSkinParts;
    public SkinParts GlovesSkinParts;
    public SkinParts HeadSkinParts;
    public SkinParts MouthSkinParts;
    public SkinParts NoseSkinParts;
    public SkinParts TailSkinParts;

    private SkinData _skinData;

    public SkinData SkinData => _skinData;

    private void OnEnable()
    {
        ColorSkinParts.PartChanged += OnPartChanged;
        AccessoriesSkinParts.PartChanged += OnPartChanged;
        EyesSkinParts.PartChanged += OnPartChanged;
        GlovesSkinParts.PartChanged += OnPartChanged;
        HeadSkinParts.PartChanged += OnPartChanged;
        MouthSkinParts.PartChanged += OnPartChanged;
        NoseSkinParts.PartChanged += OnPartChanged;
        TailSkinParts.PartChanged += OnPartChanged;
    }

    private void OnDisable()
    {
        ColorSkinParts.PartChanged -= OnPartChanged;
        AccessoriesSkinParts.PartChanged -= OnPartChanged;
        EyesSkinParts.PartChanged -= OnPartChanged;
        GlovesSkinParts.PartChanged -= OnPartChanged;
        HeadSkinParts.PartChanged -= OnPartChanged;
        MouthSkinParts.PartChanged -= OnPartChanged;
        NoseSkinParts.PartChanged -= OnPartChanged;
        TailSkinParts.PartChanged -= OnPartChanged;
    }

    public void Apply(SkinData skinData)
    {
        _skinData = skinData;
        ColorSkinParts.SetPart(skinData.ColorIndex);
        AccessoriesSkinParts.SetPart(skinData.AccessoriesIndex);
        EyesSkinParts.SetPart(skinData.EyesIndex);
        GlovesSkinParts.SetPart(_skinData.GlovesIndex);
        HeadSkinParts.SetPart(skinData.HeadIndex);
        MouthSkinParts.SetPart(skinData.MouthIndex);
        NoseSkinParts.SetPart(skinData.NoseIndex);
        TailSkinParts.SetPart(skinData.TailIndex);
    }

    public void ApplyRandom()
    {
        ColorSkinParts.SetRandom();
        AccessoriesSkinParts.SetRandom();
        EyesSkinParts.SetRandom();
        GlovesSkinParts.SetRandom();
        HeadSkinParts.SetRandom();
        MouthSkinParts.SetRandom();
        NoseSkinParts.SetRandom();
        TailSkinParts.SetRandom();
    }

    public void ApplyRandomFromAvailable()
    {
        UnlockedParts unlockedParts = DataHolder.PlayerData.UnlockedParts;

        ColorSkinParts.SetRandom(unlockedParts.UnlockedColorIndexes);
        AccessoriesSkinParts.SetRandom(unlockedParts.UnlockedAccessoriesIndexes);
        EyesSkinParts.SetRandom(unlockedParts.UnlockedEyesIndexes);
        GlovesSkinParts.SetRandom(unlockedParts.UnlockedGlovesIndexes);
        HeadSkinParts.SetRandom(unlockedParts.UnlockedHeadIndexes);
        MouthSkinParts.SetRandom(unlockedParts.UnlockedMouthIndexes);
        NoseSkinParts.SetRandom(unlockedParts.UnlockedNoseIndexes);
        TailSkinParts.SetRandom(unlockedParts.UnlockedTailIndexes);
    }

    public float GetForce()
    {
        float force = 0;

        force += ColorSkinParts.CurrentPart.Force;
        force +=  AccessoriesSkinParts.CurrentPart.Force;
        force += EyesSkinParts.CurrentPart.Force;
        force += GlovesSkinParts.CurrentPart.Force;
        force += HeadSkinParts.CurrentPart.Force;
        force += MouthSkinParts.CurrentPart.Force;
        force += NoseSkinParts.CurrentPart.Force;
        force += TailSkinParts.CurrentPart.Force;

        return force;
    }

    public float GetAccuracy()
    {
        float accuracy = 0;

        accuracy += ColorSkinParts.CurrentPart.Accuracy;
        accuracy += AccessoriesSkinParts.CurrentPart.Accuracy;
        accuracy += EyesSkinParts.CurrentPart.Accuracy;
        accuracy += GlovesSkinParts.CurrentPart.Accuracy;
        accuracy += HeadSkinParts.CurrentPart.Accuracy;
        accuracy += MouthSkinParts.CurrentPart.Accuracy;
        accuracy += NoseSkinParts.CurrentPart.Accuracy;
        accuracy += TailSkinParts.CurrentPart.Accuracy;

        return accuracy;
    }

    public float GetLuck()
    {
        float luck = 0;

        luck += ColorSkinParts.CurrentPart.Luck;
        luck += AccessoriesSkinParts.CurrentPart.Luck;
        luck += EyesSkinParts.CurrentPart.Luck;
        luck += GlovesSkinParts.CurrentPart.Luck;
        luck += HeadSkinParts.CurrentPart.Luck;
        luck += MouthSkinParts.CurrentPart.Luck;
        luck += NoseSkinParts.CurrentPart.Luck;
        luck += TailSkinParts.CurrentPart.Luck;

        return luck;
    }

    private void OnPartChanged()
    {
        _skinData = new SkinData()
        {
            ColorIndex = ColorSkinParts.CurrentPart.Id,
            AccessoriesIndex = AccessoriesSkinParts.CurrentPart.Id,
            EyesIndex = EyesSkinParts.CurrentPart.Id,
            GlovesIndex = GlovesSkinParts.CurrentPart.Id,
            HeadIndex = HeadSkinParts.CurrentPart.Id,
            MouthIndex = MouthSkinParts.CurrentPart.Id,
            NoseIndex = NoseSkinParts.CurrentPart.Id,
            TailIndex = TailSkinParts.CurrentPart.Id
        };

        Changed?.Invoke();
    }
}
