﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClickSound : MonoBehaviour
{
    public AudioSource source;
    public AudioClip click;

    public void OnClick()
    {
        source.PlayOneShot(click);
        
    }
    
}
