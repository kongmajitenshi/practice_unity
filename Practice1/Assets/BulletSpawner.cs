using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;  // 총알 원본 설계도(청사진)
    [SerializeField] private Transform playerTransform;  // 조준할 플레이어 위치
    [SerializeField] private float spawnInterval = 0.5f;  // 스폰 주기

    private float timer = 0f;
    private float spawnDistanceX = 10f;
    private float spawnDistanceY = 6f;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnInterval)
        {
            spawnBullet();
            timer = 0f;
        }
    }

    void spawnBullet()
    {
        if (playerTransform == null) return;
        Vector3 spawnPosition = Vector3.zero;
        int side = Random.Range(0, 4);

        switch (side)
        {
            case 0:
                spawnPosition = new Vector3(Random.Range(-spawnDistanceX, spawnDistanceX),spawnDistanceY, 0);
                break;
            case 1:
                spawnPosition = new Vector3(Random.Range(-spawnDistanceX, spawnDistanceX),-spawnDistanceY, 0);
                break;
            case 2:
                spawnPosition = new Vector3(-spawnDistanceX, Random.Range(-spawnDistanceY, spawnDistanceY), 0);
                break;
            case 3:
                spawnPosition = new Vector3(spawnDistanceX, Random.Range(-spawnDistanceY, spawnDistanceY), 0);
                break;
        }
        
        // 총알 생성
        GameObject newBullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
        Vector2 dirctionToPlayer = playerTransform.position - spawnPosition;
        newBullet.GetComponent<Bullet>().SetDirection(dirctionToPlayer);
    }
    
}
