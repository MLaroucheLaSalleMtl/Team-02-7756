using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectMenu : MonoBehaviour {

    [SerializeField] private GameObject[] panels;
    [SerializeField] private Selectable[] defaultOptions;
    
    public void PanelToggle(int position)
    {
        Input.ResetInputAxes();
        for(int i =0; i < panels.Length; i++)
        {
            panels[i].SetActive(position == i);
            if (position == i)
            {
                defaultOptions[i].Select();
            }
        }
    }
                                                        

	// Use this for initialization
	void Start ()
    {
        PanelToggle(0);


    }

    // Update is called once per frame
    void Update () {
		
	}
}
