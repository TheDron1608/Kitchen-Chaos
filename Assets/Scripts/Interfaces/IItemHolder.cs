using UnityEngine;

interface IItemHolder
{
    public Transform GetItemHolderContainer();

    public void ClearCurrentHoldableItem();
    public Holdable CurrentHoldableItem();
    public void SetCurrentHoldableItem(Holdable item);
}
