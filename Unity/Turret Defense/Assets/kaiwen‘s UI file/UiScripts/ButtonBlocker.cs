using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonBlocker : MonoBehaviour
{
    [SerializeField] private Button[] levelButtons;

   

    //public int[] levelToUnlock;


    // Start is called before the first frame update
    void Start()
    {

        int levelReached = PlayerPrefs.GetInt("levelPassed", 1);
        Debug.Log("LevelPassed" + levelReached);

        for (int i = 0; i < levelButtons.Length; i++)
        {
            levelButtons[i].interactable = (i + 1 > levelReached) ? false : true;
            //levelToUnlock++;
            //if (i+1 > levelReached)
            //{
            //    levelButtons[i].interactable = false;
            //}
        }
       

    }

    public void ResetLevelButtons()
    {
        levelButtons[0].interactable = true;
        levelButtons[1].interactable = false;
        levelButtons[2].interactable = false;
        levelButtons[3].interactable = false;
        levelButtons[4].interactable = false;
        levelButtons[5].interactable = false;
        levelButtons[6].interactable = false;
        levelButtons[7].interactable = false;
        levelButtons[8].interactable = false;
        levelButtons[9].interactable = false;
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

    public void OpenLevelButtons()
    {
        levelButtons[0].interactable = true;
        levelButtons[1].interactable = true;
        levelButtons[2].interactable = true;
        levelButtons[3].interactable = true;
        levelButtons[4].interactable = true;
        levelButtons[5].interactable = true;
        levelButtons[6].interactable = true;
        levelButtons[7].interactable = true;
        levelButtons[8].interactable = true;
        levelButtons[9].interactable = true;
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
