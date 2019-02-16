using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserGUI : MonoBehaviour
{
    [SerializeField] private Text lifeText;
    private BaseLifeDescrease baseLifeDecreaseRef;
    

    // Start is called before the first frame update
    void Start()
    {
        baseLifeDecreaseRef = FindObjectOfType<BaseLifeDescrease>();
        
        lifeText.text = "Lifes: " + baseLifeDecreaseRef.baseLife.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
        lifeText.text = "Lifes: " + baseLifeDecreaseRef.baseLife.ToString();
    }
}
