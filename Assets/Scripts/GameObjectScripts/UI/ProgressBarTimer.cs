using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressBarTimer : ProgressBar
{
    public float TimeLeftSeconds { get; private set; } = 0f;
    public bool Enabled { get; private set; } = false;
    [SerializeField] public float TimeLengthSeconds = 1f;

    void Update()
    {   
        if (TimeLeftSeconds >= TimeLengthSeconds)
        {
            Resetimer();
        }
        if (Enabled)
        {
            TimeLeftSeconds += Time.deltaTime;
        }
        Progress = TimeLeftSeconds / TimeLengthSeconds;
    }

    public void StartTimer()
    {
        Show();
        Enabled = true;
        TimeLeftSeconds = 0f;
    }

    public void Resetimer()
    {
        Enabled = false;
        TimeLeftSeconds = 0f;
        Hide();
    }
}
