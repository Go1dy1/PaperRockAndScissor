using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Serialization;

public class AdsManager : MonoBehaviour, IUnityAdsInitializationListener
{
   [FormerlySerializedAs("TestADS")] [SerializeField] private bool _testAds = true ; 
   [FormerlySerializedAs("IOsId")] [SerializeField] string _osId= "5286335";
   [FormerlySerializedAs("AndroidId")] [SerializeField] string _androidId ="5286334";

    private string _gameID;
void Awake()
{
    InitializeAds();
}
 public void InitializeAds(){
    _gameID = (Application.platform== RuntimePlatform.IPhonePlayer)? _osId: _androidId; 
    Advertisement.Initialize(_gameID, _testAds, this);
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
