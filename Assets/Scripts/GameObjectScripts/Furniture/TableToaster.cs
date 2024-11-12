using System.Collections;
using UnityEngine;

public class TableToaster : ItemHolder, IInteractable
{
    [SerializeField] private const float ROAST_TIME_SECONDS = 5f;
    [SerializeField] private ProgressBarTimer _progressBarTimer;
    private Coroutine _currentRoastCoroutine;

    private void Start()
    {
        Player.Instance.OnInteract += Player_OnIteract;
        _progressBarTimer.TimeLengthSeconds = ROAST_TIME_SECONDS;
    }

    void Player_OnIteract(object sender, IInteractable sendTarget)
    {
        if (sendTarget == this as IInteractable)
        {
            Interact();
        }
    }

    public void Interact()
    {   
        if (_currentHoldableItem != null)
        {
            _currentHoldableItem.Replace(Player.Instance);
            _progressBarTimer.Resetimer();
            StopCoroutine(_currentRoastCoroutine);
        }
        else if (Player.Instance.CurrentHoldableItem is RoastableHoldable)
        {
            Player.Instance.CurrentHoldableItem.Replace(this);
            _currentRoastCoroutine = StartCoroutine(FinishRoasting());
            _progressBarTimer.StartTimer();
        }
    }

    private IEnumerator FinishRoasting()
    {
        yield return new WaitForSeconds(ROAST_TIME_SECONDS);
        (_currentHoldableItem as RoastableHoldable).Roast();
    }
}
