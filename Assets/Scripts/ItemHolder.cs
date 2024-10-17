using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemHolder : MonoBehaviour
{
    [SerializeField] protected Transform _itemHolderContainer;

    protected Holdable _currentHoldableItem;

    public Transform GetItemHolderContainer()
    {
        return _itemHolderContainer;
    }

    public void ClearCurrentHoldableItem()
    {
        _currentHoldableItem = null;
    }
    public Holdable GetCurrentHoldableItem()
    {
        return _currentHoldableItem;
    }
    public void SetCurrentHoldableItem(Holdable item)
    {
        _currentHoldableItem = item;
    }
}
