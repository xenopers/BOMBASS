using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollider: MonoBehaviour
{
    private Camera mainCamera;
    BoxCollider2D groundCollider;
    void Start()
    {
        mainCamera = Camera.main;
        groundCollider = gameObject.AddComponent<BoxCollider2D>();
        groundCollider.size = new Vector2(mainCamera.orthographicSize * 2 * mainCamera.aspect, 1f);
        groundCollider.offset = new Vector2(0, (-mainCamera.orthographicSize - 1f / 2) + 3f);
    }

}
