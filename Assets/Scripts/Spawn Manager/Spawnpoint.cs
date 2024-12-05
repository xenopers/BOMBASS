using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnpoint : MonoBehaviour
{
    bool isAvailable = true;

    public bool IsAvailable
    {
        get { return isAvailable; }
        set { isAvailable = value; }
    }


    public void OnTriggerExit2D(Collider2D collision)
    {
        isAvailable = true;
        //Debug.Log($"{gameObject.name}: is available");
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log($"{gameObject.name}: isn't available");
        isAvailable = false;
    }
}
