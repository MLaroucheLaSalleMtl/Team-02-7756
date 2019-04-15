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





    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
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
