using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossHitbox : MonoBehaviour
{
    public Boss boss;
    
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other.name);
        if(other.name.Contains("bullet")){
            boss.HP--;
            boss.StartAnimation();
            Destroy(other.gameObject);
        }
    }

    


}
