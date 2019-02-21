using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTurret : MonoBehaviour
{ 
    public static BuildTurret myInstance;
    public GameObject turret_1;
    public GameObject turret_2;
    public GameObject turret_3;
    private GameObject turretToBuild;

    void Awake()
    {
        if (myInstance ==null)
        {
            myInstance = this;
        }
    }

    
    public void TurretSelection(GameObject turret)
    {
        turretToBuild = turret;
        Debug.Log(turret.name);
    }
    public GameObject GetTurrettoBuild()
    {
        return turretToBuild;

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
