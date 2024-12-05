using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestScore : MonoBehaviour
{
    private TextMeshProUGUI _text;
    private string _key;
    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _key = _text.text;

        SetText();
    }

    private void OnEnable()
    {
        SetText();
    }
    private void SetText()
    {
        _text.text = TextData.LOCALIZATION[_key][TextData.CURRENT_LANGUAGE] + PlayerPrefs.GetInt("score");
    }

    private void OnDisable()
    {
        _text.text = null;
    }
}
