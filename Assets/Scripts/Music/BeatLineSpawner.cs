using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class BeatLineSpawner : MonoBehaviour
{
    public MusicLoader musicLoader;
    public GameObject note;
    public GameObject topLineTarget, middleLineTarget, bottomLineTarget;
    public float SpawnPosX;

    private float topSpawnPosY, middleSpawnPosY, bottomSpawnPosY;
    private VariableTimer timer;
    private Stack<int> notesToSpawn = new Stack<int>();

    void Start(){
        Setup();
        GenerateSpawnerArray();
    }

    void Setup(){
        timer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
        topSpawnPosY = topLineTarget.transform.position.y;
        middleSpawnPosY = middleLineTarget.transform.position.y;
        bottomSpawnPosY = bottomLineTarget.transform.position.y;
        notesToSpawn = new Stack<int>();
    }

    void GenerateSpawnerArray(){
        // 0 - no note - 5%
        // 1 - top note - 20%
        // 2 - mid note - 20%
        // 3 - bot note - 20%
        // 4 - top/mid notes - 10%
        // 5 - top/bot notes - 10%
        // 6 - mid/bot notes - 10%
        // 7 - top/mid/bot notes - 5%

        System.Random random = new();
        for (int i = 0; i < musicLoader.songLenInBeats; ++i)
        {
            int randomNumber = random.Next(1, 101);
            int noteToSpawn = 0;

            noteToSpawn = randomNumber switch{
                int n when n <= 5 => 0,
                int n when n <= 25 => 1,
                int n when n <= 45 => 2,
                int n when n <= 65 => 3,
                int n when n <= 75 => 4,
                int n when n <= 85 => 5,
                int n when n <= 95 => 6,
                _ => 7,
            };
            notesToSpawn.Push(noteToSpawn);
            //Debug.Log(noteToSpawn);
        }
    }

}
