using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomSandwich : Holdable
{
    private List<Holdable> _ingredients = new List<Holdable>();
    const float INGREDIENT_HEIGHT = 0.125f;
    [SerializeField] public CustomSandwich Instance { get; private set; }
    [SerializeField] private List<GlobalInstances.GlobalHoldablesEnum> _initialIngredients;

    public List<Holdable> Ingredients
    {
        get
        {
            return _ingredients;
        }
        set
        {
            _ingredients = value;
        }
    }

    private void Start()
    {
        Player.Instance.OnInteract += Player_OnIteract;
    }

    private void Awake()
    {
        for (int i = 0; i < _initialIngredients.Count; i++)
        {
            Ingredients.Add(GlobalInstances.GetHoldableInstance(_initialIngredients[i]));
        }
    }

    void Player_OnIteract(object sender, IInteractable sendTarget)
    {
        if (sendTarget == CurrentHolder as IInteractable)
        {
            Interact(sendTarget as ItemHolder);
        }
    }

    public void Interact(ItemHolder itemHolder)
    {
        if (itemHolder == null) return;

        if (
            itemHolder.CurrentHoldableItem == this && 
            Player.Instance.CurrentHoldableItem != null &&
            itemHolder is Table
            )
        {
            AddIngredient(Player.Instance.CurrentHoldableItem);
        }
        else if (
            Player.Instance.CurrentHoldableItem == this && 
            itemHolder.CurrentHoldableItem != null
            )
        {
            AddIngredient(itemHolder.CurrentHoldableItem);
        }
    }


    public void AddIngredient (Holdable holdableIngreditent)
    {   
        if (holdableIngreditent is CustomSandwich)
        {
            foreach (Holdable ingredient in (holdableIngreditent as CustomSandwich).Ingredients)
            {
                AddIngredient(ingredient);
            }
            holdableIngreditent.Remove();
        }
        else
        {
            holdableIngreditent.CurrentHolder?.ClearCurrentHoldableItem();
            holdableIngreditent.ClearCurrentHolder();
            holdableIngreditent.transform.parent = transform;
            holdableIngreditent.transform.localPosition = new Vector3(0, Ingredients.Count * INGREDIENT_HEIGHT, 0);

            Ingredients.Add(holdableIngreditent);
        }
    }

    public void CreateAndAddIngredient(Holdable holdableIngreditent)
    {
        AddIngredient(Instantiate(holdableIngreditent));
    }

    public void LogIngredients()
    {   
        if (Ingredients.Count == 0)
        {
            Debug.Log("no ingredients");
            return;
        }
        foreach (Holdable holdable in Ingredients)
        {
            Debug.Log(holdable);
        }
    }

    public static bool operator == (CustomSandwich a, CustomSandwich b)
    {
        if (a.Ingredients.Count != b.Ingredients.Count) return false;

        for (int i = 0; i < a.Ingredients.Count; i++)
        {
            if (a.Ingredients[i] != b.Ingredients[i]) return false;
        }

        return true;
    }

    public static bool operator != (CustomSandwich a, CustomSandwich b)
    {
        if (a.Ingredients.Count != b.Ingredients.Count) return true;

        for (int i = 0; i < a.Ingredients.Count; i++)
        {   
            if (a.Ingredients[i] != b.Ingredients[i]) return true;
        }

        return false;
        
    }

    public override bool Equals(object obj)
    {
        return this == (CustomSandwich)obj;
    }

    public override int GetHashCode()
    {
        return gameObject.GetInstanceID();
    }
}
