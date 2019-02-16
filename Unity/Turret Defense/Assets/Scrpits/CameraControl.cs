using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{




    void Update()
    {

        if (Input.mousePosition.y >= Screen.height - 5f)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 10f, Space.World);
        }
    
        if(Input.mousePosition.y <= 5f)
        {
            transform.Translate(Vector3.back * Time.deltaTime * 10f,Space.World);
        }
        if(Input.mousePosition.x >= Screen.width - 5f)
        {
            transform.Translate(Vector3.right * Time.deltaTime * 10f);
        }
        if (Input.mousePosition.x <= 5f)
        {
            transform.Translate(Vector3.left * Time.deltaTime * 10f);
        }

        Mathf.Clamp(transform.position.y, 10f, 80f);
        Mathf.Clamp(transform.position.x, 10f,80f);
        
    }
}
