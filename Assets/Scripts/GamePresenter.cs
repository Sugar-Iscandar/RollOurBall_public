using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePresenter : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] StatusView statusView;
    IPlayerStatus[] playerStatuses;

    void Awake()
    {
        gameManager.OnElapsedTimeChanged =
            (elapsedMinute, elapsedSeconds)
            => statusView.UpdateTextElapsedTime(elapsedMinute, elapsedSeconds);

        playerStatuses = GameObjectExtensions.FindObjectOfIntarcafe<IPlayerStatus>();

        for (int i = 0; i < playerStatuses.Length; i++)
        {
            playerStatuses[i].OnMovingDistanceChanged =
                (totalMovingDistance) => statusView.UpdateTextMovingDistance(totalMovingDistance);

            playerStatuses[i].OnHpChanged =
                (hp, maxHp) => statusView.UpdateHpStatus(hp, maxHp);
        }
    }
}
