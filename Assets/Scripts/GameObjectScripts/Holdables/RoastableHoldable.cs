using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RoastableHoldable : Holdable
{
    [SerializeField] protected GameObject _roastedMesh;
    [SerializeField] protected GameObject _currentMesh;

    public void Roast()
    {
        Holdable.ConvertToSimpleHoldable(this, GlobalHoldableInstances.ToastedBreadInstance);
    }
}
