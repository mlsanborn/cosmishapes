using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colfire : MonoBehaviour {

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Land")
        {
            Destroy(gameObject,10f);
        }
    }
}
