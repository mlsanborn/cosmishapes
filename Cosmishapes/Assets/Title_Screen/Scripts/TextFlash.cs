using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class TextFlash : MonoBehaviour {

    [SerializeField]
    private Text flashingText;

    // Update is called once per frame
    void Update () {

        flashingText.text = "Press any button to play.";
        flashingText.color = new Color(flashingText.color.r, flashingText.color.g, flashingText.color.b, Mathf.PingPong(Time.time, 1));

    }
}
