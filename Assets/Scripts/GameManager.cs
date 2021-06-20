using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject enemySpawner;
    public GameObject player;
    public enum GameManagerState
    {
        Opening,
        Gameplay,
        Gameover,
        Win
    }
    GameManagerState gameManagerState;
    // Start is called before the first frame update
    void Start()
    {
        gameManagerState = GameManagerState.Opening;
        UpdateGMState();
    }

    // Update is called once per frame
    void UpdateGMState()
    {
        switch (gameManagerState)
        {
            case GameManagerState.Opening:
                {
                    GameplayUI.Instance.SetStateOfWinText(false);
                    GameoverMenu.Instance.SetStateOfUI(false);
                    OpenGameMenu.Instance.SetStateOfButtonPlay(true);
                    OpenGameMenu.Instance.SetStateOfGameTitle(true);
                    OpenGameMenu.Instance.SetStateOfLivesObject(true);
                    OpenGameMenu.Instance.SetStateOfScoreObject(true);
                    GameplayUI.Instance.SetStateOfShootingButton(false);
                }
                break;
            case GameManagerState.Gameplay:
                {
                    player.GetComponent<PlayerControl>().Init();
                    enemySpawner.GetComponent<SpawnEnemy>().StartSpawnEnemy();

                    OpenGameMenu.Instance.SetStateOfGameTitle(false);
                    OpenGameMenu.Instance.SetStateOfButtonPlay(false);
                    GameplayUI.Instance.SetStateOfShootingButton(true);
                    GameoverMenu.Instance.SetStateOfUI(false);
                }
                break;
            case GameManagerState.Gameover:
                {
                    enemySpawner.GetComponent<SpawnEnemy>().StopEvents();
                    OpenGameMenu.Instance.SetStateOfButtonPlay(true) ;
                    GameplayUI.Instance.SetStateOfLevelText(false);
                    GameoverMenu.Instance.SetStateOfUI(true);
                    enemySpawner.GetComponent<SpawnEnemy>().StopEvents();
                    GameplayUI.Instance.SetStateOfShootingButton(false);
                }
                break;
            case GameManagerState.Win:
                {
                    GameplayUI.Instance.SetStateOfWinText(true);
                    Invoke("OpenGame", 2f);
                    enemySpawner.GetComponent<SpawnEnemy>().StopEvents();
                    GameplayUI.Instance.SetStateOfShootingButton(false);
                }
                break;
        }
    }

    public void SetGamemanagerState(GameManagerState gmState)
    {
        gameManagerState = gmState;
        UpdateGMState();
    }
    public void OpenGame()
    {
        gameManagerState = GameManagerState.Opening;
        UpdateGMState();
    }
    public void StartGamePlay()
    {
        gameManagerState = GameManagerState.Gameplay;
        UpdateGMState();
    }
}
