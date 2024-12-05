using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{

    public float speed;
    public MeshRenderer meshRenderer;

    private Vector2 meshOffset;
    void Start()
    {
        meshOffset = meshRenderer.sharedMaterial.mainTextureOffset;
        if (IsTablet()) speed *= 1.4f;
        
    }

    void OnDisable()
    {
        meshRenderer.sharedMaterial.mainTextureOffset = meshOffset;
    }
    void Update()
    {
        var x = Mathf.Repeat(Time.time * speed, 1);
        var offset = new Vector2(x, meshOffset.y);
        
        meshRenderer.sharedMaterial.mainTextureOffset = offset;
    }

    public static bool IsTablet()
    {
        float ratio = (float)Screen.width / Screen.height;

        if (ratio <= 1.5) return true;
        return false;

    }

}
