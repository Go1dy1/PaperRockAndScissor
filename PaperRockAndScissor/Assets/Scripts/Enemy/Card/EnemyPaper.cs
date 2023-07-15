using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class EnemyPaper : EnemyCard
{
private void Awake() 
{

    HealPoint= 8; 
    ENDamage = 3; 
    ModifyDamage= 2.5f;

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
