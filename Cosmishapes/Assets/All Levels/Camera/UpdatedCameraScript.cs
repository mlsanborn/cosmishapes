using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdatedCameraScript : MonoBehaviour
{
    public GameObject target;
    public float damping = 0;
    Vector3 offset;
    Vector3 cameraOffSet;

    void Start()
    {
        offset = target.transform.position - transform.position;
        cameraOffSet = new Vector3(0, 4, 0);
    }

    void LateUpdate()
    {
        /*if (Input.GetKey(KeyCode.Equals))
        {

            transform.position.Set(transform.position.x + 0.0f, transform.position.y + .1f, transform.position.z - .1f);
        }
        if (Input.GetKey(KeyCode.Minus))
        {
            transform.position.Set(transform.position.x + 0.0f, transform.position.y - .1f, transform.position.z + .1f);
            
        }*/
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0.0f)
        {
            if (gameObject.GetComponent<Camera>().fieldOfView <= 120 && gameObject.GetComponent<Camera>().fieldOfView >= 40)
            {
                
                gameObject.GetComponent<Camera>().fieldOfView += -scroll * 15;
            }
            else if(gameObject.GetComponent<Camera>().fieldOfView > 120)
            {
                gameObject.GetComponent<Camera>().fieldOfView--;
            }
            else if (gameObject.GetComponent<Camera>().fieldOfView < 40)
            {
                gameObject.GetComponent<Camera>().fieldOfView++;
            }
            //Debug.Log(gameObject.GetComponent<Camera>().fieldOfView);
        }
        if (target != null)
        {
            float currentAngle = transform.eulerAngles.y;
            float desiredAngle = target.transform.eulerAngles.y;
            float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * damping);

            Quaternion rotation = Quaternion.Euler(0, angle, 0);
            transform.position = target.transform.position - (rotation * offset) + cameraOffSet;

            transform.LookAt(target.transform);
        }
    }
        
}
    
