using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lava : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "player")
        {
     
        }
    }
}
