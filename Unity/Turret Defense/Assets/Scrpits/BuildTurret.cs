﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildTurret : MonoBehaviour
{ 
    public static BuildTurret myInstance;
    [SerializeField] private GameObject turretToBuild;

    void Awake()
    {
        if (myInstance ==null)
        {
            myInstance = this;
        }
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
