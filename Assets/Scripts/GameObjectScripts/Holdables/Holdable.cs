using System;
using UnityEngine;

public abstract class Holdable : MonoBehaviour
{
    [SerializeField] protected ItemHolder _currentHolder;
    [SerializeField] private Sprite _labelSprite;

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

    public Sprite LabelSprite
    {
        get
        {
            return _labelSprite;
        }
        private set
        {
            _labelSprite = value;
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

    public void ClearCurrentHolder()
    {
        _currentHolder = null;
    }

    public void Remove()
    {
        CurrentHolder?.ClearCurrentHoldableItem();
        Destroy(gameObject);
    }

    public static CustomSandwich ConvertToCustomSandwich(Holdable convertWho)
    {
        CustomSandwich newSandwich = Instantiate(GlobalInstances.CustomSandwichInstance);

        newSandwich.ForceReplaceWithoutRemovingOldItem(convertWho.CurrentHolder);

        newSandwich.AddIngredient(convertWho);

        return newSandwich;
    }

    public static Holdable ConvertToSimpleHoldable(Holdable convertWho, Holdable convertTo)
    {
        if (convertTo.GetType() == typeof(CustomSandwich))
        {
            throw new Exception(
                "to convert holdable into custom sandwich " +
                "call ConvertToCustomSandwich()" +
                "instead of ConvertToSimpleHoldable()"
                );
        }

        Holdable newHoldable = Instantiate(convertTo);
        newHoldable.ForceReplace(convertWho.CurrentHolder);

        return newHoldable;
    }

    public static bool operator == (Holdable a, Holdable b)
    {
        return (a is null && b is null) || a?.GetType() == b?.GetType();
    }

    public static bool operator != (Holdable a, Holdable b)
    {
        return !(a == b);
    }

    public override bool Equals(object obj)
    {
        return this == (Holdable)obj;
    }

    public override int GetHashCode()
    {
        return gameObject.GetInstanceID();
    }
}
