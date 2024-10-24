using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : Selectable, IInteractable
{
    [SerializeField] public Holdable createItem;
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
        if (Player.Instance.GetCurrentHoldableItem() == null)
        {
            Holdable newItem = Instantiate(createItem);
            newItem.Replace(Player.Instance);
            Debug.Log("taking from " + this.name + " new spawned item " + newItem.name);
        }
    }
}
