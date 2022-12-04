using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    Timer timer = new Timer();

    public UnityAction<int, float> OnElapsedTimeChanged = null;

    void Start()
    {
        timer.Init();
        //実行タイミングはTimerクラスに教えてもらう
        timer.UpdateUi = () => OnElapsedTimeChanged?.Invoke(timer.ElapsedMinute, timer.ElapsedSeconds);
    }

    void Update()
    {
        timer.CalculateElapsedTime();
    }
}
