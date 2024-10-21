using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelectableItemHolder : ItemHolder, ISelectable
{
    [SerializeField] protected GameObject _mesh;
    [SerializeField] protected Material _material;
    [SerializeField] protected Material _materialSelected;
    protected MeshRenderer _meshRenderer;

    protected bool _isSelected;

    protected void Awake()
    {
        _meshRenderer = _mesh.GetComponent<MeshRenderer>();
    }

    public void Select()
    {
        _meshRenderer.material = _materialSelected;
        _isSelected = true;
        Debug.Log("selected " + this.name);
    }

    public void Deselect()
    {   
        _meshRenderer.material = _material;
        _isSelected = false;
        Debug.Log("deselected " + this.name);
    }

    public bool GetSelected()
    {
        return _isSelected;
    }
}
