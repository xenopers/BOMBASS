using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class MenuAdManager : MonoBehaviour
{
    MenuInterstitialAD interstitialAD;
    private void Start()
    {
        interstitialAD = GetComponent<MenuInterstitialAD>();
        
        MobileAds.Initialize((InitializationStatus initStatus) => {
            interstitialAD.LoadInterstitialAd();
        });
    }

    public bool ShowInterstitialAd() => interstitialAD.Show();

}
