using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class JetSkinItemUI : MonoBehaviour
{


    [Space(20f)]
    public Image jetImage;
    public TextMeshProUGUI jetNameTMP;
    public Button jetButton;
    public Button jetDonatableButton;
    public TextMeshProUGUI jetButtonTMP;
    public GameObject checkIcon;

    public Sprite emptyButtonBg;
    public Sprite fullButtonBg;

    public GameObject descriptionPanel;
    public Button descriptionButton;
    public Button closeDescriptionButton;
    public TextMeshProUGUI jetDescriptionNameTMP;
    public TextMeshProUGUI jetDonatableButtonTMP;
    public Image jetDescriptionIMG;

    private int _id;

    public bool isSelected;

    string _price;
    public JetSkinsDatabase jetDB;
  

    private AudioSource buttonClickSFX;
    private void Start() { 
        buttonClickSFX = GameObject.Find("MenuManager").GetComponent<AudioSource>();
        jetButton.onClick.AddListener(OnButtonClick);
        jetDonatableButton.onClick.AddListener(OnButtonClick);
        descriptionButton.onClick.AddListener(OnButtonClick);
        closeDescriptionButton.onClick.AddListener(OnButtonClick);
    }

    public void SetId(int id) => _id = id;

    public void OnButtonClick()
    {
        buttonClickSFX.Play();
    }

    public void SetItemPosition(Vector2 pos)
    {
        GetComponent<RectTransform>().anchoredPosition += pos;
    }

    public void SetJetImage(Sprite sprite) => jetImage.sprite = sprite;

    public void SetJetName(string name)
    {
        jetNameTMP.text = name;
        jetDescriptionNameTMP.text = name;
    }
    public void SetJetDescriptionImage(Sprite sprite) => jetDescriptionIMG.sprite = sprite;
    public void SetJetPrice(string price)
    {
        _price = price;
        jetButtonTMP.text = price + " " + TextData.LOCALIZATION["coins_key"][TextData.CURRENT_LANGUAGE];
    }


   /* public void SetAsDonatable()
    {
        jetButton.gameObject.SetActive(false);
        jetDonatableButton.gameObject.SetActive(true);
        IAPManager IAPM = GameObject.Find("MenuManager").GetComponent<IAPManager>();
        jetDonatableButton.onClick.AddListener(IAPM.F16PurchaseButtonClick);
        jetDonatableButtonTMP.text = IAPM.GetPrice("com.xenogames.bombass.f16");
    }*/
    public void SetJetAsPurchased()
    {
        jetButtonTMP.color = Color.black;
        jetButton.gameObject.SetActive(true);
        jetDonatableButton.gameObject.SetActive(false);
        jetButtonTMP.text = TextData.LOCALIZATION["select_jet_key"][TextData.CURRENT_LANGUAGE];
        jetButton.GetComponent<Image>().sprite = emptyButtonBg;
        jetButton.interactable = true;
    }

    public void OnItemPurchase(int itemIndex, UnityAction<int> action)
    {
        jetButton.onClick.RemoveAllListeners();
        jetButton.onClick.AddListener(() => action.Invoke(itemIndex));
    }

    public void OnItemSelect(int itemIndex, UnityAction<int> action)
    {
        jetButton.onClick.RemoveAllListeners();
        jetButton.onClick.AddListener(() => action.Invoke(itemIndex));
    }

    public void SelectItem()
    {
        jetButtonTMP.text = TextData.LOCALIZATION["selected_key"][TextData.CURRENT_LANGUAGE];
        jetButton.interactable = false;
        jetButton.GetComponent<Image>().sprite = fullButtonBg;
        if (descriptionPanel.activeInHierarchy)
            ChangeToWhiteButtonColor();
        else
            jetButtonTMP.color = Color.black;
        checkIcon.SetActive(true);
        isSelected = true;
    }

    public void DeselectItem()
    {
        jetButton.interactable = true;
        jetButtonTMP.text = TextData.LOCALIZATION["select_jet_key"][TextData.CURRENT_LANGUAGE];
        jetButton.GetComponent<Image>().sprite = emptyButtonBg;
        if (descriptionPanel.activeInHierarchy) 
            ChangeToWhiteButtonColor();
        else
            jetButtonTMP.color = Color.black;
        checkIcon.SetActive(false);
        isSelected = false;
    }

    public void AnimateShakeItem()
    {
        transform.DOComplete();

        transform.DOShakePosition(1f, new Vector3(16f, 0, 0), 10, 0).SetEase(Ease.Linear);
    }

    public void OnShowDescriptionButtonClick()
    {
        descriptionPanel.SetActive(true);
        ChangeToWhiteButtonColor();
    }

    public void OnCloseDescriptionButtonClick()
    {
        descriptionPanel.SetActive(false);
        if (!jetDB.IsSkinPurchased(_id))
        {
            ChangeToBlackButtonColor();
        }
        if (jetDB.IsSkinPurchased(_id) && !isSelected)
            jetButton.GetComponent<Image>().sprite = emptyButtonBg;

    }

    public void ChangeToWhiteButtonColor()
    {
        ColorBlock jetDonatableCB = jetDonatableButton.colors;
        jetDonatableCB.normalColor = Color.white;
        jetDonatableCB.selectedColor = Color.white;
        jetDonatableButton.colors = jetDonatableCB;
        jetDonatableButtonTMP.color = Color.black;

        ColorBlock jetButtonCB = jetButton.colors;
        jetButtonCB.normalColor = Color.white;
        jetButtonCB.selectedColor = Color.white;
        jetButton.colors = jetButtonCB;
        jetButton.GetComponent<Image>().sprite = fullButtonBg;
        jetButtonTMP.color = Color.black;
    }
    public void ChangeToBlackButtonColor()
    {
        ColorBlock jetDonatableCB = jetDonatableButton.colors;
        jetDonatableCB.normalColor = Color.black;
        jetDonatableCB.selectedColor = Color.black;
        jetDonatableButton.colors = jetDonatableCB;
        jetDonatableButtonTMP.color = Color.white;

        ColorBlock jetButtonCB = jetButton.colors;
        jetButtonCB.normalColor = Color.black;
        jetButtonCB.selectedColor = Color.black;
        jetButton.colors = jetButtonCB;
        jetButtonTMP.color = Color.white;
    }

    public void OnEnable()
    {
        if (jetDB.IsSkinPurchased(_id) && isSelected)
            jetButtonTMP.text = TextData.LOCALIZATION["selected_key"][TextData.CURRENT_LANGUAGE];
        else if (jetDB.IsSkinPurchased(_id) && !isSelected)
            jetButtonTMP.text = TextData.LOCALIZATION["select_jet_key"][TextData.CURRENT_LANGUAGE];
        else if (!jetDB.IsSkinPurchased(_id))
            jetButtonTMP.text =  _price + " " + TextData.LOCALIZATION["coins_key"][TextData.CURRENT_LANGUAGE];
    }
}
