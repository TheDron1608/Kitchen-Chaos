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
        Holdable.ConvertToSimpleHoldable(this, GlobalInstances.ToastedBreadInstance);
    }
}
