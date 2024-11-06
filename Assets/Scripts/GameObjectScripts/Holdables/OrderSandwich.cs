using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderSandwich : CustomSandwich
{
    [SerializeField] string _name = "unnamed";

    public string Name 
    { 
        get 
        { 
            return _name; 
        } 
        private set 
        { 
            _name = value; 
        }
    }
}
