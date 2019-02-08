using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseLifeDescrease : MonoBehaviour
{
    [SerializeField]
    private float BaseLife = 10f;
    public bool lostLiffe;
    void lostLife()
    {
        BaseLife--;
    }
 void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("lost life baby");
            lostLiffe = true;
            lostLife();
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
