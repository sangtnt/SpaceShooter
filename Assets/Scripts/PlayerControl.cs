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
    public GameObject explosion;
    public GameObject gamemanager;
    public Text ScoreText;
    public Text livesUIText;
    public int maxLives;
    public AudioSource audioSource;
    public AudioClip shootAudio;
    public AudioClip explosionAudio;
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
        livesUIText.text = lives.ToString();
        gameObject.SetActive(true);
        transform.position = new Vector2(0, 0);
        Score = 0;
    }
    // Upsate Score Text
    void UpdateScoreTextUI()
    {
        ScoreText.text = string.Format("{0:000000}", Score);
    }
    // Start is called before the first frame update
    void Start()
    {
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
            audioSource.PlayOneShot(shootAudio);
        }
        // Get direction
        float xDir = Input.GetAxisRaw("Horizontal");
        float yDir = Input.GetAxisRaw("Vertical");
        Vector2 direction = new Vector2(xDir, yDir);
        Move(direction);
    }
    private void Move(Vector2 dir)
    {
        // Get Camera point
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        // Calculate min max of Camera for player
        min.x += gameObject.transform.localScale.x / 2;
        max.x -= gameObject.transform.localScale.x / 2;
        min.y += gameObject.transform.localScale.y / 2;
        max.y -= gameObject.transform.localScale.y / 2;
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
            livesUIText.text = lives.ToString();
            if (lives == 0)
            {
                gameObject.SetActive(false);
                gamemanager.GetComponent<GameManager>().SetGamemanagerState(GameManager.GameManagerState.Gameover);
            }
        }
    }
    void PlayExplosion()
    {
        audioSource.PlayOneShot(explosionAudio);
        GameObject e = Instantiate(explosion);
        e.transform.position = transform.position;
    }
}
