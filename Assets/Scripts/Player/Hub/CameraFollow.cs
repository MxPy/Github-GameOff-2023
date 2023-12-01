using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;
    public float followSpeed = 2f;
    public string targetTag = "Player";

    //public float offsetX = 2f;
    //public float offsetY = 2f;
    public float minYPosition = -20f;
    void Start()
    {

        GameObject targetObject = GameObject.FindGameObjectWithTag(targetTag);

        if (targetObject != null){
            target = targetObject.transform;
        }
        else{
            Debug.LogWarning("No GameObject " + targetTag + " found");
        }
    }

    void Update()
    {
        if (target == null){
            return;
        }

        float targetY = Mathf.Max(target.position.y, minYPosition);

        Vector3 changedPosition = new Vector3(target.position.x, targetY, -10f);
        transform.position = Vector3.Slerp(transform.position, changedPosition, followSpeed * Time.deltaTime);

    }
}
