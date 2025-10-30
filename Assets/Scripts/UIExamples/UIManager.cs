using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button _button;

    public string messaggioPersonalizzato = "Ciao dal codice!";

    void OnEnable()
    {
        // Eventi Button standard
        _button.onClick.AddListener(() => Interazione(messaggioPersonalizzato));
        _button.onClick.AddListener(InterazioneSemplice);

        // Altri eventi tramite EventTrigger
        // AggiungiEventiAggiuntivi();
    }
    
    // void AggiungiEventiAggiuntivi()
    // {
        // Ottieni o aggiungi EventTrigger component
    //     EventTrigger trigger = _button.GetComponent<EventTrigger>();
    //     if (trigger == null)
    //         trigger = _button.gameObject.AddComponent<EventTrigger>();
        
    //     // Pointer Enter (mouse hover)
    //     EventTrigger.Entry entryEnter = new EventTrigger.Entry();
    //     entryEnter.eventID = EventTriggerType.PointerEnter;
    //     entryEnter.callback.AddListener((data) => { OnPointerEnter((PointerEventData)data); });
    //     trigger.triggers.Add(entryEnter);
        
    //     // Pointer Exit (mouse leave)
    //     EventTrigger.Entry entryExit = new EventTrigger.Entry();
    //     entryExit.eventID = EventTriggerType.PointerExit;
    //     entryExit.callback.AddListener((data) => { OnPointerExit((PointerEventData)data); });
    //     trigger.triggers.Add(entryExit);
        
    //     // Pointer Down (mouse press down)
    //     EventTrigger.Entry entryDown = new EventTrigger.Entry();
    //     entryDown.eventID = EventTriggerType.PointerDown;
    //     entryDown.callback.AddListener((data) => { OnPointerDown((PointerEventData)data); });
    //     trigger.triggers.Add(entryDown);
        
    //     // Pointer Up (mouse release)
    //     EventTrigger.Entry entryUp = new EventTrigger.Entry();
    //     entryUp.eventID = EventTriggerType.PointerUp;
    //     entryUp.callback.AddListener((data) => { OnPointerUp((PointerEventData)data); });
    //     trigger.triggers.Add(entryUp);
        
    //     // Drag (trascinamento)
    //     EventTrigger.Entry entryDrag = new EventTrigger.Entry();
    //     entryDrag.eventID = EventTriggerType.Drag;
    //     entryDrag.callback.AddListener((data) => { OnDrag((PointerEventData)data); });
    //     trigger.triggers.Add(entryDrag);

    //     // Select (quando l'oggetto viene selezionato tramite navigazione)
    //     EventTrigger.Entry entrySelect = new EventTrigger.Entry();
    //     entrySelect.eventID = EventTriggerType.Select;
    //     entrySelect.callback.AddListener((data) => { OnSelect(data); });
    //     trigger.triggers.Add(entrySelect);

    //     // Deselect (quando l'oggetto perde la selezione)
    //     EventTrigger.Entry entryDeselect = new EventTrigger.Entry();
    //     entryDeselect.eventID = EventTriggerType.Deselect;
    //     entryDeselect.callback.AddListener((data) => { OnDeselect(data); });
    //     trigger.triggers.Add(entryDeselect);
    // }

    public void Interazione(string messaggio)
    {
        Debug.Log($"il tasto premuto dice {messaggio}");
    }

    public void InterazioneSemplice(){

    }
    
    // Gestori degli eventi del mouse/touch
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("Mouse entrato nel button");
        // Esempio: cambia colore o scala
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("Mouse uscito dal button");
        // Esempio: ripristina colore o scala
    }
    
    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("Button premuto (mouse down)");
        // Esempio: effetto di pressione
    }
    
    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("Button rilasciato (mouse up)");
        // Esempio: ripristina da effetto pressione
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log($"Button trascinato: {eventData.delta}");
    }
    
    // Gestori degli eventi di selezione
    public void OnSelect(BaseEventData eventData)
    {
        Debug.Log("Button selezionato");
        // Esempio: mostra un bordo di selezione per la navigazione da tastiera/gamepad
    }

    public void OnDeselect(BaseEventData eventData)
    {
        Debug.Log("Button deselezionato");
        // Esempio: nascondi il bordo di selezione
    }
}
