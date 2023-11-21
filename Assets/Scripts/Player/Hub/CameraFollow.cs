using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float followSpeed = 2f;
    public Transform target;

    // offset is not set for now
    public float offsetY = 1f;
    public float offsetX = 1f;

    void Update()
    {
        Vector3 changedPosition = new Vector3(target.position.x, target.position.y, -10f);
        transform.position = Vector3.Slerp(transform.position, changedPosition, followSpeed * Time.deltaTime);

    }
}
