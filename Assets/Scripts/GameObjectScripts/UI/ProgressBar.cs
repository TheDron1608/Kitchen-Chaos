using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField] private Image _progressImage;
    protected float _progress;

    private void Update()
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
            _progressImage.fillAmount = _progress;
            if (_progress < 0.02f || _progress > 0.98f)
            {
                Hide();
            }
            else
            {
                Show();
            }
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
}
