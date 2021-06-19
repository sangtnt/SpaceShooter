using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    public AudioSource audioSource;
    public AudioClip shootingClip;
    public AudioClip explosionClip;
    public void PlayShootingSound()
    {
        audioSource.PlayOneShot(shootingClip);
    }
    public void PlayExplosionSound()
    {
        audioSource.PlayOneShot(explosionClip);
    }
}
