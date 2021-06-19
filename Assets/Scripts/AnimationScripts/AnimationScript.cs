using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : Singleton<AnimationScript>
{
    public GameObject explosionAnim;
    public void PlayExplosionAnim(Vector2 pos)
    {
        GameObject e = Instantiate(explosionAnim);
        e.transform.position = pos;
    }
}
