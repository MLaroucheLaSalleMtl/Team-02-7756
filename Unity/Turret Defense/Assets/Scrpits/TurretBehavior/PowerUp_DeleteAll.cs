using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_DeleteAll : MonoBehaviour
{



   
    public GameObject Bomb;
    public Transform PowerPosition;
   
    public float BombDamage = 300f;
    public GameObject ButtonDelet;
    private EnemyStats GetMoney;
    EnemySpawn Destoryy;
    private int BombReward = 80;
    private PlayerAssets MoneyCode;
    private TurretBehaviour Power;
 

   

    public void DestoryALLL()
    {
        GetMoney = FindObjectOfType<EnemyStats>(); ;
        MoneyCode = FindObjectOfType<PlayerAssets>();
        GameObject BombEffect= (GameObject) Instantiate(Bomb, PowerPosition.transform.position,PowerPosition.transform.rotation);
        // Instantiate(BombEffect);
        Destroy(BombEffect.gameObject, 2f);
        // Explo.SetActive(true);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        // loseHp = FindObjectOfType<EnemyStats>();
        Destoryy = FindObjectOfType<EnemySpawn>();
       foreach (var AllEnmies in enemies)
        {
            MoneyCode.moneyLeft += BombReward;
            ParticleSystem MyMoney = (ParticleSystem)
                Instantiate(GetMoney.money,GetMoney. moneyPosition.position,GetMoney. moneyPosition.rotation);

            Destroy(MyMoney.gameObject, 2.0f);

            Destoryy.EnemyDefeated();
            Destroy(AllEnmies);
           
           // loseHp.TakingDamage(BombDamage);
            //if (AllEn._enemiesInWaveLeft <= 0)
            //{
            //    Powerzero = true;
            //}
        }      
    }

    
    // Start is called before the first frame update
    void Start()
    {
       // Explo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
        //if (PowerCoolDown == true)
        //{
        //    PowerTimer = 4f;
        //}
    }
}
