using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigController : MonoBehaviour
{
    public GameObject bulletPos;
    public GameObject bulletPrefab;
    public float reloadTime;
    bool canShoot = false;
    public float speed;
    public int damage;


    SoundManager sm;
    float angle;
    Vector3 direction;

    public float bulletSpawnInterval;

    GameManager gm;
    Transform playerPosition;
    Rigidbody2D rb;
    SpriteRenderer[] sprite;

    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        Invoke(nameof(Reload), 1f);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        sprite = GetComponentsInChildren<SpriteRenderer>();
        playerPosition = GameObject.Find("Fighter").GetComponent<Transform>();
        sm = gm.GetComponent<SoundManager>();
        
    }

    void Update()
    {
        if (playerPosition != null)
        {
            direction = playerPosition.position - transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }

        if (angle >= 90)
        {
            sprite[0].flipY = true;
            sprite[1].flipY = true;
        }
        else
        {
            sprite[0].flipY = false;
            sprite[1].flipY = false;
        }
        transform.rotation = Quaternion.Euler(0f, 0f, angle);

        if (canShoot) Shoot();

    }

    void Shoot()
    {
        if (!canShoot) return;
        canShoot = false;

        StartCoroutine(MachineGun());

        Invoke(nameof(Reload), reloadTime);
    }

    void Reload()
    {
        canShoot = true;
    }

    IEnumerator MachineGun()
    {
        for (int i = 0; i < 3; i++)
        {
            sm.PlayPigShootSound();
            Instantiate(bulletPrefab, bulletPos.transform.position, transform.rotation).GetComponent<EnemyBulletBehaviour>().damage = damage;
            yield return new WaitForSeconds(bulletSpawnInterval);
        }
    }

}
