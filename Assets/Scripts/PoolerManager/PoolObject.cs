using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PoolObjectType
{
    Enemy,
    EnemyBullet,
    PlayerBullet
}
[System.Serializable]
public class PoolObject
{
    public PoolObjectType type;
    public GameObject prefab;
    public GameObject container;
    public int amount=0;

    [HideInInspector]
    public List<GameObject> pool = new List<GameObject>();
}
