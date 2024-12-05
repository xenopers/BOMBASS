using System;
using System.Collections;
using System.Collections.Generic;
using GoogleMobileAds.Api;
using UnityEngine;

public class ReviveRewardAD : MonoBehaviour
{
    RewardedAd rewardedAd;
    private const string adUnitId = "ca-app-pub-8980413492292826/1229732283";
    GameManager gm;
    HudManager hm;

    private void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        hm = gm.GetComponent<HudManager>();
    }

    public void LoadReviveRewardAd()
  {
      // Clean up the old ad before loading a new one.
      if (rewardedAd != null)
      {
            rewardedAd.Destroy();
            rewardedAd = null;
      }

      Debug.Log("Loading the rewarded ad.");

      // create our request used to load the ad.
      var adRequest = new AdRequest();

      // send the request to load the ad.
      RewardedAd.Load(adUnitId, adRequest,
          (RewardedAd ad, LoadAdError error) =>
          {
              // if error is not null, the load request failed.
              if (error != null || ad == null)
              {
                  hm.SetAdLoadStatus(false);
                  return;
              }

              Debug.Log("Rewarded ad loaded with response : "
                        + ad.GetResponseInfo());

              rewardedAd = ad;
              RegisterEventHandlers(rewardedAd);
          });
  }

    public void Show()
    {

        if (rewardedAd != null && rewardedAd.CanShowAd())
        {
            rewardedAd.Show((Reward reward) =>
            {
                gm.RevivePlayer();
            });
        } else hm.ShowLoadAdError();
    }

    private void RegisterEventHandlers(RewardedAd ad)
    {
        // Raised when the ad is estimated to have earned money.
        ad.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(String.Format("Rewarded ad paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        ad.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Rewarded ad recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        ad.OnAdClicked += () =>
        {
            Debug.Log("Rewarded ad was clicked.");
        };
        // Raised when an ad opened full screen content.
        ad.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Rewarded ad full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        ad.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Rewarded ad full screen content closed.");
            LoadReviveRewardAd();
        };
        // Raised when the ad failed to open full screen content.
        ad.OnAdFullScreenContentFailed += (AdError error) =>
        {
            hm.ShowLoadAdError();
            LoadReviveRewardAd();
        };
    }
}
