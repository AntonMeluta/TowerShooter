using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TapUiControl : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public PlayerMovement playerMovement; //событие вызывать
    public IkArmControl ikArmControl; //событие вызывать

    [SerializeField]
    private LayerMask layersClickable;

    public void OnPointerDown(PointerEventData eventData)
    {
        EventsBroker.TapUpdateStateEvent(true);
        StartCoroutine(TapPressed());
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        EventsBroker.TapUpdateStateEvent(false);
        StopAllCoroutines();        
    }

    private IEnumerator TapPressed()
    {
        while (true)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, layersClickable))
            {
                EventsBroker.TapEvent(hit.point);
            }
            yield return null;
        }
    }
    
}
