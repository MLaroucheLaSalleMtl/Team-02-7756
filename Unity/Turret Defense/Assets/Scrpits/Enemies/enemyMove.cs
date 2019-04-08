using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent (typeof(EnemyStats))]
public class enemyMove: MonoBehaviour
{

    //[SerializeField]
   // public float StartSpeed = 10f; 
   
   
   

    private EnemyStats FinalSpeed;
    private RouteEnemy NodePoints;
    private int IndexOfNodes;

    // Start is called before the first frame update
    void Start()
    {
        FinalSpeed = GetComponent<EnemyStats>();
        
       
        NodePoints = GameObject.FindGameObjectWithTag("Nodes").GetComponent<RouteEnemy>();
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(NodePoints.NodePoints[IndexOfNodes].position - transform.position),FinalSpeed.speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, NodePoints.NodePoints[IndexOfNodes].position, FinalSpeed.speed * Time.deltaTime);

        FinalSpeed.speed = FinalSpeed.StartSpeed;
        if (Vector3.Distance(transform.position, NodePoints.NodePoints[IndexOfNodes].position) < 0.1f)
        {
            if (IndexOfNodes < NodePoints.NodePoints.Length - 1)
            {
                IndexOfNodes++;
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    
}
