using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class instructions : MonoBehaviour {

    public GameObject InstructionCanvas;
    public GameObject PlayerInfo;
    public Text instruction;
    public int count;

    // Use this for initialization
    void Start () {
        instruction = InstructionCanvas.transform.Find("Instructions (Text)").transform.Find("Text").GetComponent<Text>();
        if (SceneManager.GetActiveScene().buildIndex != 16)
        {
            instruction.text = "Get " + (200 * (((SceneManager.GetActiveScene().buildIndex) - 1) / 2)) + " points to advance to the next level!";
            instruction.text += "\n\nYou have " + count + " seconds.";
        }
        else
        {
            instruction.text = "Defeat the boss.";
        }
        instruction.text += "\n\nClick to start.";
        InstructionCanvas.SetActive(true);
        PlayerInfo.SetActive(false);
        Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update () {
        if (InstructionCanvas.activeInHierarchy)
        {
            if (Time.timeScale == 0)
            {

                if (Input.GetMouseButton(0))
                {
                    Time.timeScale = 1;
                    InstructionCanvas.SetActive(false);
                    PlayerInfo.SetActive(true);
                }
            }
        }
    }
}
