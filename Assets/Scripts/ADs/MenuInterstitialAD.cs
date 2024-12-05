using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class MenuInterstitialAD : MonoBehaviour
{
    private InterstitialAd interstitialAd;
    private const string adUnitId = "ca-app-pub-8980413492292826/2779930098";
    

    public void LoadInterstitialAd()
    {
        // Clean up the old ad before loading a new one.
        if (interstitialAd != null)
        {
            interstitialAd.Destroy();
            interstitialAd = null;
        }

        Debug.Log("Loading the interstitial ad.");

        // create our request used to load the ad.
        var adRequest = new AdRequest();

        // send the request to load the ad.
        InterstitialAd.Load(adUnitId, adRequest,
            (InterstitialAd ad, LoadAdError error) =>
            {
                // if error is not null, the load request failed.
                if (error != null || ad == null)
                {
                    return;
                }

                Debug.Log("Interstitial ad loaded with response : "
                          + ad.GetResponseInfo());

                interstitialAd = ad;
                RegisterEventHandlers(interstitialAd);
            });
    }

    public bool Show()
    {
        if (interstitialAd != null && interstitialAd.CanShowAd())
        {
            interstitialAd.Show();
            return true;
        }
        return false;
    }

    private void RegisterEventHandlers(InterstitialAd interstitialAd)
    {

        // Raised when an impression is recorded for an ad.
        /*interstitialAd.OnAdImpressionRecorded += () =>
        {
            Debug.Log("2");
            sm.music.UnPause();
            Time.timeScale = 1;
            gm.RestartGame();
        };*/
        // Raised when the ad closed full screen content.
        interstitialAd.OnAdFullScreenContentClosed += () =>
        {
            //Debug.Log("Interstitial ad full screen content closed.");
            Debug.Log("1");
            Time.timeScale = 1;
            LoadInterstitialAd();
        };

        // Raised when the ad failed to open full screen content.
        interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
        {
            Debug.LogError("Interstitial ad failed to open full screen content " +
                           "with error : " + error);
            LoadInterstitialAd();
        };
    }


}
