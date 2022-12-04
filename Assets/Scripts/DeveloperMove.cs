using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeveloperMove : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField] bool developMode;
    [SerializeField] float floatingDistance;
    [SerializeField] float nomalSpeedOfDevelopMove;
    [SerializeField] float dashSpeedOfDevelopMove;
    float currentSpeedOfDevelopMove;
    int vKeyInputCount = 0;
    //Player player;

    IPlayerMovable playerMovable;

    void Start()
    {
        playerMovable = this.gameObject.GetComponent<IPlayerMovable>();
    }

    void Update()
    {
        if (developMode)
        {
            //Vキーを0.3秒以内に素早く２回押す
            if (Input.GetKeyDown(KeyCode.V))
            {
                vKeyInputCount++;
                Invoke("SwitchDevelopFloat", 0.3f);
            }

            if (playerMovable.IsDevelopFloating)
            {
                float inputHorizontal = Input.GetAxis("Horizontal");
                float inputVertical = Input.GetAxis("Vertical");
                float inputUpDown = 0;

                if (Input.GetKey(KeyCode.V))
                {
                    inputUpDown = 1.0f;
                }
                else if (Input.GetKey(KeyCode.LeftShift))
                {
                    inputUpDown = -1.0f;
                }

                Vector3 movementOtherUpDown = new Vector3(inputHorizontal, 0, inputVertical);

                Vector3 movementSeenByCamera = Camera.main.gameObject.transform.rotation * movementOtherUpDown;
                movementSeenByCamera.y = 0;
                movementSeenByCamera.y = inputUpDown;
                Vector3 normalizeMovementSeenByCamera = movementSeenByCamera.normalized;

                if (Input.GetKey(KeyCode.Space))
                {
                    currentSpeedOfDevelopMove = dashSpeedOfDevelopMove;
                }
                else
                {
                    currentSpeedOfDevelopMove = nomalSpeedOfDevelopMove;
                }

                transform.position += normalizeMovementSeenByCamera * currentSpeedOfDevelopMove * Time.deltaTime;
            }
        }
    }

    void SwitchDevelopFloat()
    {
        if (vKeyInputCount != 2)
        {
            vKeyInputCount = 0;
        }
        else if (vKeyInputCount == 2 && !playerMovable.IsDevelopFloating)
        {
            playerMovable.IsDevelopFloating = true;
            playerMovable.PlayerRigidbody.useGravity = false;
            playerMovable.PlayerRigidbody.isKinematic = true;
            transform.position += new Vector3(0, floatingDistance, 0);
            vKeyInputCount = 0;
        }
        else if (vKeyInputCount == 2 && playerMovable.IsDevelopFloating)
        {
            playerMovable.PlayerRigidbody.isKinematic = false;
            playerMovable.PlayerRigidbody.useGravity = true;
            playerMovable.IsDevelopFloating = false;
            vKeyInputCount = 0;
        }
    }

#endif
}
