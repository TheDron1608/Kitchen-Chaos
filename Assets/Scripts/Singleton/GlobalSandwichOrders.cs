using System.Collections.Generic;
using UnityEngine;

public class GlobalSandwichOrders : MonoBehaviour
{
    [SerializeField] private GameObject _initialSandwichOrderContainer;

    private static List<OrderSandwich> _sandwichOrders = new List<OrderSandwich>();
    private static List<OrderSandwich> _currentSandwichOrders = new List<OrderSandwich>();
    private static int _level = 0;
    private static GameObject _sandwichOrderContainer;
    private static int _score = 0;

    public static GameObject SandwichorderContainer
    {
        get
        {
            return _sandwichOrderContainer;
        }
        private set
        {
            _sandwichOrderContainer = value;
        }
    }

    public static int Score
    {
        get
        {
            return _score;
        }
        private set
        {
            _score = value;
        }
    }

    private void Awake()
    {
        _sandwichOrderContainer = _initialSandwichOrderContainer;

        foreach (Transform obj in transform)
        {
            _sandwichOrders.Add(obj.GetComponent<OrderSandwich>());
        }
    }

    private void Start()
    {
        CreateNewOrder();
        CreateNewOrder();
        CreateNewOrder();
        RefreshOrdersListUI();
    }

    public static void CreateNewOrder()
    {
        _currentSandwichOrders.Add(_sandwichOrders[_level]);
        _level = (_level + 1) % (_sandwichOrders.Count);
    }

    public static CustomSandwich GetCurrentOrderedSandwich()
    {
        return _sandwichOrders[_level];
    }

    public static bool VerifySandwich (CustomSandwich sandwich)
    {
        for (int i = 0; i < _currentSandwichOrders.Count; i++)
        {
            if ((_currentSandwichOrders[i] as CustomSandwich) == sandwich)
            {
                _currentSandwichOrders.RemoveAt(i);
                CreateNewOrder();
                RefreshOrdersListUI();
                Score++;
                return true;
            }
        }
        return false;
    }

    public static void RefreshOrdersListUI()
    {
        foreach (Transform child in _sandwichOrderContainer.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        for (int i = 0; i < _currentSandwichOrders.Count; i++)
        {
            SandwichOrder.CreateNewSandwichOrder(_currentSandwichOrders[i]);
        }
    }
}
