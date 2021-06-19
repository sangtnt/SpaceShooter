using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    public float speed;
    bool dead;
    // Start is called before the first frame update
    void Start()
    {
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;
        pos.y -= speed * Time.deltaTime;
        transform.position = pos;

        Vector2 min = CameraManager.GetCameraMin();
        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("PlayerBullet") || collision.CompareTag("PlayerShip"))
        {
            Destroy(gameObject);
            PlayExplosion();
            PlayerControl playerControl = FindObjectOfType<PlayerControl>();
            if (!dead)
            {
                playerControl.Score += 100;
                dead = true;
            }
        }
    }
    void PlayExplosion()
    {
        AnimationScript.Instance.PlayExplosionAnim(gameObject.transform.position);
        SoundManager.Instance.PlayExplosionSound();
    }
}
