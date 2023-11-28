using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlatform : MonoBehaviour
{
    public float speed = 1.5f;

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position -= new Vector3(speed*Time.deltaTime, 0, 0);
    }
}
