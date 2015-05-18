using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UGUISlide : Slide 
{
    
    public override void Deactivate()
    {
        gameObject.SetActive(false);
    }

    public override void Activate()
    {
        gameObject.SetActive(true);
    }
}
