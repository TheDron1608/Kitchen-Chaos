using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SliceableHoldable : Holdable
{
    [SerializeField] private int _baseSlicesAmount;
    [SerializeField] private bool _sliceOnStart = false;
    private int _slicesLeft;

    private void Start()
    {
        if (_sliceOnStart)
        {
            _slicesLeft = 0;
            SliceFinish();
        }
        else { 
            _slicesLeft = _baseSlicesAmount;
        }
    }

    public float SliceProgress()
    {
        float progressResult = 0f;
        if (_slicesLeft > 0)
        {
            _slicesLeft--;
            progressResult = GetProgress();
            if (_slicesLeft == 0 )
            {
                SliceFinish();
            }
        }
        return progressResult;
    }

    protected void SliceFinish()
    {
        Holdable.ConvertToSimpleHoldable(this, GlobalInstances.SlicedCheeseInstance);
    }

    public float GetProgress()
    {
        return (float)(_baseSlicesAmount - _slicesLeft) / _baseSlicesAmount;
    }
}
