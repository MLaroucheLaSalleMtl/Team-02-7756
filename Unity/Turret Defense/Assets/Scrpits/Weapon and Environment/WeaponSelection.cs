using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelection : MonoBehaviour
{

    BuildTurret buildTurretRef;
    PlayerAssets playerAssetsRef;
    

    public int turretPrice_1 = 100;
    public int turretPrice_2 = 200;
    public int turretPrice_3 = 100;
    public int turretPrice_4 = 100;
    void Start()
    {
        buildTurretRef = BuildTurret.myInstance;
        playerAssetsRef = FindObjectOfType<PlayerAssets>();
       
        
    }
   

    public void BuyTurret_1()
    {
        Debug.Log("1");
        buildTurretRef.TurretSelection(buildTurretRef.turret_1,turretPrice_1);
        
    }
    public void BuyTurret_2()
    {
        Debug.Log("2");
        buildTurretRef.TurretSelection(buildTurretRef.turret_2,turretPrice_2);
        
    }

    public void BuyTurret_3()
    {
        Debug.Log("3");
        buildTurretRef.TurretSelection(buildTurretRef.turret_3,turretPrice_3);
        
    }

    public void BuyTurret_4()
    {
        Debug.Log("4");
        buildTurretRef.TurretSelection(buildTurretRef.turret_4, turretPrice_4);
       
    }


}
