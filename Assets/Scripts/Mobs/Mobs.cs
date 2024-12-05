using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mobs : MonoBehaviour
{
    protected GameManager gm;
    public int maxHealth;
    public float currentHealth;
    public float speed;
    public int damage;

    public void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        currentHealth = maxHealth;
    }
    public virtual void TakeDamage(int damage)
    {
        if(!(this is FighterController)|| GetComponent<FighterController>().canTakeDamage) currentHealth -= damage;
        if (currentHealth <= 0)
        {
            if(this is FighterController) gameObject.SetActive(false);
            else Destroy(gameObject);
        }
    }

}
   
