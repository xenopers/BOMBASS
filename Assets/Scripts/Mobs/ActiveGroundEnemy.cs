using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGroundEnemy : Mobs
{
    public GameObject bulletPos;
    public GameObject bulletPrefab;
    public float reloadTime;
    bool canShoot = false;

    SoundManager sm;
    float angle;
    Vector3 direction;

    public float bulletSpawnInterval;

    Transform playerPosition;
    Rigidbody2D rb;
    SpriteRenderer sprite;
    new void Start()
    {
        base.Start();
        Invoke(nameof(Reload), 0.3f);
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        sprite = GetComponent<SpriteRenderer>();
        playerPosition = GameObject.Find("Fighter").GetComponent<Transform>();
        sm = gm.GetComponent<SoundManager>();
    }


    void Update()
    {
        if(playerPosition != null)
        {
            direction = playerPosition.position - transform.position;
            angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        }
        
        if (angle >= 90) sprite.flipY = true;
        else sprite.flipY = false;
        transform.rotation = Quaternion.Euler(0f, 0f, angle);
        
        if(canShoot) Shoot();

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
