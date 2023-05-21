using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyPaper : EnemyCard
{
private void Awake() {
    HealPoint= 8; ENDamage = 3; Speed=3.5f; ModifyDamage= 2.4f;
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
