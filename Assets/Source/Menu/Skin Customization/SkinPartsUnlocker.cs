using System;
using System.Collections.Generic;

public class SkinPartsUnlocker
{
    public event Action PurchaseNeeded;
    public event Action PurchaseCompleted;
    public event Action PurchaseCancelled;

    private Skin _skin;
    private Money _money;

    private Dictionary<SkinPartType, SkinPart> _skinPartsToUnlock;
    private UnlockedParts _unlockedParts;
    private int _totalCost;

    public int TotalCost => _totalCost;
    public bool CanPurchase => _totalCost <= _money.Value;

    public void Construct(Skin skin, Money money, UnlockedParts unlockedParts)
    {
        _skin = skin;
        _money = money;
        _unlockedParts = unlockedParts;
        _skin.Changed += OnSkinChanged;
    }

    public void Purchase()
    {
        foreach (var key in _skinPartsToUnlock.Keys)
        {
            _money.PurchaseSkinPart(_skinPartsToUnlock[key]);
            _unlockedParts.UnlockPart(key, _skinPartsToUnlock[key].Id);
        }

        PurchaseCompleted?.Invoke();
    }

    private void OnSkinChanged()
    {
        _skinPartsToUnlock = new Dictionary<SkinPartType, SkinPart>();
        _totalCost = 0;

        if (_unlockedParts.IsUnlocked(SkinPartType.Color, _skin.ColorSkinParts.CurrentPart.Id) == false)
        {
            _skinPartsToUnlock.Add(SkinPartType.Color, _skin.ColorSkinParts.CurrentPart);
            _totalCost += _skin.ColorSkinParts.CurrentPart.Cost;
        }
        if (_unlockedParts.IsUnlocked(SkinPartType.Accessories, _skin.AccessoriesSkinParts.CurrentPart.Id) == false)
        {
            _skinPartsToUnlock.Add(SkinPartType.Accessories, _skin.AccessoriesSkinParts.CurrentPart);
            _totalCost += _skin.AccessoriesSkinParts.CurrentPart.Cost;
        }
        if (_unlockedParts.IsUnlocked(SkinPartType.Eyes, _skin.EyesSkinParts.CurrentPart.Id) == false)
        {
            _skinPartsToUnlock.Add(SkinPartType.Eyes, _skin.EyesSkinParts.CurrentPart);
            _totalCost += _skin.EyesSkinParts.CurrentPart.Cost;
        }
        if (_unlockedParts.IsUnlocked(SkinPartType.Gloves, _skin.GlovesSkinParts.CurrentPart.Id) == false)
        {
            _skinPartsToUnlock.Add(SkinPartType.Gloves, _skin.GlovesSkinParts.CurrentPart);
            _totalCost += _skin.GlovesSkinParts.CurrentPart.Cost;
        }
        if (_unlockedParts.IsUnlocked(SkinPartType.Head, _skin.HeadSkinParts.CurrentPart.Id) == false)
        {
            _skinPartsToUnlock.Add(SkinPartType.Head, _skin.HeadSkinParts.CurrentPart);
            _totalCost += _skin.HeadSkinParts.CurrentPart.Cost;
        }
        if (_unlockedParts.IsUnlocked(SkinPartType.Mouth, _skin.MouthSkinParts.CurrentPart.Id) == false)
        {
            _skinPartsToUnlock.Add(SkinPartType.Mouth, _skin.MouthSkinParts.CurrentPart);
            _totalCost += _skin.MouthSkinParts.CurrentPart.Cost;
        }
        if (_unlockedParts.IsUnlocked(SkinPartType.Nose, _skin.NoseSkinParts.CurrentPart.Id) == false)
        {
            _skinPartsToUnlock.Add(SkinPartType.Nose, _skin.NoseSkinParts.CurrentPart);
            _totalCost += _skin.NoseSkinParts.CurrentPart.Cost;
        }
        if (_unlockedParts.IsUnlocked(SkinPartType.Tail, _skin.TailSkinParts.CurrentPart.Id) == false)
        {
            _skinPartsToUnlock.Add(SkinPartType.Tail, _skin.TailSkinParts.CurrentPart);
            _totalCost += _skin.TailSkinParts.CurrentPart.Cost;
        }

        if (_skinPartsToUnlock.Count > 0)
        {
            PurchaseNeeded?.Invoke();
        }
        else
        {
            PurchaseCancelled?.Invoke();
        }
    }
}
