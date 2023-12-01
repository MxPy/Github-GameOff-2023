using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class IntroSlides : MonoBehaviour
{
    // for images
    public Sprite[] imageArray;
    public Image image;
    public float waitDuration = 2f; // time to wait for after text is written
    private int indexImage = 0;

    // for text
    public GameObject textPanel;
    public TMP_Text textLine;
    public string[] textLineArray;
    private int indexText;
    private bool isTyping = false;
    public float wordSpeed;

    void Start()
    {
        zeroText();
        if (image == null)
        {
            Debug.LogError("Image not found");
            return;
        }

        //start intro
        NextImage();
        StartCoroutine(StartTyping());
    }

    void Update()
    {

    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

    // images methods
    private void NextImage()
    {
        image.sprite = imageArray[indexImage];
        indexImage++;
    }

    // text methods

    private IEnumerator StartTyping()
    {
        while(indexText < textLineArray.Length){
            isTyping = true;
            yield return StartCoroutine(Typing());
            isTyping = false;

            yield return StartCoroutine(Wait(waitDuration));
            NextImage();
            NextLine();
        }
    }

    public void zeroText()
    {
        textLine.text = "";
        indexText = 0;
    }

    IEnumerator Typing()
    {
        foreach (char letter in textLineArray[indexText].ToCharArray())
        {
            textLine.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        if (indexText < textLineArray.Length - 1)
        {
            indexText++;
            textLine.text = "";
        }
    }
}
