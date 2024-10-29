using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerAnimator : MonoBehaviour, IInteractable
{
    [SerializeField] private ItemSpawner _itemSpawner;
    private Animator _animator;

    private const string ANIMATOR_ONINTERACT_TRIGGER_NAME = "OnInteract";

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        Player.Instance.OnInteract += Player_OnInteract;        
    }

    void Player_OnInteract(object sender, IInteractable sendTarget)
    {
        if (sendTarget == _itemSpawner as IInteractable)
        {
            Interact();
        }
    }

    public void Interact()
    {   
        if (Player.Instance.CurrentHoldableItem == null)
        {
            _animator.SetTrigger(ANIMATOR_ONINTERACT_TRIGGER_NAME);
        }
    }
}
