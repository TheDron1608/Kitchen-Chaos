using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalHoldableInstances : MonoBehaviour
{
    [SerializeField] private Banana _bananaInstance;
    [SerializeField] private Bread _breadInstance;
    [SerializeField] private ToastedBread _toastedBreadInstance;
    [SerializeField] private Cheese _cheeseInstance;
    [SerializeField] private SlicedCheese _slicedCheeseInstance;
    [SerializeField] private CustomSandwich _customSandwichInstance;

    public static Banana BananaInstance { get; private set; }
    public static Bread BreadInstance { get; private set; }
    public static ToastedBread ToastedBreadInstance { get; private set; }
    public static Cheese CheeseInstance { get; private set; }
    public static SlicedCheese SlicedCheeseInstance { get; private set; }
    public static CustomSandwich CustomSandwichInstance { get; private set; }

    void Awake()
    {
        DontDestroyOnLoad(this);

        BananaInstance = _bananaInstance;
        BreadInstance = _breadInstance;
        ToastedBreadInstance = _toastedBreadInstance;
        CheeseInstance = _cheeseInstance;
        SlicedCheeseInstance = _slicedCheeseInstance;
        CustomSandwichInstance = _customSandwichInstance;
    }

    public enum GlobalHoldablesEnum
    {
        None,
        Banana,
        Bread,
        ToastedBread,
        Cheese,
        SlicedCheese,
        CustomSandwich,
    }

    public static Holdable GetHoldableInstance(GlobalHoldablesEnum item)
    {
        switch (item)
        {
            case GlobalHoldablesEnum.Banana: 
                return BananaInstance; 
            case GlobalHoldablesEnum.Bread: 
                return BreadInstance;
            case GlobalHoldablesEnum.ToastedBread:
                return ToastedBreadInstance;
            case GlobalHoldablesEnum.Cheese:
                return CheeseInstance;
            case GlobalHoldablesEnum.SlicedCheese:
                return SlicedCheeseInstance;
            case GlobalHoldablesEnum.CustomSandwich:
                return CustomSandwichInstance;
            default:
                return null;
        }
    }
}
