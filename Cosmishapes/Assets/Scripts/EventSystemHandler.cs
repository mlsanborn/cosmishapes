using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventSystemHandler : MonoBehaviour
{

    float count;
    private int score;
    private int required_score;
    public Text timer;
    public Text display_score;

    //the canvases for the player stuff, what shows up when the game is paused, or at the beginning
    public GameObject PlayerInfo;
    public GameObject DeathCanvas;
    public GameObject WinCanvas;

    //the player
    public GameObject Player;

    // Use this for initialization
    void Start()
    {
        Children();
        count = 90;
        timer.text = "" + count;
        score = 0;
        display_score.text = "Score: " + score;
        PlayerInfo.SetActive(false);
        DeathCanvas.SetActive(false);
        required_score = (200 * (((SceneManager.GetActiveScene().buildIndex) - 1) / 2));
    }

    // Update is called once per frame
    void Update()
    {
        count = count - Time.deltaTime;
        timer.text = "" + ((int)count + 1); //round time to second

        if(score >= required_score)
        {
            end_game(true);
        }
        if (((int)count + 1) <= 0)
        {
            end_game(false);
        }
    }

    public void end_game(bool win)
    {
        PlayerInfo.SetActive(false);
        if (win)
        {
            WinCanvas.SetActive(true);
            //calculate level number since the index is different than the actual level number
            if ((((SceneManager.GetActiveScene().buildIndex)/2)-1) > player_stats.level_unlock)
            {
                player_stats.level_unlock++;
            }
        }
        else
        {
            DeathCanvas.SetActive(true);
        }
        player_stats.total_points += score;
        Destroy(Player);
        Time.timeScale = 0;
    }

    public void score_update(int num)
    {
        Debug.Log(score);
        score = score + num;
        display_score.text = "Score: " + score;

    }

    //win-lose button functions
    public void reload()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void next_level()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void main()
    {
        SceneManager.LoadScene(2);
    }

    public void exit()
    {
        Application.Quit();
    }

    //getting the children to access text
    private void Children()
    {
        timer = PlayerInfo.transform.Find("Timer").GetComponent<Text>();
        display_score = PlayerInfo.transform.Find("Points").GetComponent<Text>();
    }
}
