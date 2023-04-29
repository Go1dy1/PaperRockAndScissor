using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;
public class Scissors : Card
{
private IEnumerator  Start(){
   yield return new WaitForEndOfFrame();
    Tower= CastlePosition.enemy.enemyPos;  
    agent= GetComponent<NavMeshAgent>(); 

}
private void Awake() {
     HealPoint= 8; Damage = 3;speed=2; ModifyDamage= 2;
}
   void Update()
    {
       TempMethod(agent,Tower);
    }
 void OnTriggerEnter(Collider other)
    {
        if(other.tag== "Enemy"&& GameObject.Find("Stone")){
            Debug.Log("SAS");
                Destroy(gameObject);
            
        }
        
    }
    
}
