using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoastableHoldable : Holdable
{
    [SerializeField] protected GameObject _roastedMesh;
    [SerializeField] protected GameObject _currentMesh;

    public bool IsRoasted { get; private set; } = false;

    public void Roast()
    {
        _currentMesh.SetActive(false);
        _roastedMesh.SetActive(true);
        IsRoasted = true;
    }
}
