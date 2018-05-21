using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public GameObject basicboy, cubeshoot, flyboy, jumpyvboby, poinson, fire, large;
    private float timer = 0f;
    // Use this for initialization
    void Start()
    {

    }
    private bool wave1 = true, wave2 = true, wave3 = true, wave4 = true, wave5 = true, wave6 = true, wave7 = true;
    // Update is called once per frame
    void Update()
    {

        if (timer == 0 && wave1)
        {
            for (int x = 0; x < 3; x++)
            {
                enemyspawn(basicboy);
            }
            wave1 = false;
        }
        if (timer >= 15f && wave2)
        {
            for (int x = 0; x < 3; x++)
            {
                enemyspawn(basicboy);
                enemyspawn(cubeshoot);
            }
            timer = 15f;
            wave2 = false;

        }
        if (timer >= 30f && wave3)
        {
            for (int x = 0; x < 3; x++)
            {
                enemyspawn(cubeshoot);
                enemyspawn(basicboy);
                enemyspawn(flyboy);
            }
            timer = 30f;
            wave3 = false;
        }

        if (timer >= 45f && wave4)
        {
            for (int x = 0; x < 3; x++)
            {
                enemyspawn(cubeshoot);
                enemyspawn(basicboy);
                enemyspawn(jumpyvboby);
                enemyspawn(flyboy);
            }
            timer = 45f;
            wave4 = false;

        }
        if (timer >= 60f && wave5)
        {
            for (int x = 0; x < 3; x++)
            {
                enemyspawn(jumpyvboby);
                enemyspawn(cubeshoot);
                enemyspawn(basicboy);
                enemyspawn(poinson);
                enemyspawn(flyboy);
            }
            timer = 60f;
            wave5 = false;
        }
        if (timer >= 75f && wave6)
        {
            for (int x = 0; x < 3; x++)
            {
                enemyspawn(jumpyvboby);
                enemyspawn(cubeshoot);
                enemyspawn(basicboy);
                enemyspawn(fire);
                enemyspawn(poinson);
                enemyspawn(flyboy);
            }
            timer = 75f;
            wave6 = false;
        }
        if (timer >= 90f && wave7)
        {
            for (int x = 0; x < 3; x++)
            {
                enemyspawn(jumpyvboby);
                enemyspawn(cubeshoot);
                enemyspawn(basicboy);
                enemyspawn(large);
                enemyspawn(poinson);
                enemyspawn(fire);
                enemyspawn(flyboy);
            }
            timer = -15f;
            wave7 = true;
            wave1 = true;
            wave2 = true;
            wave3 = true;
            wave4 = true;
            wave5 = true;
            wave6 = true;
            
        }

        Debug.Log(timer);
        timer += Time.deltaTime;
    }


    void enemyspawn(GameObject enemy)
    {
        Vector3 spawnloc = new Vector3(Random.Range(-60f, 60f), 12, Random.Range(-60.0f, 60.0f));
        GameObject Temp = Instantiate(enemy, spawnloc, transform.rotation);
        Destroy(Temp, 15f);
    }
}
