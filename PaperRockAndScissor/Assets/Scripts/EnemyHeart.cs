using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeart : TowerManager
{
    public Animator anim;
    private void Start() {
        anim.SetBool("Attaked",Attaked);
    }
private int EnemyHeartTower = 15;
void OnTriggerEnter(Collider other)
      {
    
        if(other.tag == "Ally"){
         DOTower(EnemyHeartTower);
         Debug.Log("count:");
        }

       
      }
    void Update()
    {
        
    }
}
