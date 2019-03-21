using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTurret : MonoBehaviour
{ 
    public static BuildTurret myInstance;
    public GameObject turret_1;
    public GameObject turret_2;
    public GameObject turret_3;
    public GameObject turretToBuild;
    public int turretPrice;
    
    void Awake()
    {
        if (myInstance ==null)
        {
            myInstance = this;
        }
    }

    
    public void TurretSelection(GameObject turret,int price)
    {
        turretToBuild = turret;
        turretPrice = price;
        
    }
    public GameObject GetTurrettoBuild()
    {
        return turretToBuild;
    }

    public int GetTurretPrice()
    {
        return turretPrice;
    }

    public void SetTurretToBuildToBeEmpty()
    {
        turretToBuild = null;
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
