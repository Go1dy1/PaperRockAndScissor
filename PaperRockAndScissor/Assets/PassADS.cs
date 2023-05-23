using UnityEngine;
using UnityEngine.Advertisements;
public class PassADS : MonoBehaviour, IUnityAdsLoadListener,IUnityAdsShowListener
{
   [SerializeField] private string IOsId= "Interstitial_iOS ";
   [SerializeField] private string AndroidId ="Interstitial_Android";

    private string adID;

    

void Awake()
{
adID= (Application.platform == RuntimePlatform.IPhonePlayer)? IOsId: AndroidId;
    LoadAd();
}

public void LoadAd()
{
 //   Debug.Log("Loading Ad:" + adID);
    Advertisement.Load(adID, this);
}

public void ShowAd()
{
//    Debug.Log("Show Ad:" + adID);
    Advertisement.Show(adID, this);
}

    public void OnUnityAdsAdLoaded(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        throw new System.NotImplementedException();
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        LoadAd();
    }
}
