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
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public string[] dialogue;
    private int indexText;
    private bool stopTyping;
    private bool isTyping = false;
    public float wordSpeed;

    void Start()
    {
        indexText = 0;
        zeroText();
        if (image == null)
        {
            Debug.LogError("Image not found");
            return;
        }

        //start intro
        NextImage();
        if(!this.isTyping){
            stopTyping = false;
            StartCoroutine(Typing());
        }
    }

    void Update()
    {
        if (!isTyping && dialogueText.text == dialogue[indexText])
        {
            StartCoroutine(Wait(waitDuration));
        }
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        NextLine();
    }

    // images methods
    private void NextImage()
    {
        image.sprite = imageArray[indexImage];
        indexImage++;
    }

    // text methods

    public void zeroText()
    {
        dialogueText.text = "";
        indexText = 0;
        stopTyping = true;
    }

    IEnumerator Typing()
    {
        isTyping = true;
        foreach (char letter in dialogue[indexText].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        isTyping = false;
    }

    public void NextLine()
    {
        if (indexText < dialogue.Length - 1)
        {
            indexText++;
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
