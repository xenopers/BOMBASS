using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JetSkinsDatabase", menuName = "Shop/Jet Skins Database")]
public class JetSkinsDatabase : ScriptableObject
{
    public JetSkin[] skins;

    public int Count => skins.Length;

    public bool IsSkinPurchased(int index) => skins[index].isPurchased;

    public JetSkin GetJetSkin (int index) => skins[index];  
    public void PurchaseJetSkin(int index) => skins[index].isPurchased = true;
}
