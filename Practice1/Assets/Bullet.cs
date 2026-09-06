using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 3f;
    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
