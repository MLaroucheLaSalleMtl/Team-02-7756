using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class LevelLoader : MonoBehaviour
{
    public GameObject LoadingScreen;
    //public Slider slider;
    //public Text progressText;

    private AsyncOperation async;
    [SerializeField] private Image progressbar;
    [SerializeField] private Text txtPercent;
    [SerializeField] private bool waitForUserInput = false;
    [SerializeField] private float delay = 2f;
    [SerializeField] private int sceneToLoad = -1;
    private bool ready = false;

    public void LoadLevel(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        Input.ResetInputAxes();
        System.GC.Collect();//collect the garbage
        Scene currScene = SceneManager.GetActiveScene();
        //async.allowSceneActivation = false;
        if (!waitForUserInput)//or (waitForUserInput == false)
        {
            Invoke("Active", delay);//waitting for response
        }
    }

    public void Active()
    {
        ready = true;
    }

    //Slider Loading bar
    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        async = SceneManager.LoadSceneAsync(sceneIndex);

        LoadingScreen.SetActive(true);

       
        while (!async.isDone)
        {
            float progress = Mathf.Clamp01(async.progress / 0.9f);

            progressbar.fillAmount = progress;

            txtPercent.text = ((async.progress + 0.1f) * 100).ToString("F2") + " %";

            yield return null;
        }
        

        //if (waitForUserInput && Input.anyKey)
        //{
        //    if (async.progress >= 0.89f && SplashScreen.isFinished)
        //    {
        //        ready = true;
        //    }
        //}
        //if (progressbar)
        //{
        //    progressbar.fillAmount = async.progress + 0.1f;
        //}
        //if (txtPercent)
        //{
        //    txtPercent.text = ((async.progress + 0.1f) * 100).ToString("F2") + " %";
        //}

        //if (async.progress >= 0.89f && SplashScreen.isFinished && ready)
        //{
        //    async.allowSceneActivation = true;
        //}
        //yield return null;

        // while (!operation.isDone)
        //{
        //    float progress = Mathf.Clamp01(operation.progress / 0.9f);

        //    slider.value = progress;

        //    progressText.text = progress * 100f + " % ";
        //    yield return null;
        //}
    }
}
