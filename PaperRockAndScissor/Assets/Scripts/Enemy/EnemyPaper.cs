using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyPaper : EnemyCard
{
private void Awake() {
    HealPoint= 10; ENDamage = 3; ModifyDamage= 2;
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
