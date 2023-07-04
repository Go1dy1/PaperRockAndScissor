using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener
{
   [SerializeField] private bool TestADS = true ; 
   [SerializeField] string IOsId= "5286335";
   [SerializeField] string AndroidId ="5286334";

    private string gameID;
void Awake()
{
    InitializeAds();
}
 public void InitializeAds(){
    gameID = (Application.platform== RuntimePlatform.IPhonePlayer)? IOsId: AndroidId; 
    Advertisement.Initialize(gameID, TestADS, this);
 }
//IPhonePlayer
    public void OnInitializationComplete()
    {
        Debug.Log("Unity ADS Sucsess");
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity ADS Sucsess: {error.ToString() } - {message}");
    }
}
