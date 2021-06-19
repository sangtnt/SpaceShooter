using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float speed;

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.y += speed * Time.deltaTime;
        transform.position = pos;
        Vector2 max = CameraManager.GetCameraMax();
        if (pos.y > max.y)
        {
            PoolManager.Instance.DeactivatePoolObject(gameObject, PoolObjectType.PlayerBullet);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyShip"))
        {
            PoolManager.Instance.DeactivatePoolObject(gameObject, PoolObjectType.PlayerBullet);
        }
    }
}
