using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBarrel : MonoBehaviour
{
    public float shootingTime;
    public GameObject bullet;
    private AudioSource audioSource;
    public AudioClip shootAudio;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Shoot", 1f, shootingTime);
        audioSource = FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Shoot()
    {
        GameObject player = GameObject.Find("PlayerShip");
        if (player != null)
        {
            GameObject newBullet = Instantiate(bullet);
            newBullet.transform.position = gameObject.transform.position;

            audioSource.PlayOneShot(shootAudio);
            Vector2 direction = player.transform.position - newBullet.transform.position;
            newBullet.GetComponent<EnemyBulletControl>().SetDirection(direction);
        }
    }
}
