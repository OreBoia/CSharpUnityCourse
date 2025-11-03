using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Per ricevere eventi su un oggetto UI, questo script deve essere associato a un GameObject
// che ha anche un componente grafico (es. Image, Text, Button) con "Raycast Target" abilitato.
public class UIInteractionHandler : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler,
    IPointerDownHandler,
    IPointerUpHandler,
    IPointerClickHandler,
    IDragHandler,
    IBeginDragHandler,
    IEndDragHandler,
    ISelectHandler,
    IDeselectHandler,
    IMoveHandler
{
    // Implementazione di IPointerClickHandler
    public void OnPointerClick(PointerEventData eventData)
    {
        // Debug.Log("Oggetto cliccato (tramite interfaccia)");
    }

    // Implementazione di IPointerDownHandler
    public void OnPointerDown(PointerEventData eventData)
    {
        // Debug.Log("Puntatore premuto sull'oggetto (tramite interfaccia)");
        // if(eventData.button == PointerEventData.InputButton.Left)
        // {
        //     Debug.Log("Clic sinistro rilevato");
        //     Debug.Log($"Numero di clic: {eventData.clickCount}");

        //     if(eventData.clickCount == 2)
        //     {
        //         Debug.Log("Doppio clic rilevato!");
        //         gameObject.GetComponent<Image>().color = new Color(Random.value, Random.value, Random.value);
        //     }
        // }
    }

    // Implementazione di IPointerUpHandler
    public void OnPointerUp(PointerEventData eventData)
    {
        // Debug.Log("Puntatore rilasciato sull'oggetto (tramite interfaccia)");
    }

    // Implementazione di IPointerEnterHandler
    public void OnPointerEnter(PointerEventData eventData)
    {
        // Debug.Log("Puntatore entrato nell'area dell'oggetto (tramite interfaccia)");
    }

    // Implementazione di IPointerExitHandler
    public void OnPointerExit(PointerEventData eventData)
    {
        // Debug.Log("Puntatore uscito dall'area dell'oggetto (tramite interfaccia)");
    }

    // Implementazione di IDragHandler
    public void OnDrag(PointerEventData eventData)
    {
        // Debug.Log($"Trascinamento in corso: {eventData.delta} (tramite interfaccia)");
        // transform.position += (Vector3)eventData.delta;
    }

    // Implementazione di ISelectHandler
    public void OnBeginDrag(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // throw new System.NotImplementedException();
    }

    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("Oggetto selezionato (tramite interfaccia)");
    }

    // Implementazione di IDeselectHandler
    public void OnDeselect(BaseEventData eventData)
    {
        Debug.Log("Oggetto deselezionato (tramite interfaccia)");
    }


    public void OnMove(AxisEventData eventData)
    {
        Debug.Log($"Movimento con input direzionale: {eventData.moveDir} (tramite interfaccia)");
    }

}
