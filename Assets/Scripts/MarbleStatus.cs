using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MarbleStatus : MonoBehaviour, IPlayerStatus
{
    [SerializeField] float inputMaxHp;
    float hp;
    float previousHp;
    Vector3 currentPlayerPosition;

    Vector3 lastVisitedCheckPoint;
    int numberOfLastVisitedCheckPoint;

    PlayerMovingDistanceCalculator playerMovingDistanceCalculator = new PlayerMovingDistanceCalculator();
    UnityAction<float> onMovingDistanceChanged = null;
    UnityAction<float, float> onHpChanged = null;

    public UnityAction<float> OnMovingDistanceChanged
    {
        get { return onMovingDistanceChanged; }
        set { onMovingDistanceChanged = value; }
    }

    public UnityAction<float,float> OnHpChanged
    {
        get { return onHpChanged; }
        set { onHpChanged = value; }
    }

    public Vector3 CurrentPlayerPosition
    {
        get { return currentPlayerPosition; }
    }

    public Vector3 LastVisitedCheckPoint
    {
        get { return lastVisitedCheckPoint; }
        set { lastVisitedCheckPoint = value; }
    }

    public int NumberOfLastVisitedCheckPoint
    {
        get { return numberOfLastVisitedCheckPoint; }
        set { numberOfLastVisitedCheckPoint = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        hp = inputMaxHp;
        previousHp = hp;
        currentPlayerPosition = transform.position;

        playerMovingDistanceCalculator.Init(currentPlayerPosition);

        //実行タイミングはPlayerMovingDistanceCalculatorクラスに教えてもらう
        playerMovingDistanceCalculator.UpdateUi =
            () => onMovingDistanceChanged?.Invoke(playerMovingDistanceCalculator.TotalMovingDistance);

        onHpChanged.Invoke(hp, inputMaxHp);
    }

    // Update is called once per frame
    void Update()
    {
        currentPlayerPosition = transform.position;

        playerMovingDistanceCalculator.CalculateMovingDistance(currentPlayerPosition);

        //hp計算
        hp -= playerMovingDistanceCalculator.MovingDistance;

        if (hp < 0)
        {
            hp = 0;
        }

        if ((int)hp != (int)previousHp)
        {
            onHpChanged?.Invoke(hp, inputMaxHp);
        }

        previousHp = hp;
    }
}
