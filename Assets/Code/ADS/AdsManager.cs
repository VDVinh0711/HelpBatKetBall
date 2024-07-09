
using GoogleMobileAds.Api;
using Lagger.Code.Level;
using Lagger.Code.Manager;
using Lagger.Code.Untils;
using Lagger.Code.User;
using UnityEngine;

namespace ADS
{
    public class AdsManager : Singleton<AdsManager>
    {
        // These ad units are configured to always serve test ads.
        #if UNITY_ANDROID
        private string _adUnitId = "ca-app-pub-3940256099942544/5224354917";
        #elif UNITY_IPHONE
         private string _adUnitId = "ca-app-pub-3940256099942544/1712485313";
        #else
        private string _adUnitId = "unused";
        #endif
        private RewardedAd _rewardedAd;


        private AdsRewardType _rewardType;

        private void Start()
        {
            MobileAds.Initialize((InitializationStatus initStatus) =>
            {
                LoadRewardedAd();
               
            });
        }

        public void ShowAds(AdsRewardType rewardType)
        {
            ShowRewardedAd(rewardType);
        }
        
        public void LoadRewardedAd()
        {

            if (_rewardedAd != null)
            {
                _rewardedAd.Destroy();
                _rewardedAd = null;
            }
            
            var adRequest = new AdRequest();

            // send the request to load the ad.
            RewardedAd.Load(_adUnitId, adRequest,
                (RewardedAd ad, LoadAdError error) =>
                {
                    _rewardedAd = ad;
                    RegisterEventHandlers(_rewardedAd);
                });
        }

        public void ShowRewardedAd(AdsRewardType rewardType)
        {
            if (_rewardedAd != null && _rewardedAd.CanShowAd())
            {
                _rewardedAd.Show((Reward reward) =>
                {
                    print("Run Show");
                    HandelResultReward(rewardType);
                });
            }
            else
            {
                Debug.Log("Rewarded ad is not loaded yet.");
                LoadRewardedAd(); // Load the ad again if it's not loaded.
            }
        }

        
        
        
        
        // Register Event For Ads
        private void RegisterEventHandlers(RewardedAd ad)
        {
            if (ad == null)
                return;
            // Raised when the ad closed full screen content.
            ad.OnAdFullScreenContentClosed += () =>
            {
                print("Ad Close");
            };
         
        }

        private void HandelResultReward(AdsRewardType type)
        {
            switch (type)
            {
                case AdsRewardType.ReVice:
                    EventManager.RaisEvent(SafeNameEvent.CloseUiDead);
                    GameManager.Instance.RePlay();
                    break;
                case AdsRewardType.AddMoney:
                    EventManger<int>.RaiseEvent(SafeNameEvent.AddMoney,10);
                    break;
                case AdsRewardType.DoubleReWard:
                    int rewardlevel = LevelManager.Instance.GetRewardLevel() ;
                    EventManger<int>.RaiseEvent(SafeNameEvent.AddMoney,rewardlevel);
                    EventManger<int>.RaiseEvent(SafeNameEvent.SetUiCoinReWard,rewardlevel * 2);
                    break;
                case AdsRewardType.AddSpin:
                    EventManger<int>.RaiseEvent(SafeNameEvent.AddNumberSpin,1);
                    break;
            }
        }
    }
}
