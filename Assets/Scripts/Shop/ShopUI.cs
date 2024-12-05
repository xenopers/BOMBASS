using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Internal;
using UnityEngine;


public class ShopUI : MonoBehaviour
{
    public float itemSpacing = 0.5f;
    public float itemWidth;

    //public GameObject shopPanel;
    public Transform shopMenu;
    public Transform shopItemsContainer;
    public GameObject itemPrefab;
    [Space(20f)]
    public JetSkinsDatabase jetDB;

    int newSelectedItemIndex = 0;
    int previousSelectedItemIndex = 0;

    //private List<JetSkinItemUI> _shopItemUIList = new List<JetSkinItemUI>();

    public void Start()
    {
        GenerateShopItemsUI();

        SetSelectedJet();

        SelectItemUI(GameDataManager.GetSelectedJetIndex());

    }

    void SetSelectedJet()
    {
        int index = GameDataManager.GetSelectedJetIndex();
        GameDataManager.SetSelectedJet(jetDB.GetJetSkin(index), index);
    }

    public void GenerateShopItemsUI()
    {
        for (int i = 0; i < GameDataManager.GetAllPurchasedJets().Count; i++)
        {
            int purchasedJetIndex = GameDataManager.GetPurchasedJet(i);
            jetDB.PurchaseJetSkin(purchasedJetIndex);
        }

        // Delete item template after calculating items height
        itemWidth = shopItemsContainer.GetChild(0).GetComponent<RectTransform>().sizeDelta.x;
        Destroy(shopItemsContainer.GetChild(0).gameObject);
        shopItemsContainer.DetachChildren();

        // Generate items 
        for (int i = 0; i < jetDB.Count; i++)
        {
            JetSkin jet = jetDB.GetJetSkin(i);
            JetSkinItemUI uiItem = Instantiate(itemPrefab, shopItemsContainer).GetComponent<JetSkinItemUI>();

            // Move item to its position
            uiItem.SetItemPosition(Vector2.right * i * (itemWidth + itemSpacing));
            uiItem.SetId(i);
            // Set item name in hierarchy
            uiItem.gameObject.name = "Item" + i + "_" + jet.name;

            // Add info to the UI (item)
            uiItem.SetJetName(jet.name);
            uiItem.SetJetImage(jet.image);
            uiItem.SetJetPrice(jet.price);
            uiItem.SetJetDescriptionImage(jet.descriptionImage);

            if(jet.isPurchased)
            {
                uiItem.SetJetAsPurchased();
                uiItem.OnItemSelect(i, OnItemSelected);
            } 
            else
            {
                uiItem.SetJetPrice(jet.price);
                uiItem.jetButtonTMP.color = Color.white;
                uiItem.OnItemPurchase(i, OnItemPurchased);
            }

            //_shopItemUIList.Add(uiItem);
        }
    }

    public void OnDonatableSkinPurchase(int index)
    {
        OnItemPurchased(index);
    }

    void OnItemSelected(int index)
    {
        SelectItemUI(index);
        
        GameDataManager.SetSelectedJet(jetDB.GetJetSkin(index), index);
    }

    void SelectItemUI(int itemIndex)
    {
        previousSelectedItemIndex = newSelectedItemIndex;
        newSelectedItemIndex = itemIndex;

        JetSkinItemUI prevUiItem = GetItemUI(previousSelectedItemIndex);
        JetSkinItemUI newUiItem = GetItemUI(newSelectedItemIndex);

        prevUiItem.DeselectItem();
        newUiItem.SelectItem();
    }

    JetSkinItemUI GetItemUI(int index) => shopItemsContainer.GetChild(index).GetComponent<JetSkinItemUI>();
    public void OnItemPurchased(int index)
    {
        JetSkin jetSkin = jetDB.GetJetSkin(index);
        JetSkinItemUI uiItem = GetItemUI(index);

        if (jetSkin.isDonatable) 
        {
            jetDB.PurchaseJetSkin(index);
            uiItem.SetJetAsPurchased();
            uiItem.OnItemSelect(index, OnItemSelected);
            GameDataManager.AddPurchasedJet(index);
        }
        else if(GameDataManager.CanSpendCoins(int.Parse(jetSkin.price)))
        {
            GameDataManager.SpendCoins(int.Parse(jetSkin.price));
            GameObject.Find("MenuManager").GetComponent<MenuUI>().UpdateCoinsText();
            jetDB.PurchaseJetSkin(index);
            uiItem.SetJetAsPurchased();
            uiItem.OnItemSelect(index, OnItemSelected);
            GameDataManager.AddPurchasedJet(index);
        } else
        {
            uiItem.AnimateShakeItem();
        }
    }
}
