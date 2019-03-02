using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAssets: MonoBehaviour
{
    [SerializeField] private Text lifeText;
    [SerializeField] private Text moneyText;

    [SerializeField] private Button button1;
    [SerializeField] private Button button2;
    [SerializeField] private Button button3;


    private BaseLifeDescrease baseLifeDecreaseRef;
    private WeaponSelection weaponSelectionRef;
    
    public int starterMoney = 600;
    public int moneyLeft = 0;

    
    void Start()
    {
        baseLifeDecreaseRef = FindObjectOfType<BaseLifeDescrease>();
        weaponSelectionRef = FindObjectOfType<WeaponSelection>();
        moneyLeft = starterMoney;
        

        lifeText.text = "Lifes: " + baseLifeDecreaseRef.baseLife.ToString();
        moneyText.text = "Money: " + moneyLeft.ToString();
    }

   
    void Update()
    {
        
        

        //Disable the weapon butttons when moneyleft hits 0
        if (moneyLeft <= 0)
        {
            moneyLeft = 0;
            button1.interactable = false;
            button2.interactable = false;
            button3.interactable = false;
        }

        lifeText.text = "Lifes: " + baseLifeDecreaseRef.baseLife.ToString();
        moneyText.text = "Money: " + moneyLeft.ToString();
        
    }

    
}
