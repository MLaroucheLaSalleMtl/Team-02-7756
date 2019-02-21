using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCube : MonoBehaviour
{
    [SerializeField] Color pressColor;
    private Renderer r;
    private Color originalColor;
    private GameObject turret;
    private Vector3 posOffset_CannonTower;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
        originalColor = r.material.color;
        posOffset_CannonTower = new Vector3(0.94f, 3.5f, 2f);
    }

    void OnMouseEnter()
    {
        if (BuildTurret.myInstance.GetTurrettoBuild() == null)
        {
            return;
        }
        r.material.color = pressColor;
    }

    void OnMouseExit()
    {
        r.material.color = originalColor;
    }

    void OnMouseDown()
    {
        if (BuildTurret.myInstance.GetTurrettoBuild() == null)
        {
            return;
        }
        if(turret != null)
        {
            Debug.Log("Can't Build");
            return; 
        }

        GameObject turretToBuild = BuildTurret.myInstance.GetTurrettoBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + posOffset_CannonTower, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
