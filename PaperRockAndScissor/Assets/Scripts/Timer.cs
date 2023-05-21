using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] internal GameObject Menu;
    public float timeStart = 10;
    [SerializeField] TMP_Text TimerText;
    const float lowTime = 0; 
    bool CheckTime = false;
    void Start()
    {
        TimerText.text = timeStart.ToString();
    }

   
    void Update()
    {
        timeStart-=  Time.deltaTime;
        TimerText.text  = Mathf.Round(timeStart).ToString();
        if(timeStart<=lowTime){
            if(CheckTime){
            Time.timeScale = 0f;
            CheckTime= false;
            }
            timeStart= 0;
            Menu.SetActive(true);
        }
    }
}
