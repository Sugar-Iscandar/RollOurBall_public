using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerMovingDistanceCalculator
{
    Vector3 previousFramePosition;
    Vector3 currentPosition;

    float movingDistance;
    float totalMovingDistance;
    float previousTotalMovingDistance;

    Action updateUi = null;

    public Vector3 PreviousFramePosition
    {
        set { previousFramePosition = value; }
    }

    public float MovingDistance
    {
        get { return movingDistance; }
    }

    public float TotalMovingDistance
    {
        get { return totalMovingDistance; }
    }

    public Action UpdateUi
    {
        set { updateUi = value; }
    }

    public void Init(Vector3 currentPlayerPosition)
    {
        previousFramePosition = currentPlayerPosition;
        movingDistance = 0f;
        totalMovingDistance = 0f;
        previousTotalMovingDistance = 0f;
        Debugger.Log("PMDC,Init");
    }

    public void CalculateMovingDistance(Vector3 currentPlayerPosition)
    {
        currentPosition = currentPlayerPosition;

        movingDistance = Vector3.Distance(previousFramePosition, currentPosition);

        totalMovingDistance += movingDistance;

        //UI?????????????
        if ((int)totalMovingDistance != (int)previousTotalMovingDistance)
        {
            updateUi?.Invoke();
            Debugger.Log("PMDC,UiChange");
        }

        previousFramePosition = currentPosition;
        previousTotalMovingDistance = totalMovingDistance;
    }
}
