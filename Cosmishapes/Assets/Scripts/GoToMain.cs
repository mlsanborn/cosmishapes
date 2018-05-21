using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToMain : MonoBehaviour {

    public GameObject Pause;
    public GameObject Player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Player)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Pause.SetActive(!(Pause.activeSelf));
                Time.timeScale = Mathf.Abs(Time.timeScale - 1);
            }
        }
    }

    public static void SceneLoader(int i)
    {
        Debug.Log(i);
        SceneManager.LoadScene(i+1);

    }

    public void SceneLoaderButton(int i)
    {
        Debug.Log(i);
        SceneManager.LoadScene(i);

    }

}
