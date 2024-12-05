using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassiveGroundEnemy : Mobs
{
    Rigidbody2D rb;
    Vector2 screenBounds;
    SoundManager sm;
    bool isOutScreen = false;
    public GameObject explosionPrefab;
    new void Start()
    {
        base.Start();
        gm.NumVehicles++;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        sm = gm.GetComponent<SoundManager>();
    }

    void Update()
    {
        if (transform.position.x < -screenBounds.x - 10f)
        {
            Destroy(gameObject);
            gm.Score -= gm.VehicleScore;
            isOutScreen = true;
        }
    }

    public void OnDestroy()
    {
        gm.Score += gm.VehicleScore;
        gm.NumVehicles--;
        if (!gameObject.scene.isLoaded) return;
        gm.OnDestroyItemGenerator(gameObject.transform.position, false);
        if (!isOutScreen)
        {
            sm.PlayVehicleExplosionSound();
            gm.IncreaseDestroyedEnemy("destroyedBTRs");
        }
        Instantiate(explosionPrefab, transform.position + new Vector3(0, 8), Quaternion.identity);

    }
}
