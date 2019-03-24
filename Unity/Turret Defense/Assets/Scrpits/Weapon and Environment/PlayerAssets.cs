﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAssets: MonoBehaviour
{
    GameManager code;
    [SerializeField] private Text lifeText;
    [SerializeField] Text moneyText;

    [SerializeField] private Button button1;
    [SerializeField] private Button button2;
    [SerializeField] private Button button3;

    private BuildTurret buildTurretRref;

    private BaseLifeDescrease baseLifeDecreaseRef;
    private WeaponSelection weaponSelectionRef;
   
    public int starterMoney = 300;
    public int moneyLeft = 0;
    
   

    

    
    void Start()
    {
        code = GameObject.Find("GameManager").GetComponent<GameManager>();

        baseLifeDecreaseRef = FindObjectOfType<BaseLifeDescrease>();
        weaponSelectionRef = FindObjectOfType<WeaponSelection>();
        moneyLeft = starterMoney;
        

        //lifeText.text = baseLifeDecreaseRef.baseLife.ToString();
        //moneyText.text = moneyLeft.ToString();
    }

   
    void Update()
    {



        //Disable the weapon butttons when moneyleft hits 0

        button1.interactable = (moneyLeft < 100) ? false : true;
        button3.interactable = (moneyLeft < 100) ? false : true;
        button2.interactable = (moneyLeft < 200) ? false : true;
        

        
        if (moneyLeft <=0)
        {
            moneyLeft = 0;
        }



        lifeText.text = "   " + baseLifeDecreaseRef.baseLife.ToString();
        moneyText.text =  moneyLeft.ToString();


        if (baseLifeDecreaseRef.baseLife <= 0)
        {
            code.GameOver();
        }
        
    }

    public void MoneyDeduction(int Money)
    {
        Debug.Log("moneyLeft " + Money);
        moneyLeft -= Money;
    }
    
}
