using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToSceneWithButton : EmptyButton
{
    [SerializeField] private string _goToScenceName;

    protected override void Button_OnClick()
    {
        SceneManager.LoadScene(_goToScenceName);
    }
}
