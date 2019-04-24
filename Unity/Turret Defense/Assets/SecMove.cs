using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecMove : MonoBehaviour
{
   

        //[SerializeField]
        // public float StartSpeed = 10f; 

        private EnemyStats FinalSpeed;
    private SecNode pooint;
        private int IndexOfNodes;

        // Start is called before the first frame update
        void Start()
        {
            FinalSpeed = GetComponent<EnemyStats>();


            pooint = GameObject.FindGameObjectWithTag("Point").GetComponent<SecNode>();

        }

        // Update is called once per frame
        void Update()
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(pooint.SecPoints[IndexOfNodes].position - transform.position), FinalSpeed.speed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, pooint.SecPoints[IndexOfNodes].position, FinalSpeed.speed * Time.deltaTime);

            FinalSpeed.speed = FinalSpeed.StartSpeed;
            if (Vector3.Distance(transform.position, pooint.SecPoints[IndexOfNodes].position) < 0.1f)
            {
                if (IndexOfNodes < pooint.SecPoints.Length - 1)
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
