using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEditor.Rendering;

public class SandwichOrder : MonoBehaviour
{
    [SerializeField] private GameObject _orderName;
    [SerializeField] private GameObject _ingredietsContainer;
    [SerializeField] private GameObject _defaultImageSample;

    public void LoadOrder (OrderSandwich sandwich)
    {
        if (_orderName.TryGetComponent<TMP_Text>(out TMP_Text orderNameText))
        {
            orderNameText.text = sandwich.Name;
        }
        else
        {
            throw new System.Exception("couldn't get TMP_Text component in orderSandwich UI");
        }

        for (int i = 0; i < sandwich.Ingredients.Count; i++)
        {
            GameObject newIngredientLabel = Instantiate(_defaultImageSample, _ingredietsContainer.transform);

            if (newIngredientLabel.TryGetComponent<UnityEngine.UI.Image>(out UnityEngine.UI.Image newIngredientImage))
            {
                newIngredientImage.sprite = sandwich.Ingredients[i].LabelSprite;
            }
            else
            {
                throw new System.Exception("couldn't get UnityEngine.UI.Image component from sandwichOrder UI");
            }
        }
    }

    public static void CreateNewSandwichOrder(OrderSandwich sandwich)
    {
        SandwichOrder newSandwichOrder = Instantiate(GlobalInstances.SandwichOrderInstance, GlobalSandwichOrders.SandwichorderContainer.transform);
        newSandwichOrder.LoadOrder(sandwich);
    }
}
