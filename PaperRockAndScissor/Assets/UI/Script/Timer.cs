using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] internal GameObject Menu,Lose, Win, Tie;
    public float timeStart = 5f;
    [SerializeField] TMP_Text TimerText;
    const float lowTime = 0; 
    public PassADS ad;
    private bool ShowAdds =false;
    void Start()
    {
        TimerText.text = timeStart.ToString();
    }

   
    void Update()
    {


        timeStart-=  Time.deltaTime;
        TimerText.text  = Mathf.Round(timeStart).ToString();

        if(timeStart<=lowTime||EnemyCrush.HealPoint<=lowTime||TowerManager.HealPoint<=lowTime){
            
           timeStart= lowTime;
            Menu.SetActive(true);

            if(EnemyCrush.HealPoint> TowerManager.HealPoint)Lose.SetActive(true);
            else if(EnemyCrush.HealPoint< TowerManager.HealPoint)Win.SetActive(true);
            else Tie.SetActive(true);
            if(!ShowAdds){
                ShowAdds= true;    
                ad.ShowAd();

                }
            

        }
    }
}
