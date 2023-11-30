using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionsFunctions : MonoBehaviour
{
    public AudioMixer mixer;
    public GameObject container;
    public GameObject optionsContainer;

    void Update(){
        if (!container.activeSelf && Input.GetKeyDown(KeyCode.Escape)){
            optionsContainer.SetActive(false);
            container.SetActive(true);
        }
    }

    public void ChangeVolume(float volume){
        mixer.SetFloat("Volume", volume);
    }

    public void ShowOptions(){
        if (container != null && optionsContainer != null){
            container.SetActive(false);
            optionsContainer.SetActive(true);
        }
    }

    public void HideOptions(){
        if (container != null && optionsContainer != null){
            optionsContainer.SetActive(false);
            container.SetActive(true);
        }
    }
}
