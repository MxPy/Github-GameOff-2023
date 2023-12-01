using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBulletRight : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += new Vector3(5+Time.deltaTime, 0, 0);
    }
}
