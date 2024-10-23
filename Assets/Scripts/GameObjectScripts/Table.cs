using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : ItemHolder, IInteractable
{
    private void Start()
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
        if (_currentHoldableItem != null)
        {
            _currentHoldableItem.Replace(Player.Instance);
            Debug.Log("taking from " + this.name);
        }
        else if (Player.Instance.GetCurrentHoldableItem() != null)
        {
            Player.Instance.GetCurrentHoldableItem().Replace(this);
            Debug.Log("giving to " + this.name);
        }
        else
        {
            Debug.Log("doing nothing to " + this.name);
        }
    }
}
