using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCube : MonoBehaviour
{
    [SerializeField] Color pressColor;
    private Renderer r;
    private Color originalColor;
    private GameObject turret;
    private Vector3 positionOffset_CannonTower;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
        originalColor = r.material.color;
        positionOffset_CannonTower = new Vector3(0.2f, 0.91f, 0.3f);
    }

    void OnMouseEnter()
    {
        r.material.color = pressColor;
    }

    void OnMouseExit()
    {
        r.material.color = originalColor;
    }

    void OnMouseDown()
    {
        if(turret != null)
        {
            Debug.Log("Can't Build");
            return; 
        }

        GameObject turretToBuild = BuildTurret.myInstance.GetTurrettoBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + positionOffset_CannonTower, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
