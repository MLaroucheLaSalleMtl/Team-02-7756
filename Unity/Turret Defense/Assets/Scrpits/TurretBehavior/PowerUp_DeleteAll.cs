using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_DeleteAll : MonoBehaviour
{
    public GameObject Bomb;
    public Transform PowerPosition;
   
    public float BombDamage = 300f;
    public GameObject ButtonDelet;
    EnemyStats loseHp;
    private bool Isbombing = false;
   
    public void SayHi()
    {
        Debug.Log("HIIIIIIIIIIIII");
    }
   

    public void DestoryALLL()
    {

        GameObject BombEffect= (GameObject) Instantiate(Bomb, PowerPosition.transform.position,PowerPosition.transform.rotation);
       // Instantiate(BombEffect);
       
        // Explo.SetActive(true);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        loseHp = FindObjectOfType<EnemyStats>();
       foreach (var AllEnmies in enemies)
        {

            loseHp.TakingDamage(BombDamage);
            //if (AllEn._enemiesInWaveLeft <= 0)
            //{
            //    Powerzero = true;
            //}
        }

        Destroy(BombEffect, 2f);
       
       
    }
    // Start is called before the first frame update
    void Start()
    {
       // Explo.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
