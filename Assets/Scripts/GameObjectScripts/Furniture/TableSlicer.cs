using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class TableSlicer : ItemHolder, IInteractable, IInteractableAlt
{
    [SerializeField] private ProgressBar _progressBar;
    [SerializeField] private GameObject _childMeshWithAnimatior;
    private Animator _animator;

    const string ANIMATOR_ON_INTERACT_TRIGGER_NAME = "OnInteract";
    const string ANIMATOR_ON_INTERACT_ANIMATION_NAME = "Knife|OnInteract";

    private void Awake()
    {
        if (_childMeshWithAnimatior == null)
        {
            _animator = GetComponent<Animator>();
        }
        else
        {
            _animator = _childMeshWithAnimatior.GetComponent<Animator>();
        }
    }

    private void Start()
    {
        Player.Instance.OnInteract += Player_OnIteract;
        Player.Instance.OnInteractAlt += Player_OnIteractAlt;
    }

    void Player_OnIteractAlt(object sender, IInteractable sendTarget)
    {
        if (sendTarget == this as IInteractable)
        {
            InteractAlt();
        }
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
            _progressBar.ResetProgress();
        }
        else if (Player.Instance.CurrentHoldableItem != null)
        {
            Player.Instance.CurrentHoldableItem.Replace(this);
            if (_currentHoldableItem is SliceableHoldable)
            {
                _progressBar.Progress = (CurrentHoldableItem as SliceableHoldable).GetProgress();
            }
        }
    }

    public void InteractAlt()
    {
        if (
            CurrentHoldableItem is SliceableHoldable && 
            !_animator.GetCurrentAnimatorStateInfo(0).IsName(ANIMATOR_ON_INTERACT_ANIMATION_NAME)
            )
        {
            _animator.SetTrigger(ANIMATOR_ON_INTERACT_TRIGGER_NAME);
            SliceCurrentHoldableitem();
        }
    }

    public void SliceCurrentHoldableitem()
    {
        if (_currentHoldableItem is SliceableHoldable)
        {
            _progressBar.Progress = (_currentHoldableItem as SliceableHoldable).SliceProgress();
        }
    }
}
