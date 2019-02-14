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
        PausePanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log("enter");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel = true;
            PausePanel.SetActive(true);
        }
        //GamePanelFunction();
    }
    public void GamePanelFunction()
    {
        Debug.Log("enter");
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pausePanel = true;
            PausePanel.SetActive(true);
        }
        else if (pausePanel  && Input.GetButtonDown("Jump"))
        {
            pausePanel = false;
            PausePanel.SetActive(false);

        }
    }
   

    public void GoBackGame()
    {
        pausePanel = false;
        PausePanel.SetActive(false);
    }
}
