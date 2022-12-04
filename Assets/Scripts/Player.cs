using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    //HP関係の変数
    [SerializeField] protected float hp;
    protected float maxHp;
    protected float previousHp;

    //移動関係の変数
    [SerializeField] protected float nomalSpeed;
    [SerializeField] protected float dashSpeed;
    protected float currentSpeed;
    protected Rigidbody playerRigidbody;
    protected bool isDevelopFloating = false;

    //チェックポイント関係の変数
    Vector3 checkPoint;
    int checkPointNum = 0;
    [SerializeField] float timeToHold = 3.0f;
    float longPressTime = 0;

    public UnityAction<float> OnMovingDistanceChanged = null;
    public UnityAction<float, float> OnHpChanged = null;

    protected PlayerMovingDistanceCalculator playerMovingDistanceCalculator =
                                                 new PlayerMovingDistanceCalculator();
    
    public float CurrentSpeed
    {
        get { return currentSpeed; }
        set { currentSpeed = value; }
    }

    public Rigidbody PlayerRigidbody
    {
        get { return playerRigidbody; }
        set { playerRigidbody = value; }
    }

    public bool IsDevelopFloating
    {
        get { return isDevelopFloating; }
        set { isDevelopFloating = value; }
    }

    public Vector3 CheckPoint
    {
        get { return checkPoint; }
        set { checkPoint = value; }
    }

    public int CheckPointNum
    {
        set { checkPointNum = value; }
    }

    void Start()
    {
        playerRigidbody = this.gameObject.GetComponent<Rigidbody>();
        previousHp = hp;
        maxHp = hp;

        playerMovingDistanceCalculator.Init(transform.position);

        //実行タイミングはPlayerMovingDistanceCalculatorクラスに教えてもらう
        playerMovingDistanceCalculator.UpdateUi =
            () => OnMovingDistanceChanged?.Invoke(playerMovingDistanceCalculator.TotalMovingDistance);

        OnHpChanged.Invoke(hp, maxHp);
    }

    protected virtual void Update()
    {
        playerMovingDistanceCalculator.CalculateMovingDistance(transform.position);

        //チェックポイントへ戻る処理
        if (checkPointNum != 0)
        {
            if (Input.GetKey(KeyCode.R))
            {
                longPressTime += Time.deltaTime;
                if (longPressTime >= timeToHold)
                {
                    transform.position = checkPoint;
                    longPressTime = 0;
                }
            }
        }
    }
}
