using UnityEngine;
using UnityEngine.UI;

public abstract class EmptyButton : MonoBehaviour
{
    [SerializeField] private Button _button;

    private void Awake()
    {
        _button.onClick.AddListener(Button_OnClick);
    }

    protected abstract void Button_OnClick();
}
