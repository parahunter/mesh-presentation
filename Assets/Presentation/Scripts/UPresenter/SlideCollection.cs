using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlideCollection : MonoBehaviour 
{
    public List<Slide> slides;
    int slideIndex = 0;
    Slide lastSlide;

    void Awake()
    {
                
        for(int i = 0 ; i < slides.Count ; i++)
        {
            slides[i].Deactivate();
        }
    }

    public void ShowFirst()
    {
        slideIndex = 0;
        lastSlide = slides[slideIndex];
        lastSlide.Activate();
    }

    public bool NextSlide()
    {
        if(slideIndex + 1 <= slides.Count - 1)
        {
            lastSlide.Deactivate();
            slideIndex++;

            lastSlide = slides[slideIndex];
            lastSlide.Activate();

            return true;
        }

        return false;
    }

    public bool LastSlide()
    {
        if (slideIndex - 1 >= 0)
        {
            lastSlide.Deactivate();
            slideIndex--;

            lastSlide = slides[slideIndex];
            lastSlide.Activate();

            return true;
        }

        return false;
    }

}
