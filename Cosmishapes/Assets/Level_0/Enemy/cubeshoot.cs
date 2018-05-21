using UnityEngine;
using System.Collections;

public class cubeshoot : MonoBehaviour
{
    //private int count= 0;


    //types of bullets
    public GameObject Bullet;
    //public GameObject Big;
    private float Force = 1000;


    //shooting
    private float canshootint = .5F;
    private bool canshootbool = true;

    private int deathcount;
    public GameObject cubespawn;
    void Start()
    {


    }
    void FixedUpdate()
    {
        //basic shot
        if (canshootint >= .5F)
        {
            canshootbool = true;
        }
        canshootint += Time.deltaTime;
        if (canshootbool)
        {
            //create hte bullet object
            GameObject Temp;
            //make it in the scene 
            Temp = Instantiate(Bullet, gameObject.transform.position + new Vector3(0, 1, 0), gameObject.transform.rotation) as GameObject;
            //rotate for simple fire
            Temp.transform.Rotate(Vector3.left * 90);
            //give it a rigid body
            Rigidbody TempBody;
            //"push" it so it goes, no gravity
            TempBody = Temp.GetComponent<Rigidbody>();
            TempBody.AddForce(transform.forward * Force);
            Destroy(Temp, 1.0f);

            canshootbool = false;
            canshootint = 0F;
        }
    }
    void OnCollisionEnter(Collision other)

    {
        /*
        if (other.gameObject.tag == "bigboy")
        {
            deathcount++;
            score += 10;
            display_score.text = "Score: " + score;
            Debug.Log("ajksdb");
            spawncube(new Vector3(0, 0, 0));
            spawncube(new Vector3(0, 0, 5));
            if (deathcount > 100)
            {
                //go to next level after killing 100 enemys (1st levels task)
                // or we could have a time for 60 to survive on a level and then have points for killing more enemys at the end (maybe round bonus) ?
            }
            Destroy(gameObject);
           
        }
        */

        if (other.gameObject.tag == "bullet")
        {
            deathcount++;
            
            Debug.Log("Score");
            
            spawncube(new Vector3(0, 0, 0));
            spawncube(new Vector3(0, 0, 5));
            if (deathcount > 100)
            {
                //go to next level after killing 100 enemys (1st levels task)
                // or we could have a time for 60 to survive on a level and then have points for killing more enemys at the end (maybe round bonus) ?
            }
            Destroy(gameObject);
            Destroy(other.gameObject);

        }

        if (other.gameObject.tag == "Player")
        {
            deathcount++;
            spawncube(new Vector3(0, 0, 5));
            spawncube(new Vector3(0, 0, 0));
        }
    }
    private Vector3 spawnloc;
    public void spawncube(Vector3 offset)
    {
        //count++;
        //Debug.Log(count);
        spawnloc = new Vector3(Random.Range(-50f, 50f), 2, Random.Range(-50.0f, 50.0f));
        Instantiate(gameObject, spawnloc + offset, cubespawn.transform.rotation);
    }
}
