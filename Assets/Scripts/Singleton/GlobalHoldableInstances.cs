using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalHoldableInstances : MonoBehaviour
{
    [SerializeField] private Holdable _bananaInstance;
    [SerializeField] private RoastableHoldable _breadInstance;
    [SerializeField] private SliceableHoldable _cheeseInstance;
    [SerializeField] private CustomSandwich _customSandwichInstance;

    public static Holdable BananaInstance { get; private set; }
    public static RoastableHoldable BreadInstance { get; private set; }
    public static SliceableHoldable CheeseInstance { get; private set; }
    public static CustomSandwich CustomSandwichInstance { get; private set; }

    void Awake()
    {   
        DontDestroyOnLoad(this);

        BananaInstance = _bananaInstance;
        BreadInstance = _breadInstance;
        CheeseInstance = _cheeseInstance;
        CustomSandwichInstance = _customSandwichInstance;
    }

}
