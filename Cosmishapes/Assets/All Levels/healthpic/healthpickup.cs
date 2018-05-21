using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class healthpickup : MonoBehaviour {

    public GameObject healthpickups;
    private float spawntimer = 15F - (.5F*player_stats.basic_stats[5]);
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        spawntimer += 1 * Time.deltaTime;

        if (spawntimer > 15F)
        {
            GameObject Temp = Instantiate(healthpickups, new Vector3(Random.Range(-50f, 50f), 15, Random.Range(-50.0f, 50.0f)), gameObject.transform.rotation);
            Destroy(Temp, 15f);
            spawntimer = 0F;
        }
	}

   
}

