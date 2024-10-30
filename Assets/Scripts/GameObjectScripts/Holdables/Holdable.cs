using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Holdable : MonoBehaviour
{
    [SerializeField] protected ItemHolder _currentHolder;

    public ItemHolder CurrentHolder
    {
        get
        {
            return _currentHolder;
        }
        private set
        {
            _currentHolder = value;
        }
    }


    public bool Replace(ItemHolder newHolder)
    {   
        if (newHolder.CurrentHoldableItem == null)
        {   
            CurrentHolder?.ClearCurrentHoldableItem();
            CurrentHolder = newHolder;
            newHolder.SetCurrentHoldableItem(this);

            return true;
        }
        return false;
    }

    public void ForceReplace(ItemHolder newHolder)
    {
        newHolder.CurrentHoldableItem.Remove();
        Replace(newHolder);
    }

    public void ForceReplaceWithoutRemovingOldItem(ItemHolder newHolder)
    {
        newHolder.ClearCurrentHoldableItem();
        Replace(newHolder);
    }

    public void Remove()
    {
        CurrentHolder?.ClearCurrentHoldableItem();
        Destroy(gameObject);
    }

    public static CustomSandwich ConvertToCustomSandwich(Holdable convertWho)
    {
        CustomSandwich newSandwich = Instantiate(GlobalHoldableInstances.CustomSandwichInstance);

        newSandwich.ForceReplaceWithoutRemovingOldItem(convertWho.CurrentHolder);

        newSandwich.AddIngredient(convertWho);

        return newSandwich;
    }
}
