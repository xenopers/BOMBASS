using UnityEngine;

public class CameraCollider : MonoBehaviour
{
    private Camera mainCamera;
    private BoxCollider2D leftCollider;
    private BoxCollider2D rightCollider;
    private BoxCollider2D rightSecondCollider;
    private BoxCollider2D topCollider;
    private BoxCollider2D topJetCollider;
    private BoxCollider2D bottomFirstCollider;
    private BoxCollider2D groundCollider;
    private BoxCollider2D bottomSecondCollider;

    public float colliderWidth = 1.0f;

    void Start()
    {
        mainCamera = Camera.main;

        CreateColliders();
    }

    void CreateColliders()
    {
        leftCollider = gameObject.AddComponent<BoxCollider2D>();
        leftCollider.size = new Vector2(colliderWidth, mainCamera.orthographicSize * 2);
        leftCollider.offset = new Vector2(-mainCamera.orthographicSize * mainCamera.aspect - colliderWidth / 2, 0);

        rightCollider = gameObject.AddComponent<BoxCollider2D>();
        rightCollider.size = new Vector2(colliderWidth, mainCamera.orthographicSize * 2);
        rightCollider.offset = new Vector2(mainCamera.orthographicSize * mainCamera.aspect + colliderWidth / 2, 0);

        topCollider = gameObject.AddComponent<BoxCollider2D>();
        topCollider.size = new Vector2(mainCamera.orthographicSize * 2 * mainCamera.aspect, colliderWidth);
        topCollider.offset = new Vector2(0, mainCamera.orthographicSize + colliderWidth / 2);

        topJetCollider = gameObject.AddComponent<BoxCollider2D>();
        topJetCollider.size = new Vector2(mainCamera.orthographicSize * 2 * mainCamera.aspect, colliderWidth);
        topJetCollider.offset = new Vector2(-(mainCamera.orthographicSize * mainCamera.aspect * 0.4f), mainCamera.orthographicSize + colliderWidth / 2 - 1.5f);


        bottomFirstCollider = gameObject.AddComponent<BoxCollider2D>();
        bottomFirstCollider.size = new Vector2(mainCamera.orthographicSize * 2 * mainCamera.aspect, colliderWidth);
        bottomFirstCollider.offset = new Vector2(0, (-mainCamera.orthographicSize - colliderWidth / 2) + 11f);


        bottomSecondCollider = gameObject.AddComponent<BoxCollider2D>();
        bottomSecondCollider.size = new Vector2(mainCamera.orthographicSize * 2 * mainCamera.aspect, colliderWidth);
        bottomSecondCollider.offset = new Vector2(0, (-mainCamera.orthographicSize - colliderWidth / 2));

        rightSecondCollider = gameObject.AddComponent<BoxCollider2D>();
        rightSecondCollider.size = new Vector2(colliderWidth, mainCamera.orthographicSize * 2);
        rightSecondCollider.offset = new Vector2(mainCamera.orthographicSize * mainCamera.aspect * 0.60f, 0);
    }
}
