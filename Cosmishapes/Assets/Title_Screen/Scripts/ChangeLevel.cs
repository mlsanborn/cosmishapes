using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeLevel : MonoBehaviour {

    public int index;
    public GameObject Level_Lock;
    public GameObject Level_Unlock;
    //public Sprite[] Images = { };



    // Use this for initialization
    void Start () {
        index = 1;
        //Images = { Level_1, Level_2 };
    }
	
	public void Load () {
        if(player_stats.level_unlock >= index - 1)
        {
            GoToMain.SceneLoader((2 * index) + 1);
        }
	}

    public void ChangeIndex(int num)
    {
        index += num;

        if (index < 1)
        {
            index = 7;
        }
        else if(index > 7)
        {
            index = 1;
        }

        if (index == 7)
        {
            GameObject.Find("ChooseLevel").GetComponentInChildren<Text>().text = "BOSS LEVEL";
        }
        else
        {
            GameObject.Find("ChooseLevel").GetComponentInChildren<Text>().text = "LEVEL " + index;
        }

        if(player_stats.level_unlock < index-1)
        {
            Level_Lock.SetActive(true);
            Level_Unlock.SetActive(false);
        }
        else
        {
            Level_Lock.SetActive(false);
            Level_Unlock.SetActive(true);
        }
    }

    /**
    private Sprite getSprite(int i)
    {
        if(i == 1)
        {
            return Level_1;
        }
        else if (i == 2)
        {
            return Level_2;
        }
        else if (i == 3)
        {
            return Level_3;
        }
        else if (i == 4)
        {
            return Level_4;
        }
        else if (i == 5)
        {
            return Level_5;
        }
        else if (i == 6)
        {
            return Level_6;
        }
        else if (i == 7)
        {
            return Level_BOSS;
        }
        else
        {
            return null;
        }
    }
    */

    public void exit()
    {
        Application.Quit();
    }
}
