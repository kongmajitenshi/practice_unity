using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;  // 총알 원본 설계도(청사진)
    [SerializeField] private Transform playerTransform;  // 조준할 플레이어 위치
    [SerializeField] private float spawnInterval = 0.5f;  // 스폰 주기

    private float timer = 0f;
    private Camera mainCam;

    private void Awake()
    {
        mainCam = Camera.main;
    }

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
        if (playerTransform == null || mainCam == null) return;
        
        float camHeight = mainCam.orthographicSize;
        float camWidth = camHeight * mainCam.aspect;

        float padding = 1f;
        float spawnX = camWidth + padding;
        float spawnY = camHeight + padding;
        
        Vector3 spawnPosition = Vector3.zero;
        
        int side = Random.Range(0, 4);

        switch (side)
        {
            case 0:
                spawnPosition = new Vector3(Random.Range(-camWidth, camWidth),camHeight, 0);
                break;
            case 1:
                spawnPosition = new Vector3(Random.Range(-camWidth, camWidth),-camHeight, 0);
                break;
            case 2:
                spawnPosition = new Vector3(-camWidth, Random.Range(-camHeight, camHeight), 0);
                break;
            case 3:
                spawnPosition = new Vector3(camWidth, Random.Range(-camHeight, camHeight), 0);
                break;
        }
        
        // 총알 생성
        GameObject newBullet = Instantiate(bulletPrefab, spawnPosition, Quaternion.identity);
        Vector2 directionToPlayer = playerTransform.position - spawnPosition;
        newBullet.GetComponent<Bullet>().SetDirection(directionToPlayer);
    }
    
}
