using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.y += speed * Time.deltaTime;
        transform.position = pos;
        Vector2 max = CameraManager.GetCameraMax();
        if (pos.y > max.y)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyShip"))
        {
            Destroy(gameObject);
        }
    }
}
