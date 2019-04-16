using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject GameOverMenu;
    [SerializeField] private bool isGameOver = false;
    [SerializeField] private GameObject WinPanel;
    [SerializeField] private bool isWin = false;
    private PowerUp_DeleteAll button;

    public TurretBehaviour[] turrets;
    //public bool isJiaSu = false;
    //public bool IsPowerUp = false;
    //public void JiaSu()
    //{
    //    isJiaSu = true;
    // //   turrret.PowerTimer = 5f;
    //}
    public GameObject targetTurret = null;

    public void resetUI()
    {
        GameObject[] turrets = GameObject.FindGameObjectsWithTag("Turret");
       for(int i = 0; i < turrets.Length; i++)
        {
            turrets[i].GetComponent<TurretBehaviour>().UIUpgrade.SetActive(false);
            turrets[i].GetComponent<TurretBehaviour>().weapeonRange.SetActive(false);
        }
    }
   

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        turrets = FindObjectsOfType<TurretBehaviour>();
      // 
    }

    // Update is called once per frame
    void Update()
    {
      
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit Hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out Hit, 100.0f))
            {

             
                if (Hit.collider.tag=="Turret")
                {
                    targetTurret = Hit.transform.gameObject;
                    targetTurret.GetComponent<TurretBehaviour>().UIUpgrade.SetActive(true);
                    targetTurret.GetComponent<TurretBehaviour>().weapeonRange.SetActive(true);
                   


                }
                if( Hit.collider.tag!="Turret")
                {
                    //    UiActive = false;
                    resetUI();
                }
                //if (Hit.collider.tag != "Turret")
                //{
                //  //  targetTurret = Hit.transform.gameObject;
                   

                //}
            }
        }

    }



    public void GameOver()
    {
        isGameOver = true;
       
        if (isGameOver)
        {
            GameOverMenu.SetActive(true);
            //FindObjectOfType<AudioManager>().Play("LoseMusic");
            Time.timeScale = 0f;
            button.ButtonDelet.SetActive(false);
        }
    }

    public void winGame()
    {
        isWin = true;
        
        if (isWin)
        {
            WinPanel.SetActive(true);
            //FindObjectOfType<AudioManager>().Play("WinMusic");
            Time.timeScale = 0f;
            button.ButtonDelet.SetActive(false);

        }
    }
}
