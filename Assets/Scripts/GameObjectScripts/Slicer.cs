using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class Slicer : Furniture, IInteractable
{
    [SerializeField] private Table _table;
    private Animator _animator;

    const string ANIMATOR_ON_INTERACT_TRIGGER_NAME = "OnInteract";
    const string ANIMATOR_ON_INTERACT_ANIMATION_NAME = "Knife|OnInteract";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Player.Instance.OnInteractAlt += Player_OnIteractAlt;
    }

    void Player_OnIteractAlt(object sender, IInteractable sendTarget)
    {
        if (sendTarget == _table as IInteractable)
        {
            Interact();
        }
    }

    public void Interact()
    {
        Debug.Log(_animator.GetCurrentAnimatorStateInfo(0).IsName(ANIMATOR_ON_INTERACT_ANIMATION_NAME));
        if (!(_table.GetCurrentHoldableItem() as SliceableHoldable).IsSliced && !_animator.GetCurrentAnimatorStateInfo(0).IsName(ANIMATOR_ON_INTERACT_ANIMATION_NAME))
        {
            _animator.SetTrigger(ANIMATOR_ON_INTERACT_TRIGGER_NAME);
            _table.SliceCurrentHoldableitem();
        }
    }
}
