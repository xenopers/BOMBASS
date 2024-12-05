using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{

    public float speed;
    public int damage;
    Rigidbody2D rb;
    public bool isRight;
    SoundManager sm;

    private Vector2 screenBounds;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        if (isRight) rb.velocity = transform.right * speed;
        else rb.velocity = -transform.right * speed;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        sm = GameObject.Find("Game Manager").GetComponent<SoundManager>();
    }

    private void Update()
    {
        if (transform.position.x > screenBounds.x || transform.position.x < -screenBounds.x)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        Mobs mob = collision.GetComponent<Mobs>();

        if (mob != null)
        {
            mob.TakeDamage(damage);
            if (mob is EnemyFighter)
            {
                EnemyFighter jet = (EnemyFighter)mob;
                jet.Blink();
                sm.PlayJetHitSound();
            }
            else if (mob is DroneController)
            {
                DroneController drone = (DroneController)mob;
                drone.Blink();
                sm.PlayJetHitSound();
            }

            Destroy(gameObject);
        }
    }
}
