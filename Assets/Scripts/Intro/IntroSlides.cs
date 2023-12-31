using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class IntroSlides : MonoBehaviour
{
    public string sceneToLoad;

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
        while(indexImage < imageArray.Length - 1){
            while(indexText < textLineArray.Length){
                yield return StartCoroutine(Wait(1f));
                yield return StartCoroutine(Typing());
                yield return StartCoroutine(Wait(waitDuration));
                NextImage();
                NextLine();
            }     
            NextImage();
            yield return StartCoroutine(Wait(waitDuration));
        }
        NextImage();
        yield return StartCoroutine(Wait(2f));
        LoadScene();
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
        indexText++;
        textLine.text = "";
    }

    public void LoadScene(){
        if(sceneToLoad != null){
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
