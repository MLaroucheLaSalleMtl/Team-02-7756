using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
    private int countDownEnemy;
   [SerializeField]  public float MaxHealth = 100f;
   [SerializeField] public float Currenthealth;
    public Image EnemyHpBar;

    public void TakingDamage(float damage)
    {

        Currenthealth -= damage;
        EnemyHpBar.fillAmount = Currenthealth / MaxHealth;
        if (Currenthealth <= 0)
        {
            Destroy(gameObject);
           
         
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
        Currenthealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //countDownEnemy = EnemySpawn.enemyLeft;
    }
}
