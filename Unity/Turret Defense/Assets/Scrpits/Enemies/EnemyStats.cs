using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStats : MonoBehaviour
{
   
    [SerializeField]  public float MaxHealth = 50f;
    [SerializeField] public float Currenthealth;
    public Image EnemyHpBar;
    public PlayerAssets code;
    private int reward = 80;
    
   
  

    public void TakingDamage(float damage)
    {

        Currenthealth -= damage;
        EnemyHpBar.fillAmount = Currenthealth / MaxHealth;
        if (Currenthealth <= 0)
        {
            Destroy(gameObject);
            EnemySpawn.enemyLeft--;
            code.moneyLeft += reward;
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        code = FindObjectOfType<PlayerAssets>();
        Currenthealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
       
        //countDownEnemy = EnemySpawn.enemyLeft;
    }
}
