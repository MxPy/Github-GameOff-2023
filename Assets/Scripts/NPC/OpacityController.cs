using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpacityController : MonoBehaviour
{
    public Image image;
    public float increaseRate = 0.1f;
    public float targetOpacity = 1.0f;
    private void OnEnable(){
        if(image == null){
            Debug.LogError("Sprite missing");
            return;
        }

        StartCoroutine(IncreaseOpacity());
    }

    private IEnumerator IncreaseOpacity(){
        Color initialColor = image.color;
        initialColor.a = 0.0f;
        image.color = initialColor;

        while(image.color.a < targetOpacity){
            Color currentCOlor = image.color;
            currentCOlor.a += increaseRate * Time.deltaTime;
            image.color = currentCOlor;
            yield return null;
        }

        Color finalColor = image.color;
        finalColor.a = targetOpacity;
        image.color = finalColor;

    }
}
