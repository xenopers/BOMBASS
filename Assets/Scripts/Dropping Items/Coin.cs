using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Item
{
    GameManager gm;
    int coins;
  
    new void Start()
    {
        base.Start();
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        coins = 1 + gm.DifficultyFactor / 6;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            gm.Coins += coins;
            Debug.Log("+ " + coins + " coins"); 
        }
    }
}
