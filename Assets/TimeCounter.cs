using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    float secondTime = 0;
    float minuteTime = 0;

    [SerializeField] private Text timerText;
    void Update()
    {
        Mathf.Round(secondTime += Time.deltaTime);
        timerText.text = string.Format("{0:00}:{1:00}", minuteTime, secondTime);
        IncreaseMinute(secondTime);
    }
    void IncreaseMinute(float second)
    {
        if(second >= 60)
        {
            minuteTime++;
            secondTime = 0;
        }
    }
}
