using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CrazyGames;

public class CrazyScript : MonoBehaviour
{
    public static CrazyScript Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }
    void Start()
    {
        CrazySDK.Init(() => { /** initialization finished callback */ });
    }

   
    public void ShowInterstitialAd()
    {
        CrazySDK.Ad.RequestAd(CrazyAdType.Midgame, () =>
        {
            print("Midgame ad started");
        }, (error) =>
        {
            print("Error: " + error);
        }, () =>
        {
            CrazySDK.Data.SetInt("AttemptsCount", 0);
        });
    }

    public void ShowReviveRewardedAd()
    {
        CrazySDK.Ad.RequestAd(CrazyAdType.Rewarded, () =>
        {
            print("Revive rewarded ad started");
        }, (error) =>
        {
            print("Error during revive reward ad showing: " + error);
            HudManager hm = FindAnyObjectByType<HudManager>();
            hm.ShowLoadAdError();
        }, () =>
        {
            GameManager gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
            gm.RevivePlayer();
        });
    }

    public void ShowDoubleCoinRewardedAd()
    {
        CrazySDK.Ad.RequestAd(CrazyAdType.Rewarded, () =>
        {
            print("Double coin rewarded ad started");
        }, (error) =>
        {
            print("Error during double coin reward ad showing: " + error);
            HudManager hm = FindAnyObjectByType<HudManager>();
            hm.ShowLoadAdError();
        }, () =>
        {
            GameManager gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
            gm.DoubleCoins();
        });
    }
}
