using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyStone : EnemyCard
{

private void Awake() {
   HealPoint= 12; ENDamage = 3; Speed=2; ModifyDamage= 2f;
}
private IEnumerator Start()
{
    yield return new WaitForEndOfFrame();
    Tower= TowerManager.Ally.AllyPos;  
    agent= GetComponent<NavMeshAgent>(); 
}

    void Update()
    {
        TempMethod(agent,Tower);
    }
    
}
