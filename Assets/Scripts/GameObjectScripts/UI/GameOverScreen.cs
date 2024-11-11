using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreTextContainer;

    private void Awake()
    {
        _scoreTextContainer.text += GlobalSandwichOrders.Score;
    }
}
