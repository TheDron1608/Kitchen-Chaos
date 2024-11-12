using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToScencePreloadButton : EmptyButton
{
    [SerializeField] private string _goToScenceName;

    private void Start()
    {
        ScenePreloader.PreloadScence(_goToScenceName, LoadSceneMode.Single);
    }

    protected override void Button_OnClick()
    {
        ScenePreloader.TryLoadPreloadedScence(_goToScenceName);
        ScenePreloader.UnloadPreloadedScene(_goToScenceName);
    }
}
