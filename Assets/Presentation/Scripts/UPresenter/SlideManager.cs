using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlideManager : MonoBehaviour 
{
    public KeyCode forwardKey;
    public KeyCode backKey;

    public SlideCollection slideCollection;
    
    void Start()
    {
        slideCollection.ShowFirst();
    }

    void Update()
    {
        if(Input.GetKeyDown(forwardKey))
        {
            slideCollection.NextSlide();
        }
        else if(Input.GetKeyDown(backKey))
        {
            slideCollection.LastSlide();
        }

    }


}
