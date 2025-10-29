using UnityEngine;

public class SpeedBuff : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<MoveCube>();
        if(player != null)
        {
            player.BoostSpeed(2);
        }    
    }    
}
