using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Slider _slider;

    [SerializeField] private Toggle _toggle;

    public string messaggioPersonalizzato = "Ciao dal codice!";

    void OnEnable()
    {
        // Eventi Button standard
        _button.onClick.AddListener(() => Interazione(messaggioPersonalizzato));
        _button.onClick.AddListener(InterazioneSemplice);

        _slider.onValueChanged.AddListener(OnSlideChanged);

        _toggle.onValueChanged.AddListener(OnToggleChanged);

        // Altri eventi tramite EventTrigger
        // AggiungiEventiAggiuntivi();
    }

    private void OnToggleChanged(bool isOn)
    {
        Debug.Log($"Toggle is now {(isOn ? "ON" : "OFF")}");
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
        
    public void OnSlideChanged(float valore)
    {
        Debug.Log($"Valore dello slider cambiato: {valore:F2}");
    }
}
