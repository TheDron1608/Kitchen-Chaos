using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceableHoldable : Holdable
{
    [SerializeField] protected GameObject _slicedMesh;
    [SerializeField] protected GameObject _currentMesh;
    [SerializeField] private int _baseSlicesAmount;
    private int _slicesLeft;

    private void Start()
    {
        _slicesLeft = _baseSlicesAmount;
    }

    public bool IsSliced { get; private set; } = false;

    public void SliceProgress()
    {
        if (!IsSliced)
        {
            _slicesLeft--;
            if (_slicesLeft <= 0 )
            {
                SliceFinish();
            }
        }
    }

    protected void SliceFinish()
    {
        _currentMesh.SetActive(false);
        _slicedMesh.SetActive(true);
        IsSliced = true;
    }

    public float GetProgress()
    {
        return (float)(_baseSlicesAmount - _slicesLeft) / _baseSlicesAmount;
    }
}
