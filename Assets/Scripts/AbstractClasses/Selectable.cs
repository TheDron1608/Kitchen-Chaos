/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Selectable : MonoBehaviour, ISelectable
{
    [SerializeField] protected List<GameObject> _meshes;
    [SerializeField] protected Material _material;
    [SerializeField] protected Material _materialSelected;
    protected List<MeshRenderer> _meshRenderers;

    protected bool _isSelected;

    protected void Awake()
    {   
        _meshRenderers = new List<MeshRenderer>();
        foreach (GameObject gameObject in _meshes)
        {
            _meshRenderers.Add(gameObject.GetComponent<MeshRenderer>());
        }
    }

    public void Select()
    {
        foreach (MeshRenderer meshRenderer in _meshRenderers)
        {
            meshRenderer.material = _materialSelected;
        }
        _isSelected = true;
        Debug.Log("selected " + this.name);
    }

    public void Deselect()
    {
        foreach (MeshRenderer meshRenderer in _meshRenderers)
        {
            meshRenderer.material = _material;
        }
        _isSelected = false;
        Debug.Log("deselected " + this.name);
    }

    public bool GetSelected()
    {
        return _isSelected;
    }
}
*/