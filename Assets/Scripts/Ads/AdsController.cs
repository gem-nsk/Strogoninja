using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_ANDROID
using GoogleMobileAds.Android;
#endif
using GoogleMobileAds;
using GoogleMobileAds.Api;

public class AdsController : ObjectInteractionBasement
{

    private const string _INTERSTITIAL_KEY = "ca-app-pub-6218488866205337/2681971020";
    private const string _REWARDED_VIDEO_KEY = "ca-app-pub-6218488866205337/4733419297";

    public RewardedAd _Rewarded;
    public InterstitialAd _Interstitial;

    public override void Init()
    {
        base.Init();

        MobileAds.Initialize((InitializationStatus obj) => { Debug.Log("init"); }) ;
    }

    public void RequestInterstitial()
    {
        //destroy old
        if(_Interstitial != null)
        {
            _Interstitial.Destroy();
        }

        this._Interstitial = new InterstitialAd(_INTERSTITIAL_KEY);

        //events
        this._Interstitial.OnAdClosed += _Interstitial_OnAdClosed;

        //load
        this._Interstitial.LoadAd(CreateRequest());
    }

    public void ShowInterstitial()
    {
        if (_Interstitial.IsLoaded())
        {

        }
    }

    AdRequest CreateRequest()
    {
        return new AdRequest.Builder().Build();
    }



    public void RequestRewardedVideo()
    {

    }

    public void ShowRewardedVideo()
    {

    }

    private void _Interstitial_OnAdClosed(object sender, System.EventArgs e)
    {
        throw new System.NotImplementedException();
    }
}
