using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject ExplosionEffect;
    private Transform target;
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private float BulletDamage = 20f;
    //public GameObject enemy;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            
            EnemyStats Myenemy = target.GetComponent<EnemyStats>();
            Myenemy.TakingDamage(BulletDamage);
            GameObject cloneEffect = (GameObject)Instantiate(ExplosionEffect,target.transform.position,target.transform.rotation);
            Instantiate(cloneEffect);
            Destroy(cloneEffect, 2f);
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
