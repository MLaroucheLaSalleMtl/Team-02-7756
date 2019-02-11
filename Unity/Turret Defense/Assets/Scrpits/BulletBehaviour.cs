﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Transform target;
    [SerializeField] private float bulletSpeed = 5f;

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
