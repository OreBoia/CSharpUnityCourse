using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float _timeToDie = 5f;
    void Start()
    {
        Destroy(gameObject, _timeToDie);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<ZonaSegnaPunti>())
        {
            Debug.Log($"Colliso contro il segan punti ho guadagnato un punto");
        }
        
        Destroy(gameObject);
    }

}
