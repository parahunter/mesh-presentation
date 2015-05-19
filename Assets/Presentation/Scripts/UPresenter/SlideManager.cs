using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlideManager : MonoBehaviour 
{
    public KeyCode forwardKey = KeyCode.RightArrow;
    public KeyCode backKey = KeyCode.LeftArrow;

    public SlideCollection slideCollection;
    
    void Start()
    {
        if(slideCollection != null)
            slideCollection.ShowFirst();
    }

    void Update()
    {
        if(Input.GetKeyDown(forwardKey))
        {
            if (slideCollection != null)
            {
                if (!slideCollection.NextSlide())
                    Application.LoadLevel(Application.loadedLevel + 1);
            }
            else
                Application.LoadLevel(Application.loadedLevel + 1);

        }
        else if(Input.GetKeyDown(backKey))
        {
            if (slideCollection != null)
            {
                if (!slideCollection.LastSlide())
                    Application.LoadLevel(Application.loadedLevel - 1);
            }
            else
                Application.LoadLevel(Application.loadedLevel - 1);

        }
    }
}
