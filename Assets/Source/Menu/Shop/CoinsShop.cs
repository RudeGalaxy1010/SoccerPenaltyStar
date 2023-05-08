public class CoinsShop : Shop
{
    private Dollars _dollars;
    private Coins _coins;

    public void Construct(Coins coins, Dollars dollars, ShopItemView itemViewPrefab)
    {
        _coins = coins;
        _dollars = dollars;
        Construct(itemViewPrefab);
    }

    protected override void OnItemClicked(ShopItem item)
    {
        if (item.Cost > _dollars.Value)
        {
            return;
        }

        _dollars.PurchaseItem(item);
        _coins.AddItemMoney(item);
    }
}
