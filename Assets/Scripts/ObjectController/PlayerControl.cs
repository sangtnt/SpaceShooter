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
        // Shoot when press Space btn
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject playerBullet01 = Instantiate(playerBullet);
            playerBullet01.transform.position = barrel01.transform.position;
            GameObject playerBullet02 = Instantiate(playerBullet);
            playerBullet02.transform.position = barrel02.transform.position;
            SoundManager.Instance.PlayShootingSound();
        }
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
            Destroy(collision.gameObject);
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
}
