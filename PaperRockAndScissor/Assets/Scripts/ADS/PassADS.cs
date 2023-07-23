using UnityEngine;
using UnityEngine.Advertisements;

namespace ADS
{
    public class PassAds : MonoBehaviour, IUnityAdsLoadListener,IUnityAdsShowListener
    {
        [SerializeField] private string _osId= "Interstitial_iOS ";
        [SerializeField] private string _androidId ="Interstitial_Android";

        private string _adID;

    

        void Awake()
        {
            _adID= (Application.platform == RuntimePlatform.IPhonePlayer)? _osId: _androidId;
            LoadAd();
        }

        public void LoadAd()
        {
            // Debug.Log("Loading Ad:" + adID);
            Advertisement.Load(_adID, this);
        }

        public void ShowAd()
        {
//    Debug.Log("Show Ad:" + adID);
            Advertisement.Show(_adID, this);
        }

        public void OnUnityAdsAdLoaded(string placementId)
        {
        
            print("AdsLoaded");
        
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
            print("AdsStart");
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
}

