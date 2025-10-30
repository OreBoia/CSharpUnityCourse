using UnityEngine;

public class CheckPercorso : MonoBehaviour
{
    [SerializeField] private Transform _startPoint;

    void OnTriggerEnter(Collider other)
    {
        var collision = other.gameObject;
        // if (collision.CompareTag("Wall"))
        // {
        //     transform.position = _startPoint.position;
        // }

        if (collision.CompareTag("End"))
        {
            Debug.Log("SONO ARRIVATO ALLA FINE DEL PERCORSO");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        var go = collision.gameObject;

        if (go.CompareTag("Wall"))
        {
            transform.position = _startPoint.position;
        }
    }
}
