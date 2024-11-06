using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableUploader : Furniture, IInteractable
{
    public static CustomSandwich CurrentRequiredSandwich { get; private set; }

    private void Start()
    {
        Player.Instance.OnInteract += Player_OnIteract;
        GlobalSandwichOrders.GetCurrentOrderedSandwich().LogIngredients();
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
        if (
            Player.Instance.CurrentHoldableItem != null &&
            Player.Instance.CurrentHoldableItem is CustomSandwich &&
            (Player.Instance.CurrentHoldableItem as CustomSandwich) == GlobalSandwichOrders.GetCurrentOrderedSandwich()
            )
        {
            Player.Instance.CurrentHoldableItem.Remove();
            GlobalSandwichOrders.LevelUp();

            Debug.Log("UPLOADED SUCCESSFULLY");
            GlobalSandwichOrders.GetCurrentOrderedSandwich().LogIngredients();
        }
    }
}
