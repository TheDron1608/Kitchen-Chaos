using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableUploader : Furniture, IInteractable
{
    public static CustomSandwich CurrentRequiredSandwich { get; private set; }

    private void Start()
    {
        Player.Instance.OnInteract += Player_OnIteract;
        CreateNewRequiredSandwich(1);
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
            (Player.Instance.CurrentHoldableItem as CustomSandwich) == CurrentRequiredSandwich
            )
        {
            Player.Instance.CurrentHoldableItem.Remove();
        }
    }

    public static void CreateNewRequiredSandwich (int difficulty)
    {   
        CurrentRequiredSandwich?.Remove();

        CustomSandwich newOrderedSandwich = Instantiate(GlobalHoldableInstances.CustomSandwichInstance);
        newOrderedSandwich.CreateAndAddIngredient(GlobalHoldableInstances.BreadInstance);
        newOrderedSandwich.CreateAndAddIngredient(GlobalHoldableInstances.BananaInstance);
        newOrderedSandwich.CreateAndAddIngredient(GlobalHoldableInstances.BreadInstance);
        newOrderedSandwich.gameObject.SetActive(false);

        CurrentRequiredSandwich = newOrderedSandwich;
    }
}
