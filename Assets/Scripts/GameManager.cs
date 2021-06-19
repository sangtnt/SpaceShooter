using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject gameoverImg;
    public GameObject player;
    public GameObject enemySpawner;
    public GameObject gameTitle;
    public GameObject wintext;
    public Text levelText;
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
                    gameoverImg.SetActive(false);
                    playButton.SetActive(true);
                    gameTitle.SetActive(true);
                    levelText.enabled = false;
                    wintext.SetActive(false);
                }
                break;
            case GameManagerState.Gameplay:
                {
                    gameoverImg.SetActive(false);
                    wintext.SetActive(false);
                    playButton.SetActive(false);
                    player.GetComponent<PlayerControl>().Init();
                    enemySpawner.GetComponent<SpawnEnemy>().StartSpawnEnemy();
                    gameTitle.SetActive(false);
                }
                break;
            case GameManagerState.Gameover:
                {
                    enemySpawner.GetComponent<SpawnEnemy>().StopEvents();
                    gameoverImg.SetActive(true);
                    playButton.SetActive(true);
                    levelText.enabled = false;
                }
                break;
            case GameManagerState.Win:
                {
                    wintext.SetActive(true);
                    Invoke("OpenGame", 2f);
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
