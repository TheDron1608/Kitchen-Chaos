using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class ClockTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _progressText;
    [SerializeField] private Image _progressImage;

    private float _timeLengthSeconds;
    private float _timeLeftSeconds;

    private bool _isCountingDown = false;

    public void SetTimer(float seconds)
    {
        _timeLengthSeconds = seconds;
        _timeLeftSeconds = seconds;
        UpdateDisplay();
    }

    public void StartTimer()
    {
        _isCountingDown = true;
    }
    public void StopTimer()
    {
        _isCountingDown = false;
    }

    private void Update()
    {
        if (_isCountingDown)
        {
            _timeLeftSeconds -= Time.deltaTime;
            if (_timeLeftSeconds < 0)
            {
                Destroy(gameObject);
            }
            UpdateDisplay();
        }
    }

    private void UpdateDisplay()
    {
        _progressImage.fillAmount = _timeLeftSeconds / _timeLengthSeconds;
        _progressText.text = math.ceil(_timeLeftSeconds).ToString();
    }

    public float GetTimeLeft()
    {
        return _timeLeftSeconds;
    }
}
