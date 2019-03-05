using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class SetGfx : MonoBehaviour {

    [SerializeField] Text txtGFX;
    [SerializeField] string nameParam;
    private string[] GFXNames;

    public void SetGFX(float val)
    {
        Slider slide = GetComponent<Slider>();
        int v = (int)Mathf.Floor(val);
        slide.value = val;
        PlayerPrefs.SetFloat(nameParam, val);
        PlayerPrefs.Save();
        QualitySettings.SetQualityLevel(v, true);
        txtGFX.text = GFXNames[v];
    }
	// Use this for initialization
	void Start () {
        GFXNames = QualitySettings.names;
        Slider slide = GetComponent<Slider>();
        float Volum = PlayerPrefs.GetFloat(nameParam, 0);
        slide.value = Volum;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
