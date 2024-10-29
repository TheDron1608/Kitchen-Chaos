using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemHolder : Furniture
{
    [SerializeField] protected Transform _itemHolderContainer;
    [SerializeField] protected Holdable _currentHoldableItem = null;
    [SerializeField] protected bool _removeRotationOfitemWhenReplace = false;

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
        item.transform.parent = _itemHolderContainer;
        item.transform.localPosition = Vector3.zero;
        if (_removeRotationOfitemWhenReplace)
        {
            item.transform.rotation = _itemHolderContainer.transform.rotation;
        }
    }
    public void SliceCurrentHoldableitem()
    {
        if (_currentHoldableItem != null && _currentHoldableItem is SliceableHoldable)
        {
            (_currentHoldableItem as SliceableHoldable).SliceProgress();
        }
    }
}
