using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] int checkPointNum;

    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Playerが接触したら、当チェックポイントの情報を渡す
        IPlayerStatus playerStatus = other.gameObject.GetComponent<IPlayerStatus>();

        playerStatus.LastVisitedCheckPoint = transform.position;
        playerStatus.NumberOfLastVisitedCheckPoint = checkPointNum;

        Destroy(this.gameObject);
    }
}
