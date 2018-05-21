using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class enemy : MonoBehaviour
{
    //target is where you want this cube to go to


    //how many cubes have died ? idk
    private static int deathcount = 0;
    public Image bar;
    private static float width;

    //event system object
    public EventSystemHandler EventSystem;
    public EventSystemHandlerBoss EventSystems;

    //point value of this enemy
    public int value;


    //private Transform cubespawn.Transform;                    is this even needed ????? idk 

    //types of bullets
    public GameObject Bullet;
    //public GameObject Big;
    private float Force = 1000;

    //shooting
    private float canshootint = .5F;
    private float canjumpint = .5F;
    private bool canshootbool = true;
    private bool canjumpbool = true;
    public bool canspawn;
    public bool isafly;
    public bool isashooter;
    public bool isajumpy;
    public bool isalaserman;
    public bool isapois;
    public bool isafire;
    public bool isaboss;

    private int health;
    public int max_health = 3;

    void Start()
    {
        if (isaboss)
        {
            max_health = 100;
        }
        if (isafly || isafire)
        {
            max_health = 1;
        }
        health = max_health;
        Children();
        bar.rectTransform.sizeDelta = new Vector2(width, bar.rectTransform.rect.height);
        bar.rectTransform.anchoredPosition = new Vector2(0, bar.transform.localPosition.y);
        Debug.Log(width);
    }

    void FixedUpdate()
    {
        if (isapois)
        {
            //basic shot
            if (canshootint >= .5f)
            {
                canshootbool = true;
            }
            canshootint += Time.deltaTime;
            if (canshootbool)
            {
                //create hte bullet object
                GameObject Temp;
                //make it in the scene 
                Temp = Instantiate(Bullet, gameObject.transform.position + new Vector3(0, 4, 0), gameObject.transform.rotation) as GameObject;
                //rotate for simple fire
                Temp.transform.Rotate(Vector3.left * 90);
                //give it a rigid body
                Rigidbody TempBody;
                //"push" it so it goes, no gravity
                TempBody = Temp.GetComponent<Rigidbody>();
                TempBody.AddForce(new Vector3(Random.Range(-1000f, 1000f), Random.Range(500f, 1000f), Random.Range(-1000f, 1000f)));
                //Destroy(Temp, 1.0f);

                canshootbool = false;
                canshootint = 0F;
            }
        }
        if (isafire)
        {
            //basic shot
            if (canshootint >= .2F)
            {
                canshootbool = true;
            }
            canshootint += Time.deltaTime;
            if (canshootbool)
            {
                //create hte bullet object
                GameObject Temp;
                //make it in the scene 
                Temp = Instantiate(Bullet, gameObject.transform.position + new Vector3(0, -3, 0), gameObject.transform.rotation) as GameObject;
                //rotate for simple fire
                Temp.transform.Rotate(Vector3.left * 90);
                //give it a rigid body
                Rigidbody TempBody;
                //"push" it so it goes, no gravity
                TempBody = Temp.GetComponent<Rigidbody>();
                TempBody.AddForce(new Vector3(Random.Range(-1000f, 1000f), 0, Random.Range(-1000f, 1000f)));
                //Destroy(Temp, 1.0f);

                canshootbool = false;
                canshootint = 0F;
            }
        }
        if (isajumpy)
        {
            if (canjumpint >= 2F)
            {
                canjumpbool = true;
            }
            canjumpint += Time.deltaTime;
            if (canjumpbool)
            {
                Rigidbody temp = gameObject.GetComponent<Rigidbody>();
                temp.AddForce(transform.up * 1000);
                canjumpbool = false;
                canjumpint = 0;

                //Debug.Log("jump ");
            }
        }
        if (isafly)
        {
            //basic shot
            if (canshootint >= 1F)
            {
                canshootbool = true;
            }
            canshootint += Time.deltaTime;
            if (canshootbool)
            {
                //create hte bullet object
                GameObject Temp;
                //make it in the scene 
                Temp = Instantiate(Bullet, gameObject.transform.position + new Vector3(0, -4, 0), gameObject.transform.rotation) as GameObject;
                //rotate for simple fire
                Temp.transform.Rotate(Vector3.left * 90);
                //give it a rigid body
                Rigidbody TempBody;
                //"push" it so it goes, no gravity
                TempBody = Temp.GetComponent<Rigidbody>();
                TempBody.AddForce(transform.forward * Force * 2);
                Destroy(Temp, 2.0f);

                canshootbool = false;
                canshootint = 0F;
            }
        }
        if (isashooter)
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
        if (isalaserman)
        {
            //basic shot
            if (canshootint >= 4F)
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
                //Rigidbody TempBody;
                //"push" it so it goes, no gravity
                // TempBody = Temp.GetComponent<Rigidbody>();
                // TempBody.AddForce(transform.forward * Force);
                Destroy(Temp, 3.0f);

                canshootbool = false;
                canshootint = 0F;
            }
        }
    }
    //collision detection 
    void OnCollisionEnter(Collision other)

    {



        if (other.gameObject.tag == "bullet")
        {
            health -= (1 + player_stats.basic_stats[2]);
            
            float x_width = width*((float)health / max_health);
            float x_position = - ((width-x_width) / 2);
            Debug.Log(x_position);
            Debug.Log(bar.rectTransform.anchoredPosition.x);
            Debug.Log(bar.transform.localPosition.x);
            bar.rectTransform.sizeDelta = new Vector2(x_width, bar.rectTransform.rect.height);
            bar.rectTransform.anchoredPosition = new Vector2(x_position, bar.transform.localPosition.y);
            //bar.rectTransform.rect.xMax -= (bar.rectTransform.rect.width * (1 / max_health));
            if (health <= 0 && !isaboss)
            {
                deathcount++;

                //calls the score update in the EventSystemHandler object script and adds the value set in this code
                EventSystem.score_update(value);

                spawncube(new Vector3(0, 0, 0));
                spawncube(new Vector3(0, 0, 5));

                Destroy(gameObject);
            }
            if(health <= 0 && isaboss)
            {
                EventSystems.end_game(true);
            }
            Destroy(other.gameObject);

        }

        if (other.gameObject.tag == "Player" && !isaboss)
        {
            EventSystem.score_update(value);
            deathcount++;
            spawncube(new Vector3(0, 0, 5));
            spawncube(new Vector3(0, 0, 0));

            Destroy(gameObject);

        }

    }

    private Vector3 spawnloc;
    public void spawncube(Vector3 offset)
    {
        if (canspawn)
        {
            spawnloc = new Vector3(Random.Range(-60f, 60f), 12, Random.Range(-60.0f, 60.0f));
            Instantiate(gameObject, spawnloc + offset, transform.rotation);
        }
    }
    
    private void Children()
    {
        bar = this.transform.Find("Canvas").transform.Find("Bar").GetComponent<Image>();
        if(width == 0)
        {
            width = bar.rectTransform.rect.width;
        }
    }

}