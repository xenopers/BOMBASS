using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using CrazyGames;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HudManager : MonoBehaviour
{
    GameManager gm;
    public TextMeshProUGUI scoreTMP;
    public TextMeshProUGUI coinTMP;
    public GameObject endGameMenu;
    public GameObject reviveButton;
    public GameObject doubleCoinButton;
    public GameObject bigReviveButton;
    public GameObject bigDoubleCoinButton;
    public GameObject pauseMenu;
    public GameObject settings;
    public GameObject loadAdError;
    public GameObject newRecord;
    public GameObject HUI;
    public TextMeshProUGUI menuCoinsTMP;
    public TextMeshProUGUI menuScoreTMP;

    bool adLoaded = true;
    SoundManager sm;


    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        sm = GetComponent<SoundManager>();
    }

    void Update()
    {
        scoreTMP.text = $"{gm.Score}";
        coinTMP.text = $"{gm.Coins}";
    }

    public void ShowEndGameMenu()
    {
        Time.timeScale = 0;
        menuCoinsTMP.text = $"{gm.Coins}";
        menuScoreTMP.text = scoreTMP.text;
        endGameMenu.SetActive(true);
        HUI.SetActive(false);
        CrazySDK.Game.GameplayStop();
    }

    public void ShowNewRecord() => newRecord.SetActive(true);
    public void CloseEndGameMenu()
    {
        Time.timeScale = 1;
        newRecord.SetActive(false);
        endGameMenu.SetActive(false);
        HUI.SetActive(true);
        if(!adLoaded)
        {
            reviveButton.SetActive(false);
            doubleCoinButton.SetActive(false);
        }
    }

    public void OnPauseButtonClick()
    {
        Time.timeScale = 0;
        sm.music.Pause();
        pauseMenu.SetActive(true);
        HUI.SetActive(false);
        CrazySDK.Game.GameplayStop();
    }

    public void OnResumeGameButtonClick()
    {
        Time.timeScale = 1;
        sm.music.UnPause();
        pauseMenu.SetActive(false);
        HUI.SetActive(true);
        settings.SetActive(false);
        CrazySDK.Game.GameplayStart();
    }

    public void OnBackToMenuButtonClick() => SceneManager.LoadScene(0);
    public void OnRestartGameButtonClick()
    {
        Time.timeScale = 1;
        endGameMenu.SetActive(false);
        HUI.SetActive(true);
        gm.RestartGame();
    }

    
    public void OnSettingsButtonClick()
    {
        pauseMenu.SetActive(false);
        settings.SetActive(true);
    }

    public void OnBackToPauseButtonClick()
    {
        pauseMenu.SetActive(true);
        settings.SetActive(false);
    }

    public void OnReviveButtonClick()
    {
        CrazyScript.Instance.ShowReviveRewardedAd();
        reviveButton.SetActive(false);
        bigReviveButton.SetActive(false);
        if (doubleCoinButton.activeSelf)
        {
            doubleCoinButton.SetActive(false);
            bigDoubleCoinButton.SetActive(true);
        }
        else bigDoubleCoinButton.SetActive(false);
    }

    public void OnDoubleCoinButtonClick()
    {
        CrazyScript.Instance.ShowDoubleCoinRewardedAd();
        doubleCoinButton.SetActive(false);
        bigDoubleCoinButton.SetActive(false);
        if (reviveButton.activeSelf)
        {
            reviveButton.SetActive(false);
            bigReviveButton.SetActive(true);
        }
        else bigReviveButton.SetActive(false);
    }

    public void SetAdLoadStatus(bool status) => adLoaded = status;

    public void OnCloseNoticeButton() => loadAdError.SetActive(false);

    public void UpdateCoinTMP() => menuCoinsTMP.text = $"{gm.Coins}";

    public void ShowLoadAdError() => loadAdError.SetActive(true);

}
