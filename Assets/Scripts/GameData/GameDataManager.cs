using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class JetsShopData
{
    public List<int> purchasedJetsIndexes = new List<int>();
}


[System.Serializable]
public class PlayerData
{
    public int coins = 0;
    public int selectedJetIndex = 0;
}


public class GameDataManager
{
    static PlayerData playerData = new PlayerData();
    static JetsShopData jetsShopData = new JetsShopData();

    static JetSkin selectedJetSkin;

    static GameDataManager()
    {
        LoadPlayerData();
        LoadJetsShopData();
    }

    public static int GetCoins() => playerData.coins;
    public static void AddCoins(int amount)
    {
        playerData.coins += amount;
        SavePlayerData();
    }

    public static bool CanSpendCoins(int amount) => playerData.coins >= amount;
    public static void SpendCoins(int amount)
    {
        playerData.coins -= amount;
        SavePlayerData();
    }

    public static JetSkin GetSelectedJetSkin() => selectedJetSkin;
    public static void SetSelectedJet(JetSkin newJetSkin, int index)
    {
        selectedJetSkin = newJetSkin;
        playerData.selectedJetIndex = index;
        SavePlayerData();
    }

    public static int GetSelectedJetIndex() => playerData.selectedJetIndex;
    static void LoadPlayerData()
    {
        playerData = BinarySerializer.Load<PlayerData>("player-data.txt");
        Debug.Log("<color=green>[PlayerData] Loaded.</color>");
    }

    static void SavePlayerData()
    {
        BinarySerializer.Save(playerData, "player-data.txt");
        Debug.Log("<color=green>[PlayerData] Saved.</color>");
    }

    // JETS SHOP DATA

    public static void AddPurchasedJet(int jetIndex)
    {
        jetsShopData.purchasedJetsIndexes.Add(jetIndex);
        SaveJetsShopData();
    }

    public static List<int> GetAllPurchasedJets() => jetsShopData.purchasedJetsIndexes;

    public static int GetPurchasedJet(int index) => jetsShopData.purchasedJetsIndexes[index];

    static void LoadJetsShopData()
    {
        jetsShopData = BinarySerializer.Load<JetsShopData>("jets-shop-data.txt");
        Debug.Log("<color=green>[JetsShop] Loaded.</color>");
    }

    static void SaveJetsShopData()
    {
        BinarySerializer.Save(jetsShopData, "jets-shop-data.txt");
        Debug.Log("<color=green>[JetsShop] Saved.</color>");
    }
}
