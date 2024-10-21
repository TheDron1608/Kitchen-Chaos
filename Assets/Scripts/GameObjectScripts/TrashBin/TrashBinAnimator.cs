using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBinAnimator : MonoBehaviour, IInteractable
{
    [SerializeField] private TrashBin _trashBin;
    private Animator _animator;

    private const string ANIMATOR_ONINTERACT_TRIGGER_NAME = "OnInteract";
    private const string ANIMATOR_ONINTERACT_STATE_NAME = "ItemHolderContainer|OnInteract";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Player.Instance.OnInteract += Player_OnInteract;
        //_animator.
    }

    void Player_OnInteract(object sender, IInteractable sendTarget)
    {
        if (sendTarget == _trashBin as IInteractable)
        {
            Interact();
        }
    }

    public void Interact()
    {
        if (Player.Instance.GetCurrentHoldableItem() == null)
        {   
            _animator.SetTrigger(ANIMATOR_ONINTERACT_TRIGGER_NAME);
        }
    }
}
