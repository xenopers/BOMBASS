using CrazyGames;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuUI : MonoBehaviour
{
    public TextMeshProUGUI coinsTMP;
    public TextMeshProUGUI versionTMP;
    public GameObject menuUI;
    public GameObject shopUI;
    public GameObject settingsUI;
    public MenuAdManager ad;
    

    public void Awake()
    {
        
    }

    private void Start()
    {
        versionTMP.text = "v" + Application.version;
        if (CrazySDK.Data.GetString("language") == "")
        {
            CrazySDK.Data.SetFloat("musicVolume", 1);
            CrazySDK.Data.SetFloat("soundVolume", 1);
            if (Application.systemLanguage == SystemLanguage.Ukrainian)
            {
                CrazySDK.Data.SetString("language", "uk");
                TextData.CURRENT_LANGUAGE = "uk";
            }
            else
            {
                CrazySDK.Data.SetString("language", "en");
                TextData.CURRENT_LANGUAGE = "en";
            }
        }   
        if (CrazySDK.IsInitialized)
            CrazySDK.Game.GameplayStop();
    }

    public void OnPlayButtonClick()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void OnReturnToMenuButton()
    {
        menuUI.SetActive(true);
        shopUI.SetActive(false);
        settingsUI.SetActive(false);
    }
    public void OnShopButtonClick()
    {
        menuUI.SetActive(false);
        shopUI.SetActive(true);
        UpdateCoinsText();
    }

    public void OnSettingsButtonClick()
    {
        menuUI.SetActive(false);
        settingsUI.SetActive(true);
    }

    public void OpenURL(string URL)
    {
        Application.OpenURL(URL);
    }

    public void UpdateCoinsText() => coinsTMP.text = "" + GameDataManager.GetCoins();

}
