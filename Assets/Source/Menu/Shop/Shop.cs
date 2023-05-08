using System.Collections.Generic;
using UnityEngine;

public abstract class Shop : MonoBehaviour
{
    [SerializeField] private ShopItem[] _items;
    [SerializeField] private Transform _viewsContainer;

    private ShopItemView _itemViewPrefab;
    private ShopItemView[] _itemViews;

    protected void Construct(ShopItemView itemViewPrefab)
    {
        _itemViewPrefab = itemViewPrefab;
        _itemViews = CreateItemViews();
        Subscribe();
    }

    private void OnDestroy()
    {
        Unsubscribe();
    }

    private ShopItemView[] CreateItemViews()
    {
        List<ShopItemView> views = new List<ShopItemView>();
        ShopItemView shopItemView;

        for (int i = 0; i < _items.Length; i++)
        {
            shopItemView = Instantiate(_itemViewPrefab, _viewsContainer);
            shopItemView.SetItem(_items[i]);
            views.Add(shopItemView);
        }

        return views.ToArray();
    }

    private void Subscribe()
    {
        for (int i = 0; i < _itemViews.Length; i++)
        {
            _itemViews[i].Clicked += OnItemClicked;
        }
    }

    private void Unsubscribe()
    {
        if (_itemViews == null)
        {
            return;
        }

        for (int i = 0; i < _itemViews.Length; i++)
        {
            _itemViews[i].Clicked -= OnItemClicked;
        }
    }

    protected abstract void OnItemClicked(ShopItem item);
}
