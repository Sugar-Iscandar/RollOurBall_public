using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBoardController : MonoBehaviour
{
    [Header("移動経路")]
    [SerializeField] GameObject[] destinationMarker;

    [Header("移動の速さ")]
    [SerializeField] float speed = 1.0f;

    [Header("両端到着時の待機時間")]
    [SerializeField] float waitTime = 3.0f;

    Rigidbody rigidbodyOfMovingBoard;
    int currentMarker = 0;
    bool isReturning = false;
    bool isWork = false;

    void Start()
    {
        rigidbodyOfMovingBoard = this.gameObject.GetComponent<Rigidbody>();

        if (destinationMarker != null && destinationMarker.Length > 0 && rigidbodyOfMovingBoard != null)
        {
            rigidbodyOfMovingBoard.position = destinationMarker[0].transform.position;
        }

        isWork = true;
    }

    void FixedUpdate()
    {
        if (destinationMarker != null && destinationMarker.Length > 1 && rigidbodyOfMovingBoard != null)
        {
            if (isWork)
            {
                if (!isReturning)
                {
                    int nextMarker = currentMarker + 1;

                    if (Vector3.Distance(transform.position, destinationMarker[nextMarker].transform.position) > 0.01f)
                    {
                        Vector3 movement = Vector3.MoveTowards(transform.position,
                                                                destinationMarker[nextMarker].transform.position,
                                                                speed * Time.deltaTime);

                        rigidbodyOfMovingBoard.MovePosition(movement);
                    }
                    else
                    {
                        rigidbodyOfMovingBoard.MovePosition(destinationMarker[nextMarker].transform.position);
                        currentMarker++;

                        if (currentMarker + 1 >= destinationMarker.Length)
                        {
                            isReturning = true;
                            //ここでisWorkをfalseにしたい
                            StartCoroutine(WaitForWaitingTime());
                        }
                    }
                }
                else
                {
                    int nextMarker = currentMarker - 1;

                    if (Vector3.Distance(transform.position, destinationMarker[nextMarker].transform.position) > 0.01f)
                    {
                        Vector3 movement = Vector3.MoveTowards(transform.position,
                                                                destinationMarker[nextMarker].transform.position,
                                                                speed * Time.deltaTime);

                        rigidbodyOfMovingBoard.MovePosition(movement);
                    }
                    else
                    {
                        rigidbodyOfMovingBoard.MovePosition(destinationMarker[nextMarker].transform.position);
                        currentMarker--;

                        if (currentMarker <= 0)
                        {
                            isReturning = false;
                            StartCoroutine(WaitForWaitingTime());
                        }
                    }
                }
            }
        }
    }

    IEnumerator WaitForWaitingTime()
    {
        isWork = false;
        yield return new WaitForSeconds(waitTime);
        isWork = true;
    }
}
