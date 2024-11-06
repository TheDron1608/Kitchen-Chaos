using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GlobalSandwichOrders : MonoBehaviour
{
    private static List<OrderSandwich> _sandwichOrders = new List<OrderSandwich>();
    private static int _level = 0;

    private void Awake()
    {
        foreach (Transform obj in transform)
        {
            _sandwichOrders.Add(obj.GetComponent<OrderSandwich>());
        }
    }

    public static void LevelUp()
    {
        _level = (_level + 1) % (_sandwichOrders.Count);
    }

    public static CustomSandwich GetCurrentOrderedSandwich()
    {
        return _sandwichOrders[_level];
    }
}
