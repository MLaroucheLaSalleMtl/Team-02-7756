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
    private int Reward_Normal_Fast = 80;
    private int Reward_Boss = 200;
    public EnemySpawn EnSp;

    public float OldSpeed;
    private float NewStartSpeed;
    
   public enum EnemyType
    {
        Normal,
        Fast,
        Boss
    }
    public EnemyType ENEMYTYPE;

    public void Slow(float value)
    {
        OldSpeed = NewStartSpeed * (1f - value);
      //  enmMove.speed = enmMove.StartSpeed*(1f - value);
    }

    public void TakingDamage(float damage)
    {

        Currenthealth -= damage;
        EnemyHpBar.fillAmount = Currenthealth / MaxHealth;
        if (Currenthealth <= 0)
        {
            Destroy(gameObject);
            EnSp.EnemyDefeated();

            if (ENEMYTYPE == EnemyType.Normal || ENEMYTYPE == EnemyType.Fast)
            {
                code.moneyLeft += Reward_Normal_Fast;
            }
            else if (ENEMYTYPE == EnemyType.Boss)
            {
                code.moneyLeft += Reward_Boss;
            }
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
       
       // enmMove = FindObjectOfType<enemyMove>();
        EnSp = FindObjectOfType<EnemySpawn>();
        code = FindObjectOfType<PlayerAssets>();
        Currenthealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        OldSpeed = gameObject.GetComponent<enemyMove>().speed;
        NewStartSpeed = gameObject.GetComponent<enemyMove>().StartSpeed;

        //countDownEnemy = EnemySpawn.enemyLeft;
    }
}
