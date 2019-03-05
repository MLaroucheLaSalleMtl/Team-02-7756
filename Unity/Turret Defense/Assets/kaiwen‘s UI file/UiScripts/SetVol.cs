using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class SetVol : MonoBehaviour
{
  
    [SerializeField] AudioMixer audioM;
    [SerializeField] string nameParam;

    public void SetVolume(float vol)
    {
        Slider slide = GetComponent<Slider>();
        audioM.SetFloat(nameParam, vol);
        slide.value = vol;
       
        PlayerPrefs.SetFloat(nameParam, vol);
        PlayerPrefs.Save();
    }
    // Use this for initialization
    void Start()
    {
        Slider slide = GetComponent<Slider>();
        float Volum = PlayerPrefs.GetFloat(nameParam, 0);
        slide.value = Volum;
    }

    // Update is called once per frame
    void Update()
    {

    }
}