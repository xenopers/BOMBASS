
using UnityEngine.EventSystems;
using UnityEngine;

public class MachineGunButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
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
            if (fighter.canUseMachineGun)
            {
                StartCoroutine(fighter.MachineGun());
                fighter.canUseMachineGun = false;
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
