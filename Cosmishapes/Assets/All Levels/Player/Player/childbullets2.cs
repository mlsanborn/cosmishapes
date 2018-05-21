using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class childbullets2 : MonoBehaviour
{

    //types of bullets
    public GameObject Bullet, GBullet, FBullet, GFBullet, BBullet, GBBullet, Front_Bullet_Emitter, Back_Bullet_Emitter, Left_Bullet_Emitter, Right_Bullet_Emitter, Up_Bullet_Emitter;
    public bool instruc = false;

    //public GameObject Big;
    private float Force = 5000;

    //shooting
    private float charge = .5f;
    //mode
    private int mode = 0;
    public Text type;
    private int type1 = 0;
    public float distance = 100.0f;
    public System.String[] types = { "Basic", "Freeze", "Burn" };

    private float canshootint = 3F;
    private bool canshootbool = false;
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
    void Update()
    {
        if (instruc)
        {
            if (canshootint >= (.3F - (.02F*player_stats.basic_stats[3]) ) )
            {
                canshootbool = true;
            }
            canshootint += Time.deltaTime;

            //mode change
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                mode = 0;
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                //mode = 1;
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                //mode = 2;
            }
            type.text = types[mode];

            if (Input.GetMouseButtonDown(1))
            {
                if (type1 != 2)
                {
                    type1++;

                }
                else
                {
                    type1 = 0;
                }
            }
            //straight shot
            /*if (Input.GetMouseButton(0))
            {
                charge += Time.deltaTime * .7f;
            }*/
            if (Input.GetMouseButton(0) && canshootbool && type1 == 0)
            {
                GameObject Temp, type = null;
                if (mode == 0)
                {
                    type = GBullet;
                }
                if (mode == 1)
                {
                    type = GFBullet;
                }
                if (mode == 2)
                {
                    type = GBBullet;
                }

                if (type != null)
                {
                    Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
                    position = Camera.main.ScreenToWorldPoint(position);

                    Temp = Instantiate(type, transform.position, Quaternion.identity) as GameObject;
                    Temp.transform.LookAt(position);
                    Debug.Log(position);

                    Temp.GetComponent<Rigidbody>().AddForce(Temp.transform.forward * Force * charge);
                    Destroy(Temp, 2.0f * charge);

                    charge = .5f;
                    canshootbool = false;
                    canshootint = 0F;
                }
            }

            //kobe
            /*if (Input.GetMouseButton(0))
            {
                charge += Time.deltaTime * .7f;
            }*/
            if (Input.GetMouseButton(0) && canshootbool && type1 == 1)
            {
                GameObject Temp, type = null;
                if (mode == 0)
                {
                    type = Bullet;
                }
                if (mode == 1)
                {
                    type = FBullet;
                }
                if (mode == 2)
                {
                    type = BBullet;
                }
                if (type != null)
                {
                    Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
                    position = Camera.main.ScreenToWorldPoint(position);

                    Temp = Instantiate(type, transform.position, Quaternion.identity) as GameObject;
                    Temp.transform.LookAt(position);
                    Debug.Log(position);

                    Temp.GetComponent<Rigidbody>().AddForce(Temp.transform.forward * Force * 1f * charge);
                    Temp.GetComponent<Rigidbody>().AddForce(Temp.transform.up * Force * 2f * charge);
                    Destroy(Temp, 2.0f * charge);

                    charge = .5f;
                    canshootbool = false;
                    canshootint = 0F;

                }

            }
            //shotgun
            /*if (Input.GetMouseButton(0))
            {
                charge += Time.deltaTime * .7f;
            }*/
            if (Input.GetMouseButton(0) && type1 == 2 && canshootint >= .8F)
            {
                GameObject FTemp, BTemp, LTemp, RTemp, UTemp, type = null;
                if (mode == 0)
                {
                    type = GBullet;
                }
                if (mode == 1)
                {
                    type = GFBullet;
                }
                if (mode == 2)
                {
                    type = GBBullet;
                }
                if (type != null)
                {
                    FTemp = Instantiate(Bullet, Front_Bullet_Emitter.transform.position, Front_Bullet_Emitter.transform.rotation) as GameObject;
                    BTemp = Instantiate(Bullet, Back_Bullet_Emitter.transform.position, Back_Bullet_Emitter.transform.rotation) as GameObject;
                    LTemp = Instantiate(Bullet, Left_Bullet_Emitter.transform.position, Left_Bullet_Emitter.transform.rotation) as GameObject;
                    RTemp = Instantiate(Bullet, Right_Bullet_Emitter.transform.position, Right_Bullet_Emitter.transform.rotation) as GameObject;
                    UTemp = Instantiate(Bullet, Up_Bullet_Emitter.transform.position, Up_Bullet_Emitter.transform.rotation) as GameObject;
                    FTemp.GetComponent<Rigidbody>().AddForce(transform.forward * Force * charge);
                    BTemp.GetComponent<Rigidbody>().AddForce(transform.forward * -1 * Force * charge);
                    LTemp.GetComponent<Rigidbody>().AddForce(transform.right * -1 * Force * charge);
                    RTemp.GetComponent<Rigidbody>().AddForce(transform.right * Force * charge);
                    UTemp.GetComponent<Rigidbody>().AddForce(transform.up * Force * charge);
                    Destroy(FTemp, .5f * charge);
                    Destroy(BTemp, .5f * charge);
                    Destroy(LTemp, .5f * charge);
                    Destroy(RTemp, .5f * charge);
                    Destroy(UTemp, .5f * charge);
                    charge = .5f;
                    canshootbool = false;
                    canshootint = 0F;
                }
            }

        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                instruc = true;
                canshootint = 0F;
            }
        }
    }
}