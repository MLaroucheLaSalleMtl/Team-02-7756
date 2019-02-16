using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSelection : MonoBehaviour
{

    BuildTurret buildTurretRef;
    // Start is called before the first frame update
    void Start()
    {
        buildTurretRef = BuildTurret.myInstance;
    }

    // Update is called once per frame
    public void BuyTurret_1()
    {
        buildTurretRef.TurretSelection(buildTurretRef.turret_1);
       
    }
    public void BuyTurret_2()
    {
        buildTurretRef.TurretSelection(buildTurretRef.turret_2);

    }
    public void BuyTurret_3()
    {
        buildTurretRef.TurretSelection(buildTurretRef.turret_3);

    }
}
