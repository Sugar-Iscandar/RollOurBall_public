using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Timer
{
    int elapsedMinute;
    float elapsedSeconds;
    float previousElapsedSeconds;

    Action updateUi = null;

    public int ElapsedMinute
    {
        get { return elapsedMinute; }
    }

    public float ElapsedSeconds
    {
        get { return elapsedSeconds; }
    }

    public Action UpdateUi
    {
        set { updateUi = value; }
    }

    public void Init()
    {
        elapsedMinute = 0;
        elapsedSeconds = 0f;
        previousElapsedSeconds = 0f;
    }

    public void CalculateElapsedTime()
    {
        elapsedSeconds += Time.deltaTime;

        if (elapsedSeconds >= 60.0f)
        {
            elapsedMinute++;
            elapsedSeconds -= 60f;
        }

        //UI?????????????
        if ((int)elapsedSeconds != (int)previousElapsedSeconds)
        {
            updateUi?.Invoke();
        }

        previousElapsedSeconds = elapsedSeconds;
    }
}
