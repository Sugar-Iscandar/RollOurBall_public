using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface IPlayerStatus
{
    Vector3 CurrentPlayerPosition
    {
        get;
    }

    Vector3 LastVisitedCheckPoint
    {
        get;
        set;
    }

    int NumberOfLastVisitedCheckPoint
    {
        get;
        set;
    }

    UnityAction<float> OnMovingDistanceChanged
    {
        get;
        set;
    }

    UnityAction<float,float> OnHpChanged
    {
        get;
        set;
    }
}
