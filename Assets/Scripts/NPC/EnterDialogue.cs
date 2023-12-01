using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class EnterDialogue : MonoBehaviour
{
    public GameObject pressText;
    public bool show = true;
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public string[] dialogue;
    private int index;
    private bool waitForInput;
    private bool stopTyping;
    private bool isTyping;
    private int indexCounter = 0;

    public string sceneToLoad;

    public GameObject continueButton;
    
    public float wordSpeed;
    public bool playerIsClose;

    void Start(){
        zeroText();
        isTyping = false;
        waitForInput = true;
        playerIsClose = false;
        stopTyping = true;
        
    }

    void Update()
    {
        if (playerIsClose && show)
        {
            pressText.SetActive(true);
        }
        else
        {
            pressText.SetActive(false);
        }

        if (playerIsClose && Input.GetKeyDown(KeyCode.E))
        {
            if (!isTyping)
            {
                show = false;
                pressText.SetActive(false);
                stopTyping = false;

                if (dialoguePanel.activeInHierarchy)
                {
                    zeroText();
                }
                else
                {
                    dialoguePanel.SetActive(true);
                    if(stopTyping == false){
                        StartCoroutine(Typing());
                    }
                }
            }
        }

        if (dialogueText.text == dialogue[index])
        {
            continueButton.SetActive(true);
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

    private void loadTutorial(){
        StartCoroutine(Wait());
        if(sceneToLoad != null){
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    public void zeroText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        stopTyping = true;
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(80);
    }

    IEnumerator Typing()
    {
        isTyping = true;
        foreach (char letter in dialogue[index].ToCharArray())
        {
            if(playerIsClose == false){
                zeroText();
                break;
            }
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
        waitForInput = true;
        isTyping = false;
        indexCounter++;
        if(indexCounter == 4){
            loadTutorial();
        }
    }

    public void NextLine()
    {
        continueButton.SetActive(false);
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
            show = true;
            zeroText();
            stopTyping = true;
        }
    }
}
