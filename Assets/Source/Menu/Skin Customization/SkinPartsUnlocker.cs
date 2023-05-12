using System;
using System.Collections.Generic;

public class SkinPartsUnlocker
{
    private const string UnknownCostTypeExceptionMessage = "Unknown cost type";

    public event Action PurchaseNeeded;
    public event Action PurchaseCompleted;
    public event Action PurchaseCancelled;

    private Skin _skin;
    private Coins _coins;
    private Dollars _dollars;

    private Dictionary<SkinPartType, SkinPart> _skinPartsToUnlock;
    private UnlockedParts _unlockedParts;
    private int _totalCoinsCost;
    private int _totalDollarsCost;
    private int _totalAdsCost;

    public int TotalCoinsCost => _totalCoinsCost;
    public int TotalDollarsCost => _totalDollarsCost;
    public int TotalAdsCost => _totalAdsCost;
    public bool CanPurchase => _totalCoinsCost <= _coins.Value && _totalDollarsCost <= _dollars.Value;
    public bool HasLockedParts => _totalCoinsCost > 0 || _totalDollarsCost > 0 || _totalAdsCost > 0;

    public void Construct(Skin skin, Coins coins, Dollars dollars, UnlockedParts unlockedParts)
    {
        _skin = skin;
        _coins = coins;
        _dollars = dollars;
        _unlockedParts = unlockedParts;
        _skin.Changed += OnSkinChanged;
    }

    public void Purchase()
    {
        if (CanPurchase == false)
        {
            return;
        }

        foreach (var key in _skinPartsToUnlock.Keys)
        {
            Purchase(_skinPartsToUnlock[key]);
            _unlockedParts.UnlockPart(key, _skinPartsToUnlock[key].Id);
        }

        ResetCurrentPartsData();
        PurchaseCompleted?.Invoke();
    }

    private void Purchase(SkinPart skinPart)
    {
        switch (skinPart.CostType)
        {
            case CostType.Coins: _coins.PurchaseSkinPart(skinPart);
                break;
            case CostType.Dollars: _dollars.PurchaseSkinPart(skinPart);
                break;
            case CostType.Ads: // TODO: Call ADs function
                break;
            default:
                throw new ArgumentException(UnknownCostTypeExceptionMessage);
        }
    }

    private void OnSkinChanged()
    {
        ResetCurrentPartsData();

        if (_unlockedParts.IsUnlocked(SkinPartType.Color, _skin.ColorSkinParts.CurrentPart.Id) == false)
        {
            _skinPartsToUnlock.Add(SkinPartType.Color, _skin.ColorSkinParts.CurrentPart);
            AddCost(_skin.ColorSkinParts.CurrentPart);
        }
        if (_unlockedParts.IsUnlocked(SkinPartType.Accessories, _skin.AccessoriesSkinParts.CurrentPart.Id) == false)
        {
            _skinPartsToUnlock.Add(SkinPartType.Accessories, _skin.AccessoriesSkinParts.CurrentPart);
            AddCost(_skin.AccessoriesSkinParts.CurrentPart);
        }
        if (_unlockedParts.IsUnlocked(SkinPartType.Eyes, _skin.EyesSkinParts.CurrentPart.Id) == false)
        {
            _skinPartsToUnlock.Add(SkinPartType.Eyes, _skin.EyesSkinParts.CurrentPart);
            AddCost(_skin.EyesSkinParts.CurrentPart);
        }
        if (_unlockedParts.IsUnlocked(SkinPartType.Gloves, _skin.GlovesSkinParts.CurrentPart.Id) == false)
        {
            _skinPartsToUnlock.Add(SkinPartType.Gloves, _skin.GlovesSkinParts.CurrentPart);
            AddCost(_skin.GlovesSkinParts.CurrentPart);
        }
        if (_unlockedParts.IsUnlocked(SkinPartType.Head, _skin.HeadSkinParts.CurrentPart.Id) == false)
        {
            _skinPartsToUnlock.Add(SkinPartType.Head, _skin.HeadSkinParts.CurrentPart);
            AddCost(_skin.HeadSkinParts.CurrentPart);
        }
        if (_unlockedParts.IsUnlocked(SkinPartType.Mouth, _skin.MouthSkinParts.CurrentPart.Id) == false)
        {
            _skinPartsToUnlock.Add(SkinPartType.Mouth, _skin.MouthSkinParts.CurrentPart);
            AddCost(_skin.MouthSkinParts.CurrentPart);
        }
        if (_unlockedParts.IsUnlocked(SkinPartType.Nose, _skin.NoseSkinParts.CurrentPart.Id) == false)
        {
            _skinPartsToUnlock.Add(SkinPartType.Nose, _skin.NoseSkinParts.CurrentPart);
            AddCost(_skin.NoseSkinParts.CurrentPart);
        }
        if (_unlockedParts.IsUnlocked(SkinPartType.Tail, _skin.TailSkinParts.CurrentPart.Id) == false)
        {
            _skinPartsToUnlock.Add(SkinPartType.Tail, _skin.TailSkinParts.CurrentPart);
            AddCost(_skin.TailSkinParts.CurrentPart);
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

    private void AddCost(SkinPart skinPart)
    {
        switch (skinPart.CostType) 
        {
            case CostType.Coins: _totalCoinsCost += skinPart.Cost;
                break;
            case CostType.Dollars: _totalDollarsCost += skinPart.Cost;
                break;
            case CostType.Ads: _totalAdsCost++;
                break;
            default:
                throw new ArgumentException(UnknownCostTypeExceptionMessage);
        }
    }

    private void ResetCurrentPartsData()
    {
        _skinPartsToUnlock = new Dictionary<SkinPartType, SkinPart>();
        _totalCoinsCost = 0;
        _totalDollarsCost = 0;
        _totalAdsCost = 0;
    }
}
