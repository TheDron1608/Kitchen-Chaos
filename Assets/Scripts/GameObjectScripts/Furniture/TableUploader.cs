using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableUploader : Furniture, IInteractable
{
    public static CustomSandwich CurrentRequiredSandwich { get; private set; }

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
        if (
            Player.Instance.CurrentHoldableItem != null
            )
        {   
            if (Player.Instance.CurrentHoldableItem is CustomSandwich && GlobalSandwichOrders.VerifySandwich(Player.Instance.CurrentHoldableItem as CustomSandwich))
            {
                Player.Instance.CurrentHoldableItem.Remove();
                GlobalSoundManager.PlaySoundAt(GlobalSoundManager.GlobalSoundEnum.Success, transform.position);
            }
            else
            {
                GlobalSoundManager.PlaySoundAt(GlobalSoundManager.GlobalSoundEnum.Fail, transform.position);
            }
        }
    }
}
