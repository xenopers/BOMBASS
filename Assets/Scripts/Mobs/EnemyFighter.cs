using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFighter : Mobs
{
    SoundManager sm;

    private Material matBlink;
    private Material matDefault;
    private SpriteRenderer spriteRenderer;

    public int direction = 1;
    public GameObject bulletPrefab;
    public GameObject explosionPrefab;
    public Transform bulletPos;
    private Transform playerPosition;
    Rigidbody2D rb;
    bool canShoot = false;
    public float positionDifference, reloadTime;
    public static new float speed;

    public float bulletSpawnInterval;
    public float offset = 6; // Offset from the right side of the camera

    private Camera mainCamera;
    private float toReachPosition;

    new void Start()
    {
        mainCamera = Camera.main;

        // Calculate the position based on the right side of the camera
        Vector3 cameraRightEdge = mainCamera.ViewportToWorldPoint(new Vector3(1, 0.5f, mainCamera.nearClipPlane));
        toReachPosition = cameraRightEdge.x - offset;

        Invoke(nameof(Reload), reloadTime/3);
        base.Start();
        gm.NumFighters++;
        rb = GetComponent<Rigidbody2D>();
        playerPosition = GameObject.Find("Fighter").GetComponent<Transform>(); 
        sm = gm.GetComponent<SoundManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        matBlink = Resources.Load("JetBlink", typeof(Material)) as Material;
        matDefault = spriteRenderer.material;
    }

    private void FixedUpdate()
    {
        if(transform.position.x != toReachPosition)
        transform.position = Vector2.Lerp(transform.position, new Vector3(toReachPosition, transform.position.y, 0), 10 * Time.deltaTime);
    }
    void Update()
    {
        
         EnemyMove();
        if (playerPosition != null)
        {
            if (canShoot)
            {
                positionDifference = Vector3.Distance(new Vector3(0, playerPosition.transform.position.y, 0), new Vector3(0, transform.position.y, 0));
                if (direction == 1)
                {
                    positionDifference = Vector3.Distance(new Vector3(0, playerPosition.transform.position.y, 0), new Vector3(0, transform.position.y - 1.5f, 0));
                    if (positionDifference <= 1f) Shoot();
                }
                else if (positionDifference <= 1.5f) Shoot();
            }
        }
    }


    public void Blink()
    {
        spriteRenderer.material = matBlink;
        Invoke("ResetMaterial", 0.2f);
    }

    void ResetMaterial() => spriteRenderer.material = matDefault;
    public void EnemyMove()
    {
        UpdateSpeed();
        rb.velocity = new Vector2(0, speed * direction);
    }

    private void UpdateSpeed()
    {
        switch(gm.NumFighters)
        {
            case 6:
                speed = 2.5f;
                break;
            case 5:
                speed = 3f;
                break;
            case 4:
                speed = 3.5f;
                break;
            case 3:
                speed = 4f;
                break;
            case 2:
                speed = 5f;
                break;
            case 1:
                speed = 6f;
                break;
        }
    }

    /*private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, detectionSize);
    }*/

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
            sm.PlayJetShootSound();
            Instantiate(bulletPrefab, bulletPos.transform.position, transform.rotation).GetComponent<EnemyBulletBehaviour>().damage = damage;
            yield return new WaitForSeconds(bulletSpawnInterval);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("EnemyJet") || collision.gameObject.CompareTag("Collider"))
        {
            direction *= -1;
            EnemyMove();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("EnemyJet") || collision.gameObject.CompareTag("Collider"))
        {
            if (transform.position.y > collision.gameObject.transform.position.y) direction = 1;
            else direction = -1;
            EnemyMove();
        }
            
    }

    private void OnDestroy()
    {
        gm.NumFighters--;
        gm.Score += gm.JetScore;
        if (!gameObject.scene.isLoaded) return;
        gm.IncreaseDestroyedEnemy("destroyedFighters");
        gm.OnDestroyItemGenerator(gameObject.transform.position, true);
        Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        sm.PlayJetExplosionSound();
    }


}
