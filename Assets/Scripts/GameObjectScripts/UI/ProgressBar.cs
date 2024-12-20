using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image _progressImage;
    protected float _progress;

    private void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
    }

    public float Progress
    {
        get
        {
            return _progress;
        }
        set
        {
            _progress = value;
            UpdateProgress();
        }
    }

    private void UpdateProgress()
    {
        _progressImage.fillAmount = _progress;
        if (_progress == 0f || _progress == 1f)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void ResetProgress()
    {
        Progress = 0f;
    }
}
