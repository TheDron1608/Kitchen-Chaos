using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliceableHoldable : Holdable
{
    [SerializeField] protected GameObject _slicedMesh;
    [SerializeField] protected GameObject _currentMesh;
    [SerializeField] protected int BaseSlicesAmount;
    protected int _slicesLeft;

    private void Start()
    {
        _slicesLeft = BaseSlicesAmount;
    }

    public bool IsSliced { get; private set; } = false;

    public void SliceProgress()
    {
        if (!IsSliced)
        {
            _slicesLeft--;
            if (_slicesLeft == 0 )
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
}
