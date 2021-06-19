using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenGameMenu : Singleton<OpenGameMenu>
{
    public GameObject buttonPlay;
    public GameObject scoreObject;
    public GameObject livesObject;
    public GameObject gameTitle;
    public void SetStateOfButtonPlay(bool state)
    {
        buttonPlay.SetActive(state);
    }
    public void SetStateOfScoreObject(bool state)
    {
        scoreObject.SetActive(state);
    }
    public void SetTextOfScore(string score)
    {
        scoreObject.GetComponentInChildren<Text>().text = score;
    }
    public void SetStateOfLivesObject(bool state)
    {
        livesObject.SetActive(state);
    }
    public void SetTextOfLives(string score)
    {
        livesObject.GetComponentInChildren<Text>().text = string.Format("{0:000000}", score);
    }
    public void SetStateOfGameTitle(bool state)
    {
        gameTitle.SetActive(state);
    }
}
