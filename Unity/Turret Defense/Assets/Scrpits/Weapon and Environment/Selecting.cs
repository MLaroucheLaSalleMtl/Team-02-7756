﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Selecting : MonoBehaviour
{
    
    PlayerAssets money;
   // TurretBehaviour firerate;
   private int MachineGunSell = 50;
    private int CannonSell = 100;
    private int MissleSell = 50;
    private int GlaceSell = 50;
    [SerializeField] private Button SellbUTTON;
    [SerializeField] private Button UpgradeButton;

    public enum PriceForSell
    {
        MachineGun,
        Cannon,
        Missile,
        Glace
    }
    public PriceForSell price;


    public void Upgradde()
    {
        if (price == PriceForSell.MachineGun)
        {

            gameObject.GetComponent<TurretBehaviour>().fireRate += 3;
            money.moneyLeft -= 200;
         
        }
        if (price == PriceForSell.Cannon)
        {
            gameObject.GetComponent<TurretBehaviour>().TowerBaseDamage *= 2;
            money.moneyLeft -= 300;

        }
        if (price == PriceForSell.Missile)
        {
            money.moneyLeft -= 200;
            gameObject.GetComponent<TurretBehaviour>().TowerBaseDamage *= 2;
            gameObject.GetComponent<TurretBehaviour>().fireRate += 2;

        }
        if (price == PriceForSell.Glace)
        {
            money.moneyLeft -= 100;
            gameObject.GetComponent<TurretBehaviour>().DamageOvertime *= 1.5f;
            gameObject.GetComponent<TurretBehaviour>().SlowValue *= 1.4f;

        }
    }

     public   void Sell()
    {
        if (price == PriceForSell.MachineGun)
        {
            money.moneyLeft += MachineGunSell;
            Destroy(gameObject);
        }
        if (price == PriceForSell.Cannon)
        {
            money.moneyLeft += CannonSell;
            Destroy(gameObject);
        }
        if (price == PriceForSell.Missile)
        {
            money.moneyLeft += MissleSell;
            Destroy(gameObject);
        }
        if (price == PriceForSell.Glace)
        {
            money.moneyLeft += GlaceSell;
            Destroy(gameObject);
        }

    }
        // Start is called before the first frame update
    void Start()
    {
       
        money = FindObjectOfType<PlayerAssets>();
       // bullet = FindObjectOfType<BulletBehaviour>();
       // firerate = FindObjectOfType<TurretBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if (price == PriceForSell.MachineGun)
        {
            UpgradeButton.interactable = (money.moneyLeft < 200) ? false : true;
        }
        if (price == PriceForSell.Cannon)
        {
            UpgradeButton.interactable = (money.moneyLeft < 300) ? false : true;
        }
        if (price == PriceForSell.Missile)
        {
            UpgradeButton.interactable = (money.moneyLeft < 200) ? false : true;
        }
        if (price == PriceForSell.Glace)
        {
            UpgradeButton.interactable = (money.moneyLeft < 100) ? false : true;
        }

    }
}
