using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RoastableHoldable : Holdable
{
    [SerializeField] private bool _roastOnStart = false;

    private void Start()
    {
        if (_roastOnStart)
        {
            Roast();
        }
    }

    public void Roast()
    {
        Holdable.ConvertToSimpleHoldable(this, GlobalHoldableInstances.ToastedBreadInstance);
    }
}
