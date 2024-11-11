using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class StartTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _startTimerText;

    private float _timeLengthSeconds;
    private float _timeLeftSeconds;

    public void StartTimerSeconds(float seconds)
    {
        _timeLengthSeconds = seconds;
        _timeLeftSeconds = seconds;
    }

    private void Update()
    {
        _timeLeftSeconds -= Time.deltaTime;
        _startTimerText.text = math.ceil(_timeLeftSeconds).ToString();
        if ( _timeLeftSeconds < 0 )
        {
            Destroy(gameObject);
        }
    }

    public float GetTimeLeft()
    {
        return _timeLeftSeconds;
    }
}
