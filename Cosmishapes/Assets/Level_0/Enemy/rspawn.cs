using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * alright ill be honest this class is really bad programming
 * the random spawn location could have been easily done in the enemy class
 * but eventuall i want to have a few set locations
 * this trash will have to do for now
 * - alex
*/



public class rspawn : MonoBehaviour {
    //the spawn location
    private Vector3 spawnloc;
    
	// Use this for initialization
	void Start () {
        //default locations ( rn only one that does nothing heeheeh) 
        spawnloc = new Vector3(0, 0,0);
        
	}
	
	// Update is called once per frame
	void Update () {
        // ----------------------TRASH WARNING----------------------
        //set the location randomly every frame (like 160 times per second basically) 
        //spawnloc = new Vector3(Random.Range(-50f, 50f), 2, Random.Range(-50.0f, 50.0f));
        this.transform.position = spawnloc;
        //------------------------TRASH WARNING---------------------
	}
}
