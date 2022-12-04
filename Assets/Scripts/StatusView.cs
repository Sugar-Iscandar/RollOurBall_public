using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class StatusView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshPro_elapsedTime;
    [SerializeField] TextMeshProUGUI textMeshPro_movingDistance;
    [SerializeField] TextMeshProUGUI textMeshPro_hpValue;
    [SerializeField] Slider hpSlider;

    public void UpdateTextElapsedTime(int elapsedMinute,float elapsedSeconds)
    {
        textMeshPro_elapsedTime.text = elapsedMinute.ToString("00") + ":" + ((int)elapsedSeconds).ToString("00");
    }

    public void UpdateTextMovingDistance(float totalMovingDistance)
    {
        textMeshPro_movingDistance.text = "移動距離: " + (int)totalMovingDistance + " m";
    }

    public void UpdateHpStatus(float hp, float maxHp)
    {
        hpSlider.value = hp / maxHp;
        textMeshPro_hpValue.text = ((int)hp).ToString("000");
    }
}
