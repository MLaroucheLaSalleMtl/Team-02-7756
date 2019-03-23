using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject ExplosionEffect;
    private Transform target;
    [SerializeField] private float bulletSpeed = 5f;
    private float BulletDamage = 50f;
    public EnemyStats enemies;
   // [SerializeField] public GameObject SpecialTarget;
    
    public enum BulletType
    {
        MachineGunBullet,
        CannonBullet,
        MissileBullet
    }
    public BulletType bulletType;

     void OnTriggerEnter(Collider col)
    {
        
        //Machine Gun Behavior

        if (col.GetComponent<Tag_Normal>() != null && col.gameObject.tag=="Enemy" && bulletType==BulletType.MachineGunBullet)
        {
            EnemyStats Myenemy = target.GetComponent<EnemyStats>();
            Myenemy.TakingDamage(BulletDamage*2);
            GameObject cloneEffect = (GameObject)Instantiate(ExplosionEffect, target.transform.position, target.transform.rotation);
            Instantiate(cloneEffect);
            Destroy(cloneEffect, 2f);
            Destroy(gameObject);
        }


        if ((col.GetComponent<Tag_Fast>()!=null||col.GetComponent<Tag_Boss>()!=null) && bulletType == BulletType.MachineGunBullet && col.gameObject.tag == "Enemy")
        {
            //  && enemies.enemyTypee == EnemyStats.enemyType.Normal
            EnemyStats Myenemy = target.GetComponent<EnemyStats>();
            Myenemy.TakingDamage(BulletDamage*0.5f);
            GameObject cloneEffect = (GameObject)Instantiate(ExplosionEffect, target.transform.position, target.transform.rotation);
            Instantiate(cloneEffect);
            Destroy(cloneEffect, 2f);
            Destroy(gameObject);

         }

        //Cannon tower behavior
        if ((col.GetComponent<Tag_Normal>() != null || col.GetComponent<Tag_Fast>()!=null) && col.gameObject.tag == "Enemy" && bulletType == BulletType.CannonBullet)
        {
            EnemyStats Myenemy = target.GetComponent<EnemyStats>();
            Myenemy.TakingDamage(BulletDamage * 1.5f);
            GameObject cloneEffect = (GameObject)Instantiate(ExplosionEffect, target.transform.position, target.transform.rotation);
            Instantiate(cloneEffect);
            Destroy(cloneEffect, 2f);
            Destroy(gameObject);
        }
        if (col.GetComponent<Tag_Boss>() != null && col.gameObject.tag == "Enemy" && bulletType == BulletType.CannonBullet)
        {
            EnemyStats Myenemy = target.GetComponent<EnemyStats>();
            Myenemy.TakingDamage(BulletDamage*1.5f);
            GameObject cloneEffect = (GameObject)Instantiate(ExplosionEffect, target.transform.position, target.transform.rotation);
            Instantiate(cloneEffect);
            Destroy(cloneEffect, 2f);
            Destroy(gameObject);
        }

        //Missile Tower behavior
        if((col.GetComponent<Tag_Normal>()!=null||col.GetComponent<Tag_Boss>()!=null)&& col.gameObject.tag=="Enemy" && bulletType == BulletType.MissileBullet)
        {
            EnemyStats Myenemy = target.GetComponent<EnemyStats>();
            Myenemy.TakingDamage(BulletDamage *0.8f);
            GameObject cloneEffect = (GameObject)Instantiate(ExplosionEffect, target.transform.position, target.transform.rotation);
            Instantiate(cloneEffect);
            Destroy(cloneEffect, 2f);
            Destroy(gameObject);
        }
        if(col.GetComponent<Tag_Fast>()!=null&&col.gameObject.tag=="Enemy" && bulletType == BulletType.MissileBullet)
        {
            EnemyStats Myenemy = target.GetComponent<EnemyStats>();
            Myenemy.TakingDamage(BulletDamage * 2);
            GameObject cloneEffect = (GameObject)Instantiate(ExplosionEffect, target.transform.position, target.transform.rotation);
            Instantiate(cloneEffect);
            Destroy(cloneEffect, 2f);
            Destroy(gameObject);
        }


    }

    public void ChaseTarget(Transform targetRef)
    {
        target = targetRef;
    }

    void Hit()
    {
        Debug.Log("Hit!");
        //Destroy(gameObject);
        //Destroy(target.gameObject);
    }

    private void Start()
    {
        enemies = GameObject.Find("EnemyStats").GetComponent<EnemyStats>();
    }

    void Update()
    {
        
       
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 targetDir = target.position - transform.position;
        float bulletTravelDistancePerFrame = bulletSpeed * Time.deltaTime;

        if(targetDir.magnitude <= bulletTravelDistancePerFrame)
        {
            Hit();
            return;
            
        }

        transform.Translate(targetDir.normalized * bulletTravelDistancePerFrame, Space.World);
    }
}
