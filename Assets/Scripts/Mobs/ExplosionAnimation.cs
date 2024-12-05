using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimation: MonoBehaviour
{
    public void ExplosionDone() => Destroy(gameObject);
}
