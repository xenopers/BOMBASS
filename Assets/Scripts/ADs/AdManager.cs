using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class AdManager: MonoBehaviour
{
    InterstitialAD interstitialAD;
    ReviveRewardAD reviveRewardAD;
    DoubleCoinRewardAd doubleCoinRewardAd;
    private void Awake()
    {
        interstitialAD = GetComponent<InterstitialAD>();
        reviveRewardAD = GetComponent<ReviveRewardAD>();
        doubleCoinRewardAd = GetComponent<DoubleCoinRewardAd>();

        MobileAds.Initialize((InitializationStatus initStatus) => {
            interstitialAD.LoadInterstitialAd();
            reviveRewardAD.LoadReviveRewardAd();
            doubleCoinRewardAd.LoadDoubleCoinRewardAd();
        });
    }



    public bool ShowInterstitialAd() => interstitialAD.Show();
    public void ShowDoubleCoinRewardAd() => doubleCoinRewardAd.Show();
    public void ShowReviveRewardAd() => reviveRewardAD.Show();
}
