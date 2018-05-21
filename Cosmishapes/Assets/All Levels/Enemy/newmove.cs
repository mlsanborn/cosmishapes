using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class newmove : MonoBehaviour
{

    //The target player
    public Transform player;
    //At what distance will the enemy walk towards the player?
    //public float walkingDistance = 10.0f;
    //In what time will the enemy complete the journey between its position and the players position
    //public float smoothTime = 10.0f;
    //Vector3 used to store the velocity of the enemy
    // private Vector3 smoothVelocity = Vector3.zero;
    //Call every frame
    float count = 1.5f;
    void Update()
    {
        //Look at the player
        transform.LookAt(player);


        Rigidbody TempBody;
        //"push" it so it goes, no gravity
        TempBody = gameObject.GetComponent<Rigidbody>();
        count += (1 * Time.deltaTime);

        if (count > 1)
        {
            //TempBody.AddForce(transform.up * 100);
            TempBody.AddForce(transform.forward * 800);
            count = 0;
        }
        //TempBody.AddForce(transform.forward * 10);

        //Calculate distance between player
        //float distance = Vector3.Distance(transform.position, player.position);
        //If the distance is smaller than the walkingDistance
        //if (distance < walkingDistance)
        // {
        //Move the enemy towards the player with smoothdamp
        //transform.position = Vector3.SmoothDamp(transform.position, player.position, ref smoothVelocity, smoothTime);
        //}
    }
    void Start()
    {

    }


}
