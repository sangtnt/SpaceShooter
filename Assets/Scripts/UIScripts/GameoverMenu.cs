using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameoverMenu : Singleton<GameoverMenu>
{
    public GameObject gameoverImg;
    public void SetStateOfUI(bool state)
    {
        gameoverImg.SetActive(state);
        OpenGameMenu.Instance.SetStateOfButtonPlay(state);
    }
}
