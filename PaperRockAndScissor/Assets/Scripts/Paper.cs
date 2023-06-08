using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;
public class Paper : Card
{

private void Awake() {
     HealPoint= 8; Damage = 3;speed=3.5f; ModifyDamage= 2.4f;
}
private IEnumerator Start()
{
    yield return new WaitForEndOfFrame();
    Tower= CastlePosition.enemy.enemyPos;  
    agent= GetComponent<NavMeshAgent>(); 
}
void Update()
    {
        
       TempMethod(agent,Tower);


    }   

}
