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

    [SerializeField] private GameObject GameOverMenu;
    [SerializeField] private bool isGameOver = false;

    private BuildTurret buildTurretRref;

    private BaseLifeDescrease baseLifeDecreaseRef;
    private WeaponSelection weaponSelectionRef;
   
    public int starterMoney = 300;
    public int moneyLeft = 0;
    
   

    

    
    void Start()
    {
        baseLifeDecreaseRef = FindObjectOfType<BaseLifeDescrease>();
        weaponSelectionRef = FindObjectOfType<WeaponSelection>();
        moneyLeft = starterMoney;
        

        //lifeText.text = "Lifes: " + baseLifeDecreaseRef.baseLife.ToString();
        //moneyText.text = "$: " + moneyLeft.ToString();
    }

   
    void Update()
    {



        //Disable the weapon butttons when moneyleft hits 0

        button1.interactable = (moneyLeft < 100) ? false : true;
        button3.interactable = (moneyLeft < 100) ? false : true;
        button2.interactable = (moneyLeft < 200) ? false : true;
        

        //if (moneyLeft < 100)
        //{
        //    button1.interactable = false;
        //    button3.interactable = false;
        //}
        //else
        //{
        //    button1.interactable = true;
        //    button3.interactable = true;
        //}
            
        //if (moneyLeft < 200)
        //{
        //    button2.interactable = false;
        //}
        if (moneyLeft <=0)
        {
            moneyLeft = 0;
        }



        lifeText.text = "Lifes: " + baseLifeDecreaseRef.baseLife.ToString();
        moneyText.text = "$: " + moneyLeft.ToString();


        if (baseLifeDecreaseRef.baseLife <= 0&& !isGameOver )
        {
            isGameOver = true;
            GameOverMenu.SetActive(true);
            Time.timeScale = 0f;
            if (isGameOver && GameOverMenu)
            {
                FindObjectOfType<AudioManager>().Play("LoseMusic");
            }
        }
        
    }

    
    
}
