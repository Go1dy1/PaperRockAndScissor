using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class EnemyScissors : EnemyCard
{
private void Awake()
{

    HealPoint= 6; 
    ENDamage = 4;
    ModifyDamage= 2f;

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
