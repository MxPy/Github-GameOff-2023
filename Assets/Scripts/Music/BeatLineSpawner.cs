using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class BeatLineSpawner : MonoBehaviour
{
    public MusicLoader musicLoader;
    public GameObject topNote, middleNote, bottomNote;
    public GameObject topLineTarget, middleLineTarget, bottomLineTarget;
    public float SpawnPosX;

    private float topSpawnPosY, middleSpawnPosY, bottomSpawnPosY;
    private VariableTimer timer;
    private float secPerBeat;
    public Stack<int> notesToSpawn, notesToSpawnCopy;

    void Start(){
        Setup();
        GenerateSpawnerArray();
        timer.StartTimer(secPerBeat*2);
    }

    private void Update() {
        if(timer.finished){
            SpawnNote(notesToSpawn.Pop());
            timer.ResetTimer();
            timer.StartTimer(secPerBeat);
        }
    }
    //TODO add commentts to Spawn fun and refractor this shit
    void SpawnNote(int choice){
        GameObject note;
        switch (choice){
            case 0:
                return;
            case 1:
                note = Instantiate (topNote, new UnityEngine.Vector3(SpawnPosX, topSpawnPosY, 0), UnityEngine.Quaternion.Euler(0, 0, 0));
                note.GetComponent<MoveWithBeat>().targetNum = 0;
                break;
            case 2:
                note = Instantiate (middleNote, new UnityEngine.Vector3(SpawnPosX, middleSpawnPosY, 0), UnityEngine.Quaternion.Euler(0, 0, 0));
                note.GetComponent<MoveWithBeat>().targetNum = 1;
                break;
            case 3:
                note = Instantiate (bottomNote, new UnityEngine.Vector3(SpawnPosX, bottomSpawnPosY, 0), UnityEngine.Quaternion.Euler(0, 0, 0));
                note.GetComponent<MoveWithBeat>().targetNum = 2;
                break;
            case 4:
                note = Instantiate (topNote, new UnityEngine.Vector3(SpawnPosX, topSpawnPosY, 0), UnityEngine.Quaternion.Euler(0, 0, 0));
                note.GetComponent<MoveWithBeat>().targetNum = 0;
                note = Instantiate (middleNote, new UnityEngine.Vector3(SpawnPosX, middleSpawnPosY, 0), UnityEngine.Quaternion.Euler(0, 0, 0));
                note.GetComponent<MoveWithBeat>().targetNum = 1;
                break;
            case 5:
                note = Instantiate (topNote, new UnityEngine.Vector3(SpawnPosX, topSpawnPosY, 0), UnityEngine.Quaternion.Euler(0, 0, 0));
                note.GetComponent<MoveWithBeat>().targetNum = 0;
                note = Instantiate (bottomNote, new UnityEngine.Vector3(SpawnPosX, bottomSpawnPosY, 0), UnityEngine.Quaternion.Euler(0, 0, 0));
                note.GetComponent<MoveWithBeat>().targetNum = 2;
                break;
            case 6:
                note = Instantiate (middleNote, new UnityEngine.Vector3(SpawnPosX, middleSpawnPosY, 0), UnityEngine.Quaternion.Euler(0, 0, 0));
                note.GetComponent<MoveWithBeat>().targetNum = 1;
                note = Instantiate (bottomNote, new UnityEngine.Vector3(SpawnPosX, bottomSpawnPosY, 0), UnityEngine.Quaternion.Euler(0, 0, 0));
                note.GetComponent<MoveWithBeat>().targetNum = 2;
                break;
            case 7:
                note = Instantiate (topNote, new UnityEngine.Vector3(SpawnPosX, topSpawnPosY, 0), UnityEngine.Quaternion.Euler(0, 0, 0));
                note.GetComponent<MoveWithBeat>().targetNum = 0;
                note = Instantiate (middleNote, new UnityEngine.Vector3(SpawnPosX, middleSpawnPosY, 0), UnityEngine.Quaternion.Euler(0, 0, 0));
                note.GetComponent<MoveWithBeat>().targetNum = 1;
                note = Instantiate (bottomNote, new UnityEngine.Vector3(SpawnPosX, bottomSpawnPosY, 0), UnityEngine.Quaternion.Euler(0, 0, 0));
                note.GetComponent<MoveWithBeat>().targetNum = 2;
                break;
        }
        
    }

    void Setup(){
        timer = gameObject.AddComponent(typeof(VariableTimer)) as VariableTimer;
        topSpawnPosY = topLineTarget.transform.position.y;
        middleSpawnPosY = middleLineTarget.transform.position.y;
        bottomSpawnPosY = bottomLineTarget.transform.position.y;
        secPerBeat = musicLoader.secPerBeat;
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
        notesToSpawnCopy = new Stack<int>(new Stack<int>(notesToSpawn));
    }

}
