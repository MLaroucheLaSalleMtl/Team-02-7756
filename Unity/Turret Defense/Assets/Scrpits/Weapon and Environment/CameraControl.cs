using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public float speed = 25f;
    public float Thickness = 10f;
    public Vector2 limit;
    private float minY = 10f;
    [SerializeField]
    private float maxY = 25f;
    private float scrollSpeed = 10f;

    private void Update()
    {
        Vector3 pos = transform.position;
        if (Input.GetKey("w")||Input.mousePosition.y>=Screen.height-Thickness)
        {
            pos.z += speed * Time.deltaTime;
        }
        if (Input.GetKey("s")|| Input.mousePosition.y<=Thickness)
        {
            pos.z -= speed * Time.deltaTime;

        }
        if (Input.GetKey("d")|| Input.mousePosition.x>=Screen.width-Thickness )
        {
            pos.x += speed * Time.deltaTime;
        }
        if (Input.GetKey("a")|| Input.mousePosition.x<=Thickness)
        {
            pos.x -= speed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        pos.y -= scroll * scrollSpeed *80* Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, 32, limit.x);
        pos.z = Mathf.Clamp(pos.z, -limit.y, -15);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);

        transform.position = pos;
    }
}
