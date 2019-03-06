using System.Collections;
using System.Collections.Generic;
using UnityEngine;

  public class BaseLifeDescrease : MonoBehaviour
  {
    public float baseLife = 10f;
    public bool lostLiffe;



    public void LostLife()
    {
         baseLife--;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("lost life baby");
            lostLiffe = true;
            LostLife();
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        lostLiffe = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  }
