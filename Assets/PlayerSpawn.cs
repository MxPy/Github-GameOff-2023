using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    public Transform Spawnpoint;
    public GameObject playerPrefab;
    void Start()
    {
        SprawnPlayer();
    }

    void SprawnPlayer(){
        GameObject player = Instantiate(playerPrefab, Spawnpoint.position, Spawnpoint.rotation);
    }

}
