using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  public class BaseLifeDescrease : MonoBehaviour
  {
    public float baseLife = 10f;
    public bool lostLiffe;
    public EnemySpawn loseLife;


    public void LostLife()
    {
         baseLife--;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            loseLife.EnemyDefeated();
            Debug.Log("lost life baby");
            lostLiffe = true;
            LostLife();
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        loseLife = FindObjectOfType<EnemySpawn>();
        lostLiffe = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  }
