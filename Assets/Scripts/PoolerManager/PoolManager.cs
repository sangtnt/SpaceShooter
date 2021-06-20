using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    [SerializeField]
    public List<PoolObject> listOfPool;

    private void Start()
    {
        foreach(PoolObject pool in listOfPool)
        {
            FillPoolObjectList(pool);
        }
    }
    void FillPoolObjectList(PoolObject poolObject)
    {
        for(int i = 0; i < poolObject.amount; i++)
        {
            GameObject newGameObject = Instantiate(poolObject.prefab, poolObject.container.transform);
            poolObject.pool.Add(newGameObject);
            newGameObject.SetActive(false);
        }
    }

    public GameObject GetPoolObject(PoolObjectType type)
    {
        PoolObject poolObject = GetPoolObjectByType(type);
        GameObject pool;
        if (poolObject.pool.Count > 0)
        {
            pool = poolObject.pool[poolObject.pool.Count - 1];
            poolObject.pool.Remove(pool);
        }
        else
        {
            pool = Instantiate(poolObject.prefab, poolObject.container.transform);
        }
        return pool;
    }
    public void DeactivatePoolObject(GameObject p, PoolObjectType type)
    {
        p.SetActive(false);
        PoolObject poolObject = GetPoolObjectByType(type);
        if (!poolObject.pool.Contains(p))
        {
            poolObject.pool.Add(p);
        }
    }
    PoolObject GetPoolObjectByType(PoolObjectType type)
    {
        foreach(PoolObject pool in listOfPool)
        {
            if(pool.type == type)
            {
                return pool;
            }
        }
        return null;
    }
}
