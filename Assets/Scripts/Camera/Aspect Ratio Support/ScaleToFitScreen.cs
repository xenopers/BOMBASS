using UnityEngine;

public class ScaleToFitScreen : MonoBehaviour
{
    private MeshFilter meshFilter;

    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();

        // World height is always camera's orthographicSize * 2
        float worldScreenHeight = Camera.main.orthographicSize * 2;

        // World width is calculated by diving world height with screen height
        // then multiplying it with screen width
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        // To scale the game object, we divide the world screen width with the
        // size x of the mesh, and we divide the world screen height with the
        // size y of the mesh
        Vector3 meshSize = meshFilter.mesh.bounds.size;
        transform.localScale = new Vector3(
            worldScreenWidth / meshSize.x,
            worldScreenHeight / meshSize.y - 2,
            1);

    }
}
