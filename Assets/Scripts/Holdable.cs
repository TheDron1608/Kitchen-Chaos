using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdable : MonoBehaviour
{
    [SerializeField] protected ItemHolder currentHolder;

    public bool Replace(ItemHolder newHolder)
    {   
        if (newHolder.GetCurrentHoldableItem() == null)
        {   
            currentHolder.ClearCurrentHoldableItem();
            currentHolder = newHolder;
            newHolder.SetCurrentHoldableItem(this);

            return true;
        }
        return false;
    }
}
