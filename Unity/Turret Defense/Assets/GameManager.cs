using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject GameOverMenu;
    private bool isGameOver = false;
    private GameObject WinPanel;
    private bool isWin = false;





    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void GameOver()
    {
        isGameOver = true;
        GameOverMenu.SetActive(true);
        if (isGameOver)
        {
            FindObjectOfType<AudioManager>().Play("LoseMusic");
        }
    }

    public void winGame()
    {
        isWin = true;
        WinPanel.SetActive(true);
        if (isWin)
        {
            FindObjectOfType<AudioManager>().Play("WinMusic");
        }
    }
}
