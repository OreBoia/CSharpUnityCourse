using UnityEngine;

public class GenerateCube : MonoBehaviour
{
    [SerializeField] private int _cubeToSpawn = 3;
    [SerializeField] private GameObject _prefabToSpawn;

    void Start()
    {
        for(int i = 0; i<_cubeToSpawn; i++)
        {
            Instantiate(_prefabToSpawn, Vector3.zero, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
