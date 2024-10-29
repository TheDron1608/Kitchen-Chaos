using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBin : Furniture, IInteractable
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
        if (Player.Instance.CurrentHoldableItem != null)
        {
            Player.Instance.CurrentHoldableItem.Remove();
        }
    }
}
