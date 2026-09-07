using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Vector2 moveDirection;
    
    public void SetDirection(Vector2 dir)
    {
        moveDirection = dir.normalized;  // 대각선 속도 보정
    }

    private void Start()
    {
        Destroy(gameObject, 3f);  // 화면 밖으로 사라지고 3초 후 삭제
    }

    void Update()
    {
        transform.position += (Vector3)moveDirection * speed * Time.deltaTime;
    }
}
