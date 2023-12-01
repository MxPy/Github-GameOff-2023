using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroSkip : MonoBehaviour
{
    public string sceneToLoad;
    public float waitTime = 1;
    [SerializeField] private GameObject intro;
    [SerializeField] private GameObject ifSkip;
    void Start(){
        intro.SetActive(false);
        ifSkip.SetActive(true);
    }

    public void OnClickYes()
    {
        if(sceneToLoad != null){
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    public void OnClickNo()
    {
        ifSkip.SetActive(false);
        StartCoroutine(Wait(waitTime));
        intro.SetActive(true);
        gameObject.SetActive(false);
    }

    IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
}
