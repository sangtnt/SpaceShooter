using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnEnemy : MonoBehaviour
{
    public float maxSpawnTime;
    public GameObject enemy;
    public GameObject gamemanager;
    float spawnTime;
    public float timeToNextLevel;
    int level;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update level text
    void UpdateLevelText()
    {
        GameplayUI.Instance.SetStateOfLevelText(true);
        GameplayUI.Instance.SetValueOfLevelText(level.ToString());
        Invoke("HideLevelText", 2f);
    }
    void HideLevelText()
    {
        GameplayUI.Instance.SetStateOfLevelText(false);
    }

    private void CreateEnemy()
    {
        Vector2 min = CameraManager.GetCameraMin();
        Vector2 max = CameraManager.GetCameraMax();
        Vector2 spawnPos = new Vector2(Random.Range(min.x + transform.localScale.x / 2, max.x - transform.localScale.x / 2), max.y);

        GameObject newEnemy = PoolManager.Instance.GetPoolObject(PoolObjectType.Enemy);
        newEnemy.SetActive(true);
        newEnemy.transform.position = spawnPos;
        NextEnemy();
    }

    private void NextEnemy()
    {
        float spawnEnemyTime = 1f;
        if (spawnTime > 1f)
        {
            spawnEnemyTime = Random.Range(1f, spawnTime);
        }
        Invoke("CreateEnemy", spawnEnemyTime);
    }
    private void IncreaseLevel()
    {
        if (spawnTime > 1f)
        {
            spawnTime--;
            level++;
            UpdateLevelText();
        }
        else
        {
            CancelInvoke("CreateEnemy");
            gamemanager.GetComponent<GameManager>().SetGamemanagerState(GameManager.GameManagerState.Win);
            
        }
    }
    public void StopEvents()
    {
        CancelInvoke("CreateEnemy");
        CancelInvoke("IncreaseLevel");
    }
    public void StartSpawnEnemy()
    {
        level = 1;
        UpdateLevelText();
        spawnTime = maxSpawnTime;
        Invoke("CreateEnemy", spawnTime);
        InvokeRepeating("IncreaseLevel", timeToNextLevel, timeToNextLevel);
    }
}
