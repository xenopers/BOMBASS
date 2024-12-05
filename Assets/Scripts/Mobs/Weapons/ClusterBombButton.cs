using UnityEngine;
using UnityEngine.EventSystems;

public class ClusterBombButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    FighterController fighter;
    bool pressed = false;
    void Start()
    {
        fighter = FindAnyObjectByType<FighterController>().GetComponent<FighterController>();
    }

    void Update()
    {
        if (pressed)
        {
            if (fighter.canUseClusterBomb)
            {
                Instantiate(fighter.clusterBombPrefab, fighter.bulletPos.transform.position, transform.rotation);
                fighter.canUseClusterBomb = false;
            }
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }
    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }
}
