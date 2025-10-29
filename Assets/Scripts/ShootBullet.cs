using UnityEngine;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] private GameObject _prefabToSpawn;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private float _shootForce;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var bullet = Instantiate(_prefabToSpawn, null);
            bullet.transform.position = _spawnPoint.position;
            bullet.SetActive(true);
    
            var rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * _shootForce, ForceMode.Impulse);
        }
    }
}
