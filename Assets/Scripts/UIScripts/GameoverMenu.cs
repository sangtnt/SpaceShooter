using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameoverMenu : Singleton<GameoverMenu>
{
    public void SetStateOfUI(bool state)
    {
        gameObject.SetActive(state);
        OpenGameMenu.Instance.SetStateOfButtonPlay(state);
    }
}
