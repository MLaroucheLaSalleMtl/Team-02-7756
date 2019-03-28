using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WaveDect : MonoBehaviour
{
    public GameObject Normal_ImageCurrentWaveNormal;
    public GameObject Fast_ImageCurrentWaveFast;
    public GameObject Boss_ImageCurrentWaveBoss;

    private bool normal = false;
    private bool fast = false;
    private bool boss = false;
    //public EnemyStats Enemiees;


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Tag_Normal>() != null)
        {
            normal = true;

        }
        else
        {
            normal = false;
        }
        
        if (other.GetComponent<Tag_Fast>() != null)
        {
            fast = true;
           
        }
        else
        {
            fast = false;
        }
        if (other.GetComponent<Tag_Boss>() != null)
        {
            boss = true;
            
        }
        else
        {
            boss = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
        
        
      //  Enemiees = FindObjectOfType<EnemyStats>();
    }

    // Update is called once per frame
    void Update()
    {
        if (normal == true)
        {
            Normal_ImageCurrentWaveNormal.SetActive(true);
        }
        if(normal==false)
        {
            Normal_ImageCurrentWaveNormal.SetActive(false); 
        }
        if (fast == true)
        {
            Fast_ImageCurrentWaveFast.SetActive(true);
        }
        if (fast == false)
        {
            Fast_ImageCurrentWaveFast.SetActive(false);
        }
        if (boss == true)
        {
            Boss_ImageCurrentWaveBoss.SetActive(true);
        }
        if(boss==false)
        {
            Boss_ImageCurrentWaveBoss.SetActive(false);
        }
    }
}
