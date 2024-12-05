using System.Collections;
using System.Collections.Generic;
using CrazyGames;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageSwitcher : MonoBehaviour
{
    public TextMeshProUGUI englishLanguage;
    public TextMeshProUGUI ukrainianLangauge;


    void Awake()
    {
        UpdateLanguageButtonsUI();
    }

    public void UpdateLanguageButtonsUI()
    {
        switch(TextData.CURRENT_LANGUAGE)
        {
            case "en":
                ChooseEnglish();
                break;
            case "uk":
                ChooseUkrainian();
                break;
        }
    }

    public void ChooseEnglish()
    {
        TextData.CURRENT_LANGUAGE = "en"; 
        CrazySDK.Data.SetString("language", "en");
        englishLanguage.color = Color.black;
        englishLanguage.fontStyle = FontStyles.Underline;
        ukrainianLangauge.color = Color.gray;
        ukrainianLangauge.fontStyle = FontStyles.Normal;

    }
     
    public void ChooseUkrainian()
    {
        TextData.CURRENT_LANGUAGE = "uk"; 
        CrazySDK.Data.SetString("language", "uk");
        ukrainianLangauge.color = Color.black;
        ukrainianLangauge.fontStyle = FontStyles.Underline;
        englishLanguage.color = Color.gray;
        englishLanguage.fontStyle = FontStyles.Normal;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
