using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : Singleton<GameplayUI>
{
    public GameObject levelText;
    public GameObject winText;
    public void SetStateOfLevelText(bool state)
    {
        levelText.SetActive(state);
    }
    public void SetValueOfLevelText(string text)
    {
        levelText.GetComponent<Text>().text = "Level " + text;
    }
    public void SetStateOfWinText(bool state)
    {
        winText.SetActive(state);
    }
}
