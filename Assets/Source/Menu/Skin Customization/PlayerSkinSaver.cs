public class PlayerSkinSaver
{
    private Skin _playerSkin;

    public PlayerSkinSaver(Skin playerSkin)
    {
        _playerSkin = playerSkin;
        _playerSkin.Changed += OnSkinChanged;
    }

    private void OnSkinChanged()
    {
        SkinData skinData = _playerSkin.SkinData;

        if (CanSaveSkinData(skinData) == true)
        {
            DataHolder.PlayerData.PlayerSkinData = skinData;
            DataHolder.PlayerForce = _playerSkin.GetForce();
            DataHolder.PlayerAccuracy = _playerSkin.GetAccuracy();
            DataHolder.PlayerLuck = _playerSkin.GetLuck();
        }
    }

    private bool CanSaveSkinData(SkinData skinData)
    {
        UnlockedParts unlockedParts = DataHolder.PlayerData.UnlockedParts;

        return unlockedParts.IsUnlocked(SkinPartType.Color, skinData.ColorIndex)
            && unlockedParts.IsUnlocked(SkinPartType.Accessories, skinData.AccessoriesIndex)
            && unlockedParts.IsUnlocked(SkinPartType.Eyes, skinData.EyesIndex)
            && unlockedParts.IsUnlocked(SkinPartType.Gloves, skinData.GlovesIndex)
            && unlockedParts.IsUnlocked(SkinPartType.Head, skinData.HeadIndex)
            && unlockedParts.IsUnlocked(SkinPartType.Mouth, skinData.MouthIndex)
            && unlockedParts.IsUnlocked(SkinPartType.Nose, skinData.NoseIndex)
            && unlockedParts.IsUnlocked(SkinPartType.Tail, skinData.TailIndex);
    }
}
