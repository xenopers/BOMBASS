using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClusterBombBehaviour : MonoBehaviour
{
    public int damage;
    public float rotationSpeed;
    Rigidbody2D rb;
    SoundManager sm;
    public GameObject explosionPrefab;
    bool touchEnemy;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 horizontal = GameObject.Find("Fighter").GetComponent<Rigidbody2D>().velocity;
        rb.velocity = new Vector2(horizontal.x/2, 0);
        sm = GameObject.Find("Game Manager").GetComponent<SoundManager>();
    }

    void Update()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -90), rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Vehicle") || collision.gameObject.CompareTag("Drone")) touchEnemy = true;
        if(collision.gameObject.CompareTag("Vehicle") || collision.gameObject.CompareTag("Drone") || collision.CompareTag("Ground"))
        {
            Mobs mob = collision.gameObject.GetComponent<Mobs>();
            if(mob != null) mob.TakeDamage(damage);
            Destroy(gameObject);
        }


    }

    private void OnDestroy()
    {
        sm.PlayClusterBombExplosionSound();
        if(!touchEnemy) Instantiate(explosionPrefab, transform.position + new Vector3(0, 5), Quaternion.identity);
    }

}
