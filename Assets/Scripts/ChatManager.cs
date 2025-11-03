using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class ChatManager : MonoBehaviour
{
    [Header("Riferimenti UI")]
    [SerializeField] private TMP_InputField nomeInput;
    [SerializeField] private TMP_InputField messaggioInput;
    [SerializeField] private Button inviaButton;

    [Header("Riferimenti ScrollView")]
    [SerializeField] private GameObject messaggioPrefab;
    [SerializeField] private Transform contentParent;
    [SerializeField] private ScrollRect scrollRect;
    private static string chat;

    void Start()
    {
        // inviaButton.onClick.AddListener(InviaMessaggio);
        for(int i = 0; i < 10; i++)
        {
            InviaMessaggio();
        }
    }
    private void InviaMessaggio()
    {
        string nome = "nomeInput.text";
        string messaggio = "messaggioInput.text";

        if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(messaggio))
        {
            return;
        }

        GameObject nuovoMessaggioGO = Instantiate(messaggioPrefab, contentParent);

        TextMeshProUGUI testoMessaggio = nuovoMessaggioGO.GetComponentInChildren<TextMeshProUGUI>();
        testoMessaggio.text = "<b>" + nome + ":</b> " + messaggio;

        // nomeInput.text = "";
        // messaggioInput.text = "";

        // messaggioInput.Select();
        // messaggioInput.ActivateInputField();
        Canvas.ForceUpdateCanvases();
        scrollRect.verticalNormalizedPosition = 0;
        // StartCoroutine(ScrollToBottom());
    }
    
    private IEnumerator ScrollToBottom()
    {
        // Aspetta un frame per permettere al layout di aggiornarsi
        yield return null;
        scrollRect.verticalNormalizedPosition = 0;
    }
}