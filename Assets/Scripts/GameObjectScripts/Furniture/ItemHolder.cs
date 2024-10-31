using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemHolder : Furniture
{   
    [SerializeField] protected Transform _itemHolderContainer;
    [SerializeField] protected Holdable _currentHoldableItem = null;

    public Holdable CurrentHoldableItem
    {
        get
        {
            return _currentHoldableItem;
        }
        private set
        {
            _currentHoldableItem = value;
        }
    }

    public void ClearCurrentHoldableItem()
    {
        _currentHoldableItem = null;
    }
    public void SetCurrentHoldableItem(Holdable item)
    {
        _currentHoldableItem = item;
        item.transform.parent = _itemHolderContainer;
        item.transform.localPosition = Vector3.zero;
        item.transform.rotation = _itemHolderContainer.transform.rotation;
    }
}
