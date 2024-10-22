using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : Selectable, IInteractable
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
        Debug.Log("interacted with " + name);
        if (Player.Instance.GetCurrentHoldableItem() != null)
        {
            Player.Instance.GetCurrentHoldableItem().Remove();
        }
    }
}
