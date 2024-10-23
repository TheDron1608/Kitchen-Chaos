using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectableMesh : MonoBehaviour
{
    [SerializeField] private Furniture _selectableParent;
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Material _selectMaterial;
    private MeshRenderer _meshRenderer;

    private void Start()
    {
        Player.Instance.OnReSelect += Player_OnReSelect;
    }

    private void Awake()
    {
        _meshRenderer = gameObject.GetComponent<MeshRenderer>();
    }

    private void Player_OnReSelect(object sender, PlayerReSelectEventArgs e)
    {
        if (e.oldSelected != null && e.oldSelected == _selectableParent)
        {
            Deselect();
        }
        else if (e.newSelected != null && e.newSelected == _selectableParent)
        {
            Select();
        }
    }

    private void Select()
    {
        _meshRenderer.material = _selectMaterial;
    }

    private void Deselect()
    {
        _meshRenderer.material = _defaultMaterial;
    }
}
