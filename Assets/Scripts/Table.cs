using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : ItemHolder
{
    [SerializeField] private GameObject _meshSelected;
    [SerializeField] private Material _material;
    [SerializeField] private Material _materialSelected;
    private MeshRenderer _meshRenderer;

    public bool IsSelected { get; private set; } = false;

    private void Awake()
    {
        _meshRenderer = _meshSelected.GetComponent<MeshRenderer>();
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
}
