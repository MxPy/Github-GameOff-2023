using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour
{
    public string sceneToLoad;
    public GameObject hoverImage;
    
    public void LoadScene(){
        SceneManager.LoadScene(sceneToLoad);
    }

    public void ExitGame(){
        Application.Quit();
    }
}
