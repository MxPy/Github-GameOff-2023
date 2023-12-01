using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroSlides : MonoBehaviour
{
    public Sprite[] imageArray;
    public Image image;
    public float slideDuration = 2f; // time for an image

    private int currentIndex = 0;

    void Start()
    {
        if (image == null)
        {
            Debug.LogError("err");
            return;
        }

        //start intro
        StartCoroutine(StartSlideshow());
    }

    IEnumerator StartSlideshow()
    {
        while (currentIndex < imageArray.Length)
        {
            image.sprite = imageArray[currentIndex];
            yield return new WaitForSeconds(slideDuration);
            currentIndex++;
        }

        // something 
    }

}
