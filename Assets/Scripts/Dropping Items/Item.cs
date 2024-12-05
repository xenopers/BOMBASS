using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public int dropChance;
    public int speed;
    public int quantity;
    protected Rigidbody2D rb;
    protected FighterController player;
    Vector2 screenBounds;

    SoundManager sm;
    bool isOutScreen = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    protected void Start()
    {
        
        player = GameObject.Find("Fighter").GetComponent<FighterController>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        sm = GameObject.Find("Game Manager").GetComponent<SoundManager>();
    }

    void Update()
    {
        if (transform.position.x < -screenBounds.x - 3f)
        {
            Destroy(gameObject);
            isOutScreen = true;
        }
    }


    public void ChooseDirection(bool x)
    {
        if(x) rb.velocity = new Vector2(-speed, 0); 
        else rb.velocity = new Vector2(0, speed);
    }


    public void OnDestroy()
    {
        if(!isOutScreen) sm.PlayItemPickUpSound();
        
    }
}
