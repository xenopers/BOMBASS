using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FighterController : Mobs
{


    SoundManager sm;
    public float machineGunColdown;
    public float clusterBombColdown;

    public bool canUseMachineGun = true;
    float machineGunTimer;
    public bool canUseClusterBomb = true;
    float clusterBombTimer;

    public bool canTakeDamage = true;
    public float bulletSpawnInterval;

    public Transform bulletPos;
    public GameObject bulletPrefab;
    public GameObject clusterBombPrefab;

    private Rigidbody2D rb;
    internal float vertical, horizontal;

    bool isRightMouseButtonHeld;
    bool isLeftMouseButtonHeld;

    private Material matBlink;
    private Material matDefault;
    private SpriteRenderer spriteRenderer;

    new void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody2D>();
        sm = gm.GetComponent<SoundManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        matBlink = Resources.Load("JetBlink", typeof(Material)) as Material;
        matDefault = spriteRenderer.material;
    }

    
    void Update()
    {
        IsMouseButtonsHeld();
        if (!canUseClusterBomb)
        {
            clusterBombTimer += Time.deltaTime;
            if (clusterBombTimer >= clusterBombColdown)
            {
                canUseClusterBomb = true;
                clusterBombTimer = 0;
            }

        } else if(canUseClusterBomb && isRightMouseButtonHeld)
        {
            Instantiate(clusterBombPrefab, bulletPos.transform.position, transform.rotation);
            canUseClusterBomb = false;
        }

        if(!canUseMachineGun)
        {
            machineGunTimer += Time.deltaTime;
            if (machineGunTimer >= machineGunColdown)
            {
                canUseMachineGun = true;
                machineGunTimer = 0;
            }

        } else if(canUseMachineGun && isLeftMouseButtonHeld)
        {
            
            StartCoroutine(MachineGun());
            canUseMachineGun = false;
        }

        vertical = Input.GetAxis("Vertical") * speed;
        horizontal = Input.GetAxis("Horizontal") * speed;
    }


    void IsMouseButtonsHeld()
    {
        if (Input.GetMouseButtonDown(1)) isRightMouseButtonHeld = true;
        if(Input.GetMouseButtonDown(0)) isLeftMouseButtonHeld = true;
        if (Input.GetMouseButtonUp(1)) isRightMouseButtonHeld = false;
        if (Input.GetMouseButtonUp(0)) isLeftMouseButtonHeld = false;

    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal, vertical);
    }

    public IEnumerator MachineGun()
    {
        for(int i = 0; i < 3; i++)
        {
            sm.PlayJetShootSound();
            Instantiate(bulletPrefab, bulletPos.transform.position, transform.rotation).GetComponent<BulletBehaviour>().damage = damage;
            yield return new WaitForSeconds(bulletSpawnInterval);
        }
    }

    
    public IEnumerator Revive()
    {
        canTakeDamage = false;
        for(int i = 0; i < 5; i++)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 100);
            yield return new WaitForSeconds(0.2f);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            yield return new WaitForSeconds(0.5f);
        }
        canTakeDamage = true;

    }

    private void OnDisable()
    {
        gm.GameEnd();
    }

    public void Blink()
    {
        spriteRenderer.material = matBlink;
        Invoke("ResetMaterial", 0.2f);
    }

    void ResetMaterial() => spriteRenderer.material = matDefault;

    public void ChangeSkin(Sprite sprite, Transform bulletPos)
    {
        spriteRenderer.sprite = sprite;
        this.bulletPos= bulletPos;
    }
}
