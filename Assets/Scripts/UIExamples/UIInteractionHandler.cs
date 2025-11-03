using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// Per ricevere eventi su un oggetto UI, questo script deve essere associato a un GameObject
// che ha anche un componente grafico (es. Image, Text, Button) con "Raycast Target" abilitato.
public class UIInteractionHandler : Selectable,
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
    // Limiti per il trascinamento
    float minX;
    float maxX;
    float minY;
    float maxY;

    protected override void Start()
    {
        base.Start();
        GetRectTransform();
    }

    // Implementazione di IPointerClickHandler
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Oggetto cliccato (tramite interfaccia)");
    }

    // Implementazione di IPointerDownHandler
    public override void OnPointerDown(PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        Debug.Log("Puntatore premuto sull'oggetto (tramite interfaccia)");
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Debug.Log("Clic sinistro rilevato");
            Debug.Log($"Numero di clic: {eventData.clickCount}");

            if (eventData.clickCount == 2)
            {
                Debug.Log("Doppio clic rilevato!");
                gameObject.GetComponent<Image>().color = new Color(Random.value, Random.value, Random.value);
            }
        }
    }

    // Implementazione di IPointerUpHandler
    public override void OnPointerUp(PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        Debug.Log("Puntatore rilasciato sull'oggetto (tramite interfaccia)");
    }

    // Implementazione di IPointerEnterHandler
    public override void OnPointerEnter(PointerEventData eventData)
    {
        base.OnPointerEnter(eventData);
        Debug.Log("Puntatore entrato nell'area dell'oggetto (tramite interfaccia)");
    }

    // Implementazione di IPointerExitHandler
    public override void OnPointerExit(PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
        Debug.Log("Puntatore uscito dall'area dell'oggetto (tramite interfaccia)");
    }

    // Implementazione di IDragHandler
    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log($"Trascinamento in corso: {eventData.delta} (tramite interfaccia)");
        transform.position += (Vector3)eventData.delta;
        ClampPosition();
    }

    private void ClampPosition()
    {
        RectTransform rt = transform as RectTransform;
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX + rt.rect.width / 2, maxX - rt.rect.width / 2);
        pos.y = Mathf.Clamp(pos.y, minY + rt.rect.height / 2, maxY - rt.rect.height / 2);
        transform.position = pos;
    }

    // Implementazione di IBeginDragHandler
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Inizio trascinamento (tramite interfaccia)");
    }

    // Implementazione di IEndDragHandler
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Fine trascinamento (tramite interfaccia)");
    }

    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);
        Debug.Log("Oggetto selezionato (tramite interfaccia)");
    }

    // Implementazione di IDeselectHandler
    public override void OnDeselect(BaseEventData eventData)
    {
        base.OnDeselect(eventData);
        Debug.Log("Oggetto deselezionato (tramite interfaccia)");
    }


    public override void OnMove(AxisEventData eventData)
    {
        Debug.Log($"Movimento con input direzionale: {eventData.moveDir} (tramite interfaccia)");
    }

    public Image Limits;
    private void GetRectTransform()
    {
        if (Limits == null)
        {
            Limits = GetComponent<Image>();
        }

        RectTransform rt = Limits.rectTransform;
        Vector3[] corners = new Vector3[4];
        rt.GetWorldCorners(corners);

        minX = corners[0].x;
        maxX = corners[0].x;
        minY = corners[0].y;
        maxY = corners[0].y;

        for (int i = 1; i < corners.Length; i++)
        {
            if (corners[i].x < minX) minX = corners[i].x;
            if (corners[i].x > maxX) maxX = corners[i].x;
            if (corners[i].y < minY) minY = corners[i].y;
            if (corners[i].y > maxY) maxY = corners[i].y;
        }

        Debug.Log($"RectTransform World Corners - MinX: {minX}, MaxX: {maxX}, MinY: {minY}, MaxY: {maxY}");
    }
}
