﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MapCube : MonoBehaviour
{
    [SerializeField] Color pressColor;
    private Renderer r;
    private Color originalColor;
    private GameObject turret;
    private Vector3 posOffset_CannonTower;

    private PlayerAssets playerAssetsRef;

    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Renderer>();
        originalColor = r.material.color;
       

        playerAssetsRef = FindObjectOfType<PlayerAssets>();
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
        if(playerAssetsRef.moneyLeft < 0)
        {
            Debug.Log("No more build");
            return;
        }

        GameObject turretToBuild = BuildTurret.myInstance.GetTurrettoBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position, transform.rotation);

        BuildTurret.myInstance.SetTurretToBuildToBeEmpty();
        
    }
    

    void Update()
    {
        
    }
}
