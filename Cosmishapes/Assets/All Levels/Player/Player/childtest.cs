using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class childtest : MonoBehaviour
{
    public GameObject bullet;
    public float distance = 10.0f;
    private float canshootint = 3F;
    private bool canshootbool = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (canshootint >= .1F)
        {
            canshootbool = true;
        }
        canshootint += Time.deltaTime;

        if (Input.GetMouseButton(0)&& canshootbool)
        {
            //Input.mousePosition.y
            Vector3 position = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
            position = Camera.main.ScreenToWorldPoint(position);

            GameObject go = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            go.transform.LookAt(position);
            Debug.Log(position);
            go.GetComponent<Rigidbody>().AddForce(go.transform.forward * 1000);
            canshootbool = false;
            canshootint = 0F;
        }
    }
}
