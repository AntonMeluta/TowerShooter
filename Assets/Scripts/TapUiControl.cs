using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapUiControl : MonoBehaviour, IDragHandler, IPointerDownHandler, 
    IPointerUpHandler
{
    public PlayerMovement playerMovement; //событие вызывать
    public IkArmControl ikArmControl; //событие вызывать

    public LayerMask layersClickable;

    public void OnDrag(PointerEventData eventData)
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, layersClickable))
        {
            playerMovement.GoTargetMoving(hit.point);
        }

        // Таргетирование для стрельбы, вызов событий
        ikArmControl.TryShootingOn();
        ikArmControl.CubeCostil(hit.point);     //событие передвижения цели кинематик-анимации руки
        //Вызов события для стрельбы
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, layersClickable))
        {
            playerMovement.GoTargetMoving(hit.point);
        }

        ikArmControl.TryShootingOn();
        ikArmControl.CubeCostil(hit.point);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // Таргетирование для стрельбы, вызов события
        ikArmControl.TryShootingOff();
    }
}
