using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image healthbar;
    FighterController player;

    void Start()
    {    
        player = GameObject.Find("Fighter").GetComponent<FighterController>();
    }
    void Update()
    {
        healthbar.fillAmount = player.currentHealth / player.maxHealth;
    }
}
