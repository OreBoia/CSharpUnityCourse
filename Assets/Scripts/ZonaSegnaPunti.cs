using UnityEngine;

public class ZonaSegnaPunti : MonoBehaviour
{
    [SerializeField] private int _score = 0; //99

    void OnTriggerEnter(Collider other)
    {
        //Bullet entra
        if (other.gameObject.GetComponent<Bullet>()) //riconosce che è un bullet
        {
            if (GameManager.Instance.IncrementaScore(1) >= 10)
            {
                Destroy(gameObject);
            }
        }
    }
}
