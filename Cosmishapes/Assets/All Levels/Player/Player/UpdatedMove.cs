 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UpdatedMove : MonoBehaviour
{

    //all of the vars that affect the movement of the charecter. 
    public float speed = 20.0F + (2.0F * player_stats.basic_stats[1]);
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public int rotateSpeed = 5;
    private Vector3 moveDirection = Vector3.zero;
    private float count = 0F;


    //hp of the player
    public int current_health;
    public Image original_bar;
    public Image health_bar;
    public Image triangle;
    public Text health_text;

    //event system to change canvases
    public EventSystemHandler events;

    void Start()
    {

        //Rigidbody TempBody = gameObject.GetComponent<Rigidbody>();
        //TempBody.AddForce(new Vector3(0, 0, 0));
        Debug.Log("Start!");
        current_health = 5 * (2 + player_stats.basic_stats[0]);
        //current_health = 1000;
        //health_bar.maxValue = current_health;
        Children();
    }


    // Update is called once per frame
    void Update()
    {
        /*
        Rigidbody TempBody = gameObject.GetComponent<Rigidbody>();
        TempBody.AddForce(new Vector3(0, 0, 100000000000));*/

        //make the character contller to control some aspects of the charecter (mainly more variable stuff) * in components of the charecter
        //Debug.Log(transform != null);

        health_text.text = current_health + "/" + (5 * (2 + player_stats.basic_stats[0]));
        //health_bar.value = current_health;
        updateHealth();

        if (Time.timeScale != 0)
        {
            if (transform != null)
            {
                CharacterController controller = GetComponent<CharacterController>();
                //if im on the ground let me jump and move 
                if (controller.isGrounded)
                {
                    //move left right only if on the ground ( up to change depending on how clunky controls feel )
                    moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
                    moveDirection = transform.TransformDirection(moveDirection);
                    moveDirection *= speed;


                    //make the player jump if "Space" is pressed        (I want to work on phasing out all of the Unity control things so i can make custom sets.
                    if (Input.GetButton("Jump"))
                        moveDirection.y = jumpSpeed*1.3f;

                    count = 0F;

                }
                //Debug.Log("falling i think");
                count++;
                if (count > 200)
                {
                    current_health = 0;
                }

                //gravity always acting on the player
                moveDirection.y -= gravity * Time.deltaTime;

                //actually move the charecter with this line
                controller.Move(moveDirection * Time.deltaTime);

                //Rotate Player
                transform.Rotate(0, Input.GetAxis("rotate") * rotateSpeed * Time.deltaTime * 25, 0);
            }

            if (current_health <= 0)
            {
                current_health = 0;
                events.end_game(false);
            }
        }

    }

    //collision detection with the player                                                                                                                                               
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "cubeshootbullet")
        {
            Destroy(collision.gameObject);
            current_health--;
        }
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "fire")
        {
            tick();
            tick();
            tick();
            tick();
            Destroy(collision.gameObject);

            
            for (float x = 0; x < 10; x += Time.deltaTime*2)
            {
                if (x % 2 == 0)
                {
                    tick();
                }
            }

        }
        if (collision.gameObject.tag == "laser")
        {
            current_health--;
        }


        if (collision.gameObject.tag == "poinson")
        {
            Destroy(collision.gameObject);

            tick();
            float timer = 0;
            bool firsttick = true, secondtick = true;
            for(float x = 0; x < 5; x += Time.deltaTime)
            {
                if (timer >= 2&&firsttick)
                {
                    tick();
                    timer = 2f;
                    firsttick = false;
                }
                if (timer >= 4&&secondtick)
                {
                    tick();
                    timer = 4f;
                    secondtick = false;
                }
                timer += Time.deltaTime;
            }
            
            
        }

        if(collision.gameObject.tag == "lava")
        {

            while (current_health >= 0)
            {
                current_health--;
            }
        }
        //if player collides w/ the enemy lose hp and destroy enemy. (check enemy class for more info)
        if (collision.gameObject.tag == "enemy")
        {
            current_health--;
            
        }

        if (collision.gameObject.tag == "hp")
        {
            Destroy(collision.gameObject);
            if (current_health+(1 + player_stats.basic_stats[4]) <= 5 * (2 + player_stats.basic_stats[0]))
            {
                current_health+= (1+player_stats.basic_stats[4]);
            }
        }

        if (current_health <= 0)
        {
            current_health = 0;
            events.end_game(false);
        }

    }

    private void tick()
    {
        current_health--;
    }

    private void Children()
    {
        health_text = events.PlayerInfo.transform.Find("Health (Text)").GetComponent<Text>();
        health_bar = events.PlayerInfo.transform.Find("Health").GetComponent<Image>();
        triangle = health_bar.transform.Find("Triangle").GetComponent<Image>();
    }

    private void updateHealth()
    {
        float x_width = original_bar.rectTransform.rect.width * ((float)(current_health-1) / ( (5 * (2 + player_stats.basic_stats[0])) - 1 ) );
        health_bar.rectTransform.sizeDelta = new Vector2(x_width, original_bar.rectTransform.rect.height);
        float x_position = original_bar.transform.localPosition.x - ((original_bar.rectTransform.rect.width - x_width)/2);
        health_bar.rectTransform.anchoredPosition = new Vector2(x_position, original_bar.transform.localPosition.y);
        triangle.rectTransform.anchoredPosition = new Vector2( ((health_bar.rectTransform.rect.width / 2) + (triangle.rectTransform.rect.width / 2) - (float)0.0), 0);
    }

}