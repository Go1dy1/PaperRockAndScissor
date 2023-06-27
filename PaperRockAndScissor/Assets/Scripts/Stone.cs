using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;
public class Stone : Card
{
private void Awake() {
    HealPoint= 10; Damage = 3;speed=2; ModifyDamage= 2f;
    
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
