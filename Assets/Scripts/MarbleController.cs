using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarbleController : MonoBehaviour, IPlayerMovable
{
    [SerializeField] float nomalMovementSpeed;
    [SerializeField] float dashMovementSpeed;

    float currentMovementSpeed;

    Rigidbody playerRigidbody;

    bool isDevelopFloating;

    IPlayerStatus interfaceOfPlayerStatus;

    [SerializeField] float timeToHoldToReturnCheckPoint = 3.0f;
    float longPressTime = 0;

    public bool IsDevelopFloating
    {
        get { return isDevelopFloating; }
        set { isDevelopFloating = value; }
    }

    public Rigidbody PlayerRigidbody
    {
        get { return playerRigidbody; }
        set { playerRigidbody = value; }
    }

    void Start()
    {
        playerRigidbody = this.gameObject.GetComponent<Rigidbody>();
        interfaceOfPlayerStatus = this.gameObject.GetComponent<IPlayerStatus>();
    }

    void Update()
    {
        //チェックポイントへ戻る処理
        if (interfaceOfPlayerStatus.NumberOfLastVisitedCheckPoint != 0)
        {
            if (Input.GetKey(KeyCode.R))
            {
                longPressTime += Time.deltaTime;
                if (longPressTime >= timeToHoldToReturnCheckPoint)
                {
                    transform.position = interfaceOfPlayerStatus.LastVisitedCheckPoint;
                    longPressTime = 0;
                }
            }
        }
    }

    void FixedUpdate()
    {
        //移動処理
        if (!isDevelopFloating)
        {
            float inputHorizontal = Input.GetAxis("Horizontal");
            float inputVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(inputHorizontal, 0, inputVertical);

            Vector3 movementSeenByCamera = Camera.main.gameObject.transform.rotation * movement;
            movementSeenByCamera.y = 0;
            Vector3 normalizeMovementSeenByCamera = movementSeenByCamera.normalized;

            if (Input.GetKey(KeyCode.Space))
            {
                currentMovementSpeed = dashMovementSpeed;
            }
            else
            {
                currentMovementSpeed = nomalMovementSpeed;
            }

            playerRigidbody.AddForce(normalizeMovementSeenByCamera * currentMovementSpeed);
        }
    }
}
