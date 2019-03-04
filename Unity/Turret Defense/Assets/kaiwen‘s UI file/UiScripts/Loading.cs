using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;//for UI
using UnityEngine.SceneManagement;//for scenes transition
using UnityEngine.Rendering;//for the splashscreen.

public class Loading : MonoBehaviour
{

    private AsyncOperation async;
    [SerializeField] private Image progressbar;
    [SerializeField] private Text txtPercent;
    [SerializeField] private bool waitForUserInput = false;
    [SerializeField] private float delay = 0;
    [SerializeField] private int sceneToLoad = -1;
    private bool ready = false;


    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1f;
        Input.ResetInputAxes();
        System.GC.Collect();//collect the garbage
        Scene currScene = SceneManager.GetActiveScene();
        if (sceneToLoad == -1)
        {
            async = SceneManager.LoadSceneAsync("Level 1");
        }
        else
        {
            async = SceneManager.LoadSceneAsync(sceneToLoad);
        }
        async.allowSceneActivation = false;
        if (!waitForUserInput)//or (waitForUserInput == false)
        {
            Invoke("Active", delay);//waitting for response
        }
    }

    public void Active()
    {
        ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForUserInput && Input.anyKey)
        {
            if (async.progress >= 0.89f && SplashScreen.isFinished)
            {
                ready = true;
            }
        }
        if (progressbar)
        {
            progressbar.fillAmount = async.progress + 0.1f;
        }
        if (txtPercent)
        {
            txtPercent.text = ((async.progress + 0.1f) * 100).ToString("F2") + " %";
        }

        if (async.progress >= 0.89f && SplashScreen.isFinished && ready)
        {
            async.allowSceneActivation = true;
        }
    }
}

