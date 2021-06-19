using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletControl : MonoBehaviour
{
    public float speed;
    private Vector2 _direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }
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
            Destroy(gameObject);
        }
    }
}
