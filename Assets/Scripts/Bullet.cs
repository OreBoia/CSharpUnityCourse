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
        Destroy(gameObject);
    }

}
