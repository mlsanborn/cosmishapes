using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Shop : MonoBehaviour {

    public Text points;
    public Button button_0;
    public Button button_1;
    public Button button_2;
    public Button button_3;
    public Button button_4;
    public Button button_5;
    public Button result;
    public Text next;
    public Button confirm_0;
    public Button confirm_1;
    public Button confirm_2;
    public Button confirm_3;
    public Button confirm_4;
    public Button confirm_5;
    public Canvas shop_screen;

    private bool use_script;

    public static string[] stats = { "Base Health", "Base Speed", "Attack Power", "Attack Speed",
                             "Health Boost Value", "Health Boost Spawn Rate" };

    public void button_text(Text text_button, int i)
    {
        if (player_stats.basic_stats[i] < 8)
        {
            text_button.text = stats[i] + " (" + (100 * (int)Mathf.Pow(2, player_stats.basic_stats[i])) + ")";
        }
        else
        {
            text_button.text = stats[i] + " (MAX)";
        }
    }

    private void change_color()
    {
        for(int i = 0; i < 6; i++)
        {
            for(int j = 1; j <= player_stats.basic_stats[i]; j++)
            {
                if(j == 1)
                {
                    shop_screen.transform.Find("Upgrade " + i + " (1)").GetComponent<Image>().color = new Color32(255, 64, 64, 255);
                }
                else
                {
                    shop_screen.transform.Find("Upgrade " + i + " (1)").transform.Find("Upgrade " + i + " (" + j + ")").GetComponent<Image>().color = new Color32(255, 64, 64, 255);
                }
            }
        }
    }

    private void Update()
    {
        if (use_script)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.currentSelectedGameObject == null)
                {
                    nullbuttons(false, -1);
                }
            }
        }
    }

    private void Start()
    {
        button_text(button_0.transform.Find("Health (text)").GetComponent<Text>(), 0);
        button_text(button_1.transform.Find("Speed (text)").GetComponent<Text>(), 1);
        button_text(button_2.transform.Find("AP (Text)").GetComponent<Text>(), 2);
        button_text(button_3.transform.Find("AS (Text)").GetComponent<Text>(), 3);
        button_text(button_4.transform.Find("HBV (Text)").GetComponent<Text>(), 4);
        button_text(button_5.transform.Find("HBSR (Text)").GetComponent<Text>(), 5);

        points.text = "Total Points: " + player_stats.total_points;

        change_color();

        use_script = false;
    }

    private void Purchase(int i)
    {
        player_stats.total_points -= 100 * (int)Mathf.Pow(2, player_stats.basic_stats[i]);
        player_stats.basic_stats[i]++;
    }

    private void Test_Purchase(int i)
    {
        Debug.Log("Help!");
        if( (player_stats.total_points - ( 100 * (int)Mathf.Pow(2, player_stats.basic_stats[i]) ) ) < 0)
        {
            next.text = "Not enough points!";
        }

        else
        {
            Purchase(i);
            next.text = "Success!";
            button_text(Choose_Text(i), i);
            points.text = "Total Points: " + player_stats.total_points;
            change_color();
        }

        RectTransform for_result = result.gameObject.GetComponent<RectTransform>();
        for_result.anchoredPosition = Choose_Button(i).gameObject.GetComponent<RectTransform>().anchoredPosition;
    }

    public Text Choose_Text(int i)
    {
        if (i == 0)
        {
            return button_0.transform.Find("Health (text)").GetComponent<Text>();
        }
        else if (i == 1)
        {
            return button_1.transform.Find("Speed (text)").GetComponent<Text>();
        }
        else if (i == 2)
        {
            return button_2.transform.Find("AP (Text)").GetComponent<Text>();
        }
        else if (i == 3)
        {
            return button_3.transform.Find("AS (Text)").GetComponent<Text>();
        }
        else if (i == 4)
        {
            return button_4.transform.Find("HBV (Text)").GetComponent<Text>();
        }
        else if (i == 5)
        {
            return button_5.transform.Find("HBSR (Text)").GetComponent<Text>();
        }
        else
        {
            Debug.Log("Error! 'i' does not fit number of texts.");
            return null;
        }
    }
    public Button Choose_Button(int i)
    {
        if (i == 0)
        {
            return confirm_0;
        }
        else if (i == 1)
        {
            return confirm_1;
        }
        else if (i == 2)
        {
            return confirm_2;
        }
        else if (i == 3)
        {
            return confirm_3;
        }
        else if (i == 4)
        {
            return confirm_4;
        }
        else if (i == 5)
        {
            return confirm_5;
        }
        else
        {
            Debug.Log("Error! 'i' does not fit number of buttons.");
            return null;
        }
    }

    public void setActiveness (bool set)
    {
        use_script = set;
    }

    public void buttonNull(int i)
    {
        nullbuttons(false, i);
    }

    public void confirmNull(int i)
    {
        Test_Purchase(i);
        nullbuttons(true, i);
    }

    private void nullbuttons(bool final, int i)
    {
        button_0.gameObject.SetActive(true);
        button_1.gameObject.SetActive(true);
        button_2.gameObject.SetActive(true);
        button_3.gameObject.SetActive(true);
        button_4.gameObject.SetActive(true);
        button_5.gameObject.SetActive(true);
        confirm_0.gameObject.SetActive(false);
        confirm_1.gameObject.SetActive(false);
        confirm_2.gameObject.SetActive(false);
        confirm_3.gameObject.SetActive(false);
        confirm_4.gameObject.SetActive(false);
        confirm_5.gameObject.SetActive(false);
        result.gameObject.SetActive(false);
        if (i != -1)
        {
            if (!final)
            {
                if (i == 0 && player_stats.basic_stats[i] < 8)
                {
                    confirm_0.gameObject.SetActive(true);
                    button_0.gameObject.SetActive(false);
                }
                if (i == 1 && player_stats.basic_stats[i] < 8)
                {
                    confirm_1.gameObject.SetActive(true);
                    button_1.gameObject.SetActive(false);
                }
                if (i == 2 && player_stats.basic_stats[i] < 8)
                {
                    confirm_2.gameObject.SetActive(true);
                    button_2.gameObject.SetActive(false);
                }
                if (i == 3 && player_stats.basic_stats[i] < 8)
                {
                    confirm_3.gameObject.SetActive(true);
                    button_3.gameObject.SetActive(false);
                }
                if (i == 4 && player_stats.basic_stats[i] < 8)
                {
                    confirm_4.gameObject.SetActive(true);
                    button_4.gameObject.SetActive(false);
                }
                if (i == 5 && player_stats.basic_stats[i] < 8)
                {
                    confirm_5.gameObject.SetActive(true);
                    button_5.gameObject.SetActive(false);
                }
            }
            else
            {
                result.gameObject.SetActive(true);

                if (i == 0)
                {
                    button_0.gameObject.SetActive(false);
                }
                if (i == 1)
                {
                    button_1.gameObject.SetActive(false);
                }
                if (i == 2)
                {
                    button_2.gameObject.SetActive(false);
                }
                if (i == 3)
                {
                    button_3.gameObject.SetActive(false);
                }
                if (i == 4)
                {
                    button_4.gameObject.SetActive(false);
                }
                if (i == 5)
                {
                    button_5.gameObject.SetActive(false);
                }
            }
        }
    }
}
