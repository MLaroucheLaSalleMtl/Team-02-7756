using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{




    void Update()
    {

        if (Input.mousePosition.y >= Screen.height - 20f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 10f, Space.World);
        }
    
        if(Input.mousePosition.y <= 20f)
        {
            transform.Translate(Vector3.back * Time.deltaTime * 10f,Space.World);
        }
        if(Input.mousePosition.x >= Screen.width - 20f)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 10f);
        }
        if (Input.mousePosition.x <= 20f)
        {
            transform.Translate(Vector3.left * Time.deltaTime * 10f);
        }

        Vector3 v3 = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        v3.z = Mathf.Clamp(transform.position.z, -90f,  90f);
        v3.x = Mathf.Clamp(transform.position.x, -30f,90f);
        transform.position = v3;

        
     
        Camera.main.fieldOfView -= Input.GetAxis("Mouse ScrollWheel")* 10f;

        if(Camera.main.fieldOfView < 10f)
        {
            Camera.main.fieldOfView = 10f;
        }
        else if(Camera.main.fieldOfView > 50f)
        {
            Camera.main.fieldOfView = 50f;
        }

    }
}
