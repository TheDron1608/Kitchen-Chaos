using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GlobalInstances : MonoBehaviour
{
    [Header("holdables")]
    [SerializeField] private Banana _bananaInstance;
    [SerializeField] private Bread _breadInstance;
    [SerializeField] private ToastedBread _toastedBreadInstance;
    [SerializeField] private Cheese _cheeseInstance;
    [SerializeField] private SlicedCheese _slicedCheeseInstance;
    [SerializeField] private CustomSandwich _customSandwichInstance;
    [Header("sprites")]
    [SerializeField] private Sprite _bananaInstanceSprite;
    [SerializeField] private Sprite _breadInstanceSprite;
    [SerializeField] private Sprite _toastedBreadInstanceSprite;
    [SerializeField] private Sprite _cheeseInstanceSprite;
    [SerializeField] private Sprite _slicedCheeseInstanceSprite;
    [SerializeField] private Sprite _customSandwichInstanceSprite;
    [Header("ui")]
    [SerializeField] private SandwichOrder _sandwichOrderInstance;

    public static Banana BananaInstance { get; private set; }
    public static Bread BreadInstance { get; private set; }
    public static ToastedBread ToastedBreadInstance { get; private set; }
    public static Cheese CheeseInstance { get; private set; }
    public static SlicedCheese SlicedCheeseInstance { get; private set; }
    public static CustomSandwich CustomSandwichInstance { get; private set; }

    public static Sprite BananaInstanceSprite { get; private set; }
    public static Sprite BreadInstanceSprite { get; private set; }
    public static Sprite ToastedBreadInstanceSprite { get; private set; }
    public static Sprite CheeseInstanceSprite { get; private set; }
    public static Sprite SlicedCheeseInstanceSprite { get; private set; }

    public static SandwichOrder SandwichOrderInstance { get; private set; }

    void Awake()
    {
        DontDestroyOnLoad(this);

        BananaInstance = _bananaInstance;
        BreadInstance = _breadInstance;
        ToastedBreadInstance = _toastedBreadInstance;
        CheeseInstance = _cheeseInstance;
        SlicedCheeseInstance = _slicedCheeseInstance;
        CustomSandwichInstance = _customSandwichInstance;

        BananaInstanceSprite = _bananaInstanceSprite;
        BreadInstanceSprite = _breadInstanceSprite;
        ToastedBreadInstanceSprite = _toastedBreadInstanceSprite;
        CheeseInstanceSprite = _cheeseInstanceSprite;
        SlicedCheeseInstanceSprite = _slicedCheeseInstanceSprite;
        SandwichOrderInstance = _sandwichOrderInstance;
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

    public static Sprite GetHoldableInstanceSprite(GlobalHoldablesEnum item)
    {
        switch (item)
        {
            case GlobalHoldablesEnum.Banana:
                return BananaInstanceSprite;
            case GlobalHoldablesEnum.Bread:
                return BreadInstanceSprite;
            case GlobalHoldablesEnum.ToastedBread:
                return ToastedBreadInstanceSprite;
            case GlobalHoldablesEnum.Cheese:
                return CheeseInstanceSprite;
            case GlobalHoldablesEnum.SlicedCheese:
                return SlicedCheeseInstanceSprite;
            default:
                return null;
        }
    }
}
