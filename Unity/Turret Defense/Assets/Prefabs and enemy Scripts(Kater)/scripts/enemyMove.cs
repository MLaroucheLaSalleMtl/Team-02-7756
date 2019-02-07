using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove: MonoBehaviour
{
    [SerializeField]
    private float speed;

    private RouteEnemy NodePoints;
    private int IndexOfNodes;

    // Start is called before the first frame update
    void Start()
    {
        NodePoints = GameObject.FindGameObjectWithTag("Nodes").GetComponent<RouteEnemy>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, NodePoints.NodePoints[IndexOfNodes].position, speed * Time.deltaTime);
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
