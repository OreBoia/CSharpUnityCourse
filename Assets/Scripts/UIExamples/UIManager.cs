using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button _button;

    public string messaggioPersonalizzato = "Ciao dal codice!";

    void OnEnable()
    {
        _button.onClick.AddListener(() => Interazione(messaggioPersonalizzato));
        _button.onClick.AddListener(InterazioneSemplice);
    }

    public void Interazione(string messaggio)
    {
        Debug.Log($"il tasto premuto dice {messaggio}");
    }

    public void InterazioneSemplice(){

    }
}
