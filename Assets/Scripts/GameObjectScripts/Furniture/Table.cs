using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : ItemHolder, IInteractable
{
    protected void Start()
    {
        Player.Instance.OnInteract += Player_OnIteract;
    }

    void Player_OnIteract(object sender, IInteractable sendTarget)
    {
        if (sendTarget == this as IInteractable)
        {
            Interact();
        }
    }

    public void Interact()
    {
        if (_currentHoldableItem != null && Player.Instance.CurrentHoldableItem == null)
        {
            _currentHoldableItem.Replace(Player.Instance);
        }
        else if (_currentHoldableItem == null && Player.Instance.CurrentHoldableItem != null)
        {
            Player.Instance.CurrentHoldableItem.Replace(this);
        }
        else if (_currentHoldableItem != null && Player.Instance.CurrentHoldableItem != null)
        {   
            if (!(_currentHoldableItem is CustomSandwich))
            {
                _currentHoldableItem = Holdable.ConvertToCustomSandwich(CurrentHoldableItem);
            }
            (CurrentHoldableItem as CustomSandwich).AddIngredient(Player.Instance.CurrentHoldableItem);
        }
    }
}
