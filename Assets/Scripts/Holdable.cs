using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdable : MonoBehaviour
{
    protected ItemHolder currentHolder {  get; private set; }

    public bool Replace(ItemHolder newHolder)
    {   
        if (newHolder.GetCurrentHoldableItem() != null)
        {   
            currentHolder.ClearCurrentHoldableItem();
            transform.parent = newHolder.GetItemHolderContainer();
            newHolder.SetCurrentHoldableItem(this);

            return true;
        }
        return false;
    }
}
