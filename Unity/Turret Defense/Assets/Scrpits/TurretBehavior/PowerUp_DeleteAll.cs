using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_DeleteAll : MonoBehaviour
{



    private LightControl miss;
    public GameObject Bomb;
    public Transform PowerPosition;
   
    public float BombDamage = 300f;
    public GameObject ButtonDelet;
    private EnemyStats GetMoney;
    EnemySpawn Destoryy;
    private int BombReward = 80;
    private PlayerAssets MoneyCode;
    private TurretBehaviour Power;
    private float PowerFireRate = 7f;
    private float NewPowerRate;

    public float PowerTimer = 8f;
    public bool PowerCoolDown = false;

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

    public void Accelerating()
    {
        InvokeRepeating("Powers", 0f,1f);
       

    }

    public void Powers()
    {
        miss = FindObjectOfType<LightControl>();
        miss.MisslIght.SetActive(true);
        PowerTimer--;
        Power = FindObjectOfType<TurretBehaviour>();
        GameObject[] CurrentTurret = GameObject.FindGameObjectsWithTag("Turret");
        Power.fireRate += PowerFireRate;
        if (PowerTimer <= 0f)
        {
            PowerTimer = 0f;
            CancelInvoke("Powers");
            PowerCoolDown = true;
            Power.fireRate = 1;
            PowerTimer = 8f;
           miss. MisslIght.SetActive(false);
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
