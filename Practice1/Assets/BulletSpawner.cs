using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float spawnInterval = 0.5f;

    private float timer = 0f;
    private float spawnDistanceX = 10f;
    private float spawnDistanceY = 6f;


    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
