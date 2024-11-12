using UnityEngine;

public class QuitButton : EmptyButton
{
    protected override void Button_OnClick()
    {
        Application.Quit();
        Debug.Log("quit program");
    }
}
