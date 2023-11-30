using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSomeScene : MonoBehaviour
{
    public string sceneToLoad;
    public void LoadScene(){
        if(sceneToLoad != null){
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
