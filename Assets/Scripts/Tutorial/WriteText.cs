using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class WriteText : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TMP_Text dialogueText;
    public string[] dialogue;
    private int index;
    private bool waitForInput;
    private bool stopTyping;
    private bool isTyping;
    
    public float wordSpeed;

    void Start(){
        zeroText();
        isTyping = false;
        waitForInput = true;
        stopTyping = true;
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)){
            if (!isTyping){
                stopTyping = false;
				if(stopTyping == false){
					StartCoroutine(Typing());
				}
            }
        }

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
