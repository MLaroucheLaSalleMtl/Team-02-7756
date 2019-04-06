using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove: MonoBehaviour
{
    [SerializeField]
    public float StartSpeed = 10f; 
   
   
    public float speed;

    public EnemyStats FinalSpeed;
    private RouteEnemy NodePoints;
    private int IndexOfNodes;

    // Start is called before the first frame update
    void Start()
    {
        FinalSpeed = FindObjectOfType<EnemyStats>();
        NodePoints = GameObject.FindGameObjectWithTag("Nodes").GetComponent<RouteEnemy>();
        speed = StartSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(NodePoints.NodePoints[IndexOfNodes].position - transform.position), speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, NodePoints.NodePoints[IndexOfNodes].position, FinalSpeed.OldSpeed * Time.deltaTime);
        
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
