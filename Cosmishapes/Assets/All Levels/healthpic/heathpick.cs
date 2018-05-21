using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class heathpick : MonoBehaviour {


    void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(new Vector3(1, 1, 1));
    }
/*
    private void OnCollisionEnter(Collision collision)
    {
       void Start()
        {

        }
    }*/
}
