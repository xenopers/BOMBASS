using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DroneController : Mobs
{
    Rigidbody2D rb;
    Vector2 screenBounds;
    bool isColliding;
    SoundManager sm;
    bool isOutScreen = false;
    public GameObject explosionPrefab;

    private Material matBlink;
    private Material matDefault;
    private SpriteRenderer spriteRenderer;
    new void Start()
    {
        base.Start();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gm.NumDrones++;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2 (-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        sm = gm.GetComponent<SoundManager>();
        matBlink = Resources.Load("JetBlink", typeof(Material)) as Material;
        matDefault = spriteRenderer.material;
    }

    void Update()
    {
        if (transform.position.x < -screenBounds.x - 4f)
        {
            Destroy(gameObject);
            gm.Score -= gm.DroneScore;
            isOutScreen = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            FighterController player = collision.GetComponent<FighterController>();
            player.TakeDamage(damage);
            Destroy(gameObject);
            isColliding = true;
            
        }
    }

    private void OnDestroy()
    {
        gm.Score += gm.DroneScore;
        gm.NumDrones--;
        if(!isColliding)
        {;
            if (!gameObject.scene.isLoaded) return;
            gm.OnDestroyItemGenerator(gameObject.transform.position, true);
        }
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        if (!isOutScreen)
        {
            sm.PlayDroneExplosionSound();
            gm.IncreaseDestroyedEnemy("destroyedDrones");
        }

    }

    public void Blink()
    {
        spriteRenderer.material = matBlink;
        Invoke("ResetMaterial", 0.2f);
    }

    void ResetMaterial() => spriteRenderer.material = matDefault;

}
