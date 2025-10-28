using UnityEngine;

public class FirstScript : MonoBehaviour
{
    void Start()
    {
        Debug.Log($"Mia Posizione: {transform.position}");
        Debug.Log($"Sono nel GameObject: {gameObject.name}");
    }

    // Richiamato ogni Frame
    void Update()
    {
        transform.position += new Vector3(0f, 0f, 0.01f);
        transform.Rotate(new Vector3(0f, -0.1f, 0f));
        transform.localScale += new Vector3(0.1f, 0f, 0f);

        Debug.Log($"Mia Posizione Attuale: {transform.position}");
    }
}
