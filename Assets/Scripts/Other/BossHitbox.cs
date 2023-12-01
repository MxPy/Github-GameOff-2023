using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHitbox : MonoBehaviour
{
    public Boss boss;


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.name.Contains("bullet")){
            boss.HP--;
            Destroy(other.gameObject);
        }
    }
}
