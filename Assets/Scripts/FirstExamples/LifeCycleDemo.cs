using UnityEngine;

public class LifeCycleDemo : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("Mi sono svegliato. Awake()");
    }

    void OnEnable()
    {
        Debug.Log("Mi sono Attivato. OnEnable()");
    }

    void Start()
    {
        Debug.Log("Mi sono Avviato. Start()");
    }

    void Update()
    {
        Debug.Log("Mi sto Aggiornando. Update()");

        if (Input.GetKeyDown(KeyCode.A))
        {
            print("Hai premuto il tasto A");
        }
    }

    void FixedUpdate()
    {
        Debug.Log("Mi sto Aggiornando ad un intervallo regolare. FixedUpdate()");
    }

    void LateUpdate()
    {
        print("Mi sto aggiornando dopo tutti gli altri. LateUpdate()");
    }

    void OnDisable()
    {
        print("Mi sto Disabilitando. OnDisable()");
    }

    void OnDestroy()
    {
        print("Mi sto per distruggere. Addio!. OnDestroy()");
    }
}
