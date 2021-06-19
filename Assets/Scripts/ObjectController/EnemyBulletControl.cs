using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletControl : MonoBehaviour
{
    public float speed;
    private Vector2 _direction;
    public void SetDirection(Vector2 dir)
    {
        _direction = dir;
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos += speed * Time.deltaTime * _direction;
        transform.position = pos;

        Vector2 min = CameraManager.GetCameraMin();
        Vector2 max = CameraManager.GetCameraMax();

        if ((pos.x < min.x) || (pos.x > max.x) || (pos.y < min.y) || (pos.y > max.y))
        {
            PoolManager.Instance.DeactivatePoolObject(gameObject, PoolObjectType.EnemyBullet);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerShip"))
        {
            PoolManager.Instance.DeactivatePoolObject(gameObject, PoolObjectType.EnemyBullet);
        }
    }
}
