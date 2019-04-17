using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public GameObject TimeButton;
    public GameObject RewindButton;
    
    private bool Speed = false;

    public void PressSpeedin()
    {
        Speed = true;
        Time.timeScale = 1.5f;
        Debug.Log("Speed Up!");
        TimeButton.SetActive(false);
        RewindButton.SetActive(true);
    }

    
    public void RewindSpeed()
    {
        TimeButton.SetActive(true);
        RewindButton.SetActive(false);
        Speed = false;
        Time.timeScale = 1f;

    }
    // Start is called before the first frame update
    void Start()
    {
        TimeButton.SetActive(true);
        RewindButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
      
        
    }
}
