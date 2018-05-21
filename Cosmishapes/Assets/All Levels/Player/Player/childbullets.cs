using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class childbullets : MonoBehaviour
{
    public GameObject Bullet_Emitter;

    //types of bullets
    public GameObject Bullet;
    public GameObject FBullet;
    public GameObject BBullet;
    //public GameObject Big;
    private float Force = 3500;

    //shooting
    private float canshootint = 3F;
    private bool canshootbool = true;

    //mode
    private int mode = 0;
    public Text type;
    public System.String[] types = { "Basic", "Freeze", "Burn" };

    /*
     * This script controls all fire types and bullet types
     * to shoot its ,u,i,o,p
     * to cycle through modes its j,k (j is next, k is prev)
     * 
     * 0 - generic
     * 1 - freeze
     * 2 - burn 
     * 3 ??
     */
    void Start()
    {


    }
    void Update()
    {
        //basic shot
        if (canshootint >= 1F)
        {
            canshootbool = true;
        }
        canshootint += Time.deltaTime;

        //mode change
        if (Input.GetKeyDown(KeyCode.J))
        {
            if (mode != 0)
                mode--;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            if (mode != 2) { mode++; }


        }
        type.text = types[mode];

        // type 0
        if (Input.GetKeyDown(KeyCode.U) && canshootbool)
        {
            if (mode == 0)
            {
                //create hte bullet object
                GameObject Temp;
                //make it in the scene 
                Temp = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
                //rotate for simple fire
                Temp.transform.Rotate(Vector3.left * 90);
                //give it a rigid body
                Rigidbody TempBody;
                //"push" it so it goes, no gravity
                TempBody = Temp.GetComponent<Rigidbody>();
                TempBody.AddForce(transform.forward * Force);
                Destroy(Temp, 1.0f);

            }
            if (mode == 1)
            {
                //create hte bullet object
                GameObject Temp1;
                //make it in the scene 
                Temp1 = Instantiate(FBullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
                //rotate for simple fire
                Temp1.transform.Rotate(Vector3.left * 90);
                //give it a rigid body
                Rigidbody TempBody;
                //"push" it so it goes, no gravity
                TempBody = Temp1.GetComponent<Rigidbody>();
                TempBody.AddForce(transform.forward * Force);
                Destroy(Temp1, 1.0f);
            }
            if (mode == 2)
            {
                //create hte bullet object
                GameObject Temp;
                //make it in the scene 
                Temp = Instantiate(BBullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
                //rotate for simple fire
                Temp.transform.Rotate(Vector3.left * 90);
                //give it a rigid body
                Rigidbody TempBody;
                //"push" it so it goes, no gravity
                TempBody = Temp.GetComponent<Rigidbody>();
                TempBody.AddForce(transform.forward * Force);
                Destroy(Temp, 1.0f);
            }

            canshootbool = false;
            canshootint = 0F;
        }
        //Fast and long range
        if (Input.GetKeyDown(KeyCode.I) && canshootbool)
        {
            if (mode == 0)
            {
                //create hte bullet object
                GameObject Temp;
                //make it in the scene 
                Temp = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
                //rotate for simple fire
                Temp.transform.Rotate(Vector3.left * 90);
                //give it a rigid body
                Rigidbody TempBody;
                //"push" it so it goes, no gravity
                TempBody = Temp.GetComponent<Rigidbody>();
                TempBody.AddForce(transform.forward * Force * 3);
                Destroy(Temp, 1.0f);
            }
            if (mode == 1)
            {
                //create hte bullet object
                GameObject Temp;
                //make it in the scene 
                Temp = Instantiate(FBullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
                //rotate for simple fire
                Temp.transform.Rotate(Vector3.left * 90);
                //give it a rigid body
                Rigidbody TempBody;
                //"push" it so it goes, no gravity
                TempBody = Temp.GetComponent<Rigidbody>();
                TempBody.AddForce(transform.forward * Force * 3);
                Destroy(Temp, 1.0f);
            }
            if (mode == 2)
            {
                //create hte bullet object
                GameObject Temp;
                //make it in the scene 
                Temp = Instantiate(BBullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
                //rotate for simple fire
                Temp.transform.Rotate(Vector3.left * 90);
                //give it a rigid body
                Rigidbody TempBody;
                //"push" it so it goes, no gravity
                TempBody = Temp.GetComponent<Rigidbody>();
                TempBody.AddForce(transform.forward * Force * 3);
                Destroy(Temp, 1.0f);
            }

            canshootbool = false;
            canshootint = 0F;
        }
        //shotgun
        if (Input.GetKeyDown(KeyCode.O) && canshootbool)
        {
            if (mode == 0)
            {
                int x = 0;
                GameObject Temp;
                for (; x < 3; x++)
                {
                    //make it in the scene 
                    Temp = Instantiate(Bullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
                    //rotate for simple fire
                    Temp.transform.Rotate(Vector3.left * (60 + (30 * x)));
                    //give it a rigid body
                    Rigidbody TempBody;
                    //"push" it so it goes, no gravity
                    TempBody = Temp.GetComponent<Rigidbody>();
                    TempBody.AddForce(transform.forward * Force);
                    Destroy(Temp, .3f);

                    canshootbool = false;
                    canshootint = 0F;
                }
                x = 0;
            }
            if (mode == 1)
            {
                int x = 0;
                GameObject Temp;
                for (; x < 3; x++)
                {
                    //make it in the scene 
                    Temp = Instantiate(FBullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
                    //rotate for simple fire
                    Temp.transform.Rotate(Vector3.left * (60 + (30 * x)));
                    //give it a rigid body
                    Rigidbody TempBody;
                    //"push" it so it goes, no gravity
                    TempBody = Temp.GetComponent<Rigidbody>();
                    TempBody.AddForce(transform.forward * Force);
                    Destroy(Temp, .3f);

                    canshootbool = false;
                    canshootint = 0F;
                }
                x = 0;
            }
            if (mode == 2)
            {
                int x = 0;
                GameObject Temp;
                for (; x < 3; x++)
                {
                    //make it in the scene 
                    Temp = Instantiate(BBullet, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
                    //rotate for simple fire
                    Temp.transform.Rotate(Vector3.left * (60 + (30 * x)));
                    //give it a rigid body
                    Rigidbody TempBody;
                    //"push" it so it goes, no gravity
                    TempBody = Temp.GetComponent<Rigidbody>();
                    TempBody.AddForce(transform.forward * Force);
                    Destroy(Temp, .3f);

                    canshootbool = false;
                    canshootint = 0F;
                }
                x = 0;
            }


        }

        //circle
        /*
        if (Input.GetKeyDown(KeyCode.P) && canshootbool)
        {
            //create hte bullet object
            GameObject Temp;
            //make it in the scene 
            //Temp = Instantiate(Big, Bullet_Emitter.transform.position, Bullet_Emitter.transform.rotation) as GameObject;
            //rotate for simple fire
            Temp.transform.Rotate(Vector3.left * 90);
            //give it a rigid body
            Rigidbody TempBody;
            //"push" it so it goes, no gravity
            TempBody = Temp.GetComponent<Rigidbody>();
            TempBody.AddForce(transform.forward * Force);
            Destroy(Temp, 10.0f);

            canshootbool = false;
            canshootint = 0F;
        }*/
    }
}