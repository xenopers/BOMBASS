using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class AnchorGameObject : MonoBehaviour
{
    public enum AnchorType
    {
        BottomLeft,
        BottomCenter,
        BottomRight,
        MiddleLeft,
        MiddleCenter,
        MiddleRight,
        TopLeft,
        TopCenter,
        TopRight,
    };

    //public bool executeInUpdate;

    public AnchorType anchorType;
    public Vector3 anchorOffset;

    //IEnumerator updateAnchorRoutine; // Coroutine handle so we don't start it if it's already running

    // Use this for initialization
    void Start()
    {
        UpdateAnchor();
    }

    void UpdateAnchor()
    {
        if (CameraViewportHandler.Instance == null)
        {
            Debug.LogWarning("CameraViewportHandler.Instance is null. Anchor update skipped.");
            return;
        }

        switch (anchorType)
        {
            case AnchorType.BottomLeft:
                SetAnchor(CameraViewportHandler.Instance.BottomLeft);
                break;
            case AnchorType.BottomCenter:
                SetAnchor(CameraViewportHandler.Instance.BottomCenter);
                break;
            case AnchorType.BottomRight:
                SetAnchor(CameraViewportHandler.Instance.BottomRight);
                break;
            case AnchorType.MiddleLeft:
                SetAnchor(CameraViewportHandler.Instance.MiddleLeft);
                break;
            case AnchorType.MiddleCenter:
                SetAnchor(CameraViewportHandler.Instance.MiddleCenter);
                break;
            case AnchorType.MiddleRight:
                SetAnchor(CameraViewportHandler.Instance.MiddleRight);
                break;
            case AnchorType.TopLeft:
                SetAnchor(CameraViewportHandler.Instance.TopLeft);
                break;
            case AnchorType.TopCenter:
                SetAnchor(CameraViewportHandler.Instance.TopCenter);
                break;
            case AnchorType.TopRight:
                SetAnchor(CameraViewportHandler.Instance.TopRight);
                break;
        }
    }

    void SetAnchor(Vector3 anchor)
    {
        Vector3 newPos = anchor + anchorOffset;
        transform.position = newPos;
    }


}
