using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSelection : MonoBehaviour
{

    BuildTurret buildTurretRef;
    PlayerAssets playerAssetsRef;
    int turretPrice_1 = 100;
    int turretPrice_2 = 200;
    int turretPrice_3 = 100;

    void Start()
    {
        buildTurretRef = BuildTurret.myInstance;
        playerAssetsRef = FindObjectOfType<PlayerAssets>();

        
        
    }
   

    public void BuyTurret_1()
    {
        buildTurretRef.TurretSelection(buildTurretRef.turret_1);
        playerAssetsRef.moneyLeft -= turretPrice_1;
    }
    public void BuyTurret_2()
    {
        buildTurretRef.TurretSelection(buildTurretRef.turret_2);
        playerAssetsRef.moneyLeft -= turretPrice_2;
    }

    public void BuyTurret_3()
    {
        buildTurretRef.TurretSelection(buildTurretRef.turret_3);
        playerAssetsRef.moneyLeft -= turretPrice_3;
    }

}
