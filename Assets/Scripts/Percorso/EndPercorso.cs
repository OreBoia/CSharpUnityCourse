using UnityEngine;

public class EndPercorso : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<MoveCube>();
        if(player != null)
        {
            if (GameManager.Instance.IsTimerStarted())
            {
                GameManager.Instance.StopTimer();
            }
        }
    }
}
