using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TextTranslator : MonoBehaviour
{
    TextMeshProUGUI _text;
    private string _key;
    private void Start()
    {
        //if (PlayerPrefs.GetString("language").Equals("")) PlayerPrefs.SetString("language", "uk");
        _text = GetComponent<TextMeshProUGUI>();
        _key = _text.text;

        SetText();
    }

    void Update()
    {
        SetText();
    }
    private void SetText()
    {
        _text.text = TextData.LOCALIZATION[_key][TextData.CURRENT_LANGUAGE];
    }

    private void OnDisable()
    {
        _text.text = null;
    }
}
