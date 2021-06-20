using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour
{
    public float speed;
    public GameObject playerBullet;
    public GameObject barrel01;
    public GameObject barrel02;
    public GameObject gamemanager;
    public int maxLives;
    int lives;
    int score;

    public int Score { 
        get {
            return score;
        } 
        set {
            score = value;
            UpdateScoreTextUI();
        }
    }

    public void Init()
    {
        lives = maxLives;
        OpenGameMenu.Instance.SetTextOfLives(lives.ToString());
        gameObject.SetActive(true);
        transform.position = new Vector2(0, 0);
        Score = 0;
    }
    // Upsate Score Text
    void UpdateScoreTextUI()
    {
        OpenGameMenu.Instance.SetTextOfScore(Score.ToString());
    }
    // Update is called once per frame
    void Update()
    {
        // Get direction
        float xDir = Input.GetAxisRaw("Horizontal");
        float yDir = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(xDir, yDir);
        Move(direction);
    }
    private void Move(Vector2 dir)
    {
        Vector2 min = CameraManager.GetObjectMinLimitInCamera(gameObject);
        Vector2 max = CameraManager.GetObjectMaxLimitInCamera(gameObject);
        // Calculate new position
        Vector2 pos = transform.position;
        pos += speed * dir * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);
        transform.position = pos;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("EnemyShip")|| collision.CompareTag("EnemyBullet"))
        {
            PlayExplosion();

            lives--;
            OpenGameMenu.Instance.SetTextOfLives(lives.ToString());
            if (lives == 0)
            {
                gameObject.SetActive(false);
                gamemanager.GetComponent<GameManager>().SetGamemanagerState(GameManager.GameManagerState.Gameover);
            }
        }
    }
    void PlayExplosion()
    {
        AnimationScript.Instance.PlayExplosionAnim(gameObject.transform.position);
        SoundManager.Instance.PlayExplosionSound();
    }
    public void Shoot()
    {
        GameObject playerBullet01 = PoolManager.Instance.GetPoolObject(PoolObjectType.PlayerBullet);
        playerBullet01.transform.position = barrel01.transform.position;
        playerBullet01.SetActive(true);
        GameObject playerBullet02 = PoolManager.Instance.GetPoolObject(PoolObjectType.PlayerBullet);
        playerBullet02.transform.position = barrel02.transform.position;
        playerBullet02.SetActive(true);
        SoundManager.Instance.PlayShootingSound();
        Invoke("Shoot", 0.2f);
    }
    public void CancelShooting()
    {
        CancelInvoke("Shoot");
    }
}
