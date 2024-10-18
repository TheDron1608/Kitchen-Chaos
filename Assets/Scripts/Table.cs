using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : ItemHolder, IInteractable, ISelectable
{
    [SerializeField] protected GameObject _meshSelected;
    [SerializeField] protected Material _material;
    [SerializeField] protected Material _materialSelected;
    protected MeshRenderer _meshRenderer;

    public bool IsSelected { get; protected set; }

    protected void Awake()
    {   
        _meshRenderer = _meshSelected.GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        Player.Instance.OnInteract += Player_OnIteract;
    }

    public void Select()
    {
        _meshRenderer.material = _materialSelected;
        IsSelected = true;
    }

    public void Deselect()
    {
        _meshRenderer.material = _material;
        IsSelected = false;
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
            Debug.Log("taking from " + this.name);
        }
        else if (Player.Instance.GetCurrentHoldableItem() != null)
        {
            Player.Instance.GetCurrentHoldableItem().Replace(this);
            Debug.Log("giving to " + this.name);
        }
        else
        {
            Debug.Log("doing nothing to " + this.name);
        }
    }
}
