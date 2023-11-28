using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOnColissions : MonoBehaviour
{
    public BoxCollider2D boxCollider2D;
    public MusicLoader musicLoader;

    // Update is called once per frame
    void Update()
    {
        if(musicLoader.musicStarted && !boxCollider2D.enabled){
            boxCollider2D.enabled = true;
        }
    }
}
