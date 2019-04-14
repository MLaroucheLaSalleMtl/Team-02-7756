using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PanelBehaviors : MonoBehaviour//, //IPointerEnterHandler
{
    public GameObject statusPanel;

    public Text targetText;
    public Text priceText;
    public Image target;
    public Text price;
    

    //public void OpenStatusPanel()
    //{
    //    if (displayInfo)
    //    {
            

    //        Animator anim = statusPanel.GetComponent<Animator>();
    //        if (anim != null)
    //        {
    //            bool isOpen = anim.GetBool("OpenWeaponUIStatus");

    //            anim.SetBool("OpenWeaponUIStatus", !isOpen);

    //        }
    //    }
    //}

    public void OnMouseOver()
    { 
        statusPanel.SetActive(true);
        targetText.text = "Favor Target :";
        priceText.text = "Price :";  

        
    }
    public void OnMouseExit()
    {
        statusPanel.SetActive(false);
    }










    // Start is called before the first frame update
    void Start()
    {
        statusPanel.SetActive(false);
    }

  
    
}
