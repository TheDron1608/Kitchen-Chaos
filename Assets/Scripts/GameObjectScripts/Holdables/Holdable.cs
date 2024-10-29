using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Holdable : MonoBehaviour
{
    [SerializeField] protected ItemHolder currentHolder;

    public bool Replace(ItemHolder newHolder)
    {   
        if (newHolder.CurrentHoldableItem == null)
        {   
            currentHolder?.ClearCurrentHoldableItem();
            currentHolder = newHolder;
            newHolder.SetCurrentHoldableItem(this);

            return true;
        }
        return false;
    }

    public void Remove()
    {
        currentHolder?.ClearCurrentHoldableItem();
        Destroy(gameObject);
    }
}
