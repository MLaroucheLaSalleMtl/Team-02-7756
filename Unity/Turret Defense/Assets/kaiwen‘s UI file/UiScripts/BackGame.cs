using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BackGame : MonoBehaviour {

    [SerializeField] public GameObject PausePanel;
    
    public bool pausePanel = false;



    // Use this for initialization
    void Start()
    {
        PausePanel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GamePanelFunction();
        }
    }
    public void GamePanelFunction()
    {
       
      
            pausePanel = false;
            PausePanel.SetActive(false);
        
  
    }
   
}
