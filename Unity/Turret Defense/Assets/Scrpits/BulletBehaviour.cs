using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject ExplosionEffect;
    private Transform target;
    [SerializeField] private float bulletSpeed = 5f;

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
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
        Destroy(gameObject);
        Destroy(target.gameObject);
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
