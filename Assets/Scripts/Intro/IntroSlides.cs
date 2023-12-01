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
    public float slideDuration = 2f; // time for an image
    private int currentIndex = 0;

    // for text
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public string[] dialogue;
    private int index;
    private bool waitForInput;
    private bool stopTyping;
    private bool isTyping;
    public float wordSpeed;

    void Start()
    {
        zeroText();
        this.isTyping = false;
        if (image == null)
        {
            Debug.LogError("Image not found");
            return;
        }

        //start intro
        StartCoroutine(StartSlideshow());
        if(!this.isTyping){
            stopTyping = false;
            StartCoroutine(Typing());
        }
    }

    void Update()
    {
        if (dialogueText.text == dialogue[index])
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                if (waitForInput)
                {
                    NextLine();
                    waitForInput = false;
                }
            }
        }
    }


    // images methods
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

    // text methods

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        stopTyping = true;
    }

    IEnumerator Typing()
    {
        isTyping = true;
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        waitForInput = true;
        isTyping = false;
    }

    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            if(stopTyping == false){
            StartCoroutine(Typing());
            }
        }
        else
        {
            zeroText();
        }
    }

}
