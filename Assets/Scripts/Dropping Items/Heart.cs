using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : Item
{
   private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            if(player.currentHealth < player.maxHealth)
            {
                if (player.currentHealth >= player.maxHealth)
                {
                    player.currentHealth = player.maxHealth;
                }
                else player.currentHealth += quantity;
                    
            }
        }
    }

}
