using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class Scissors : Card
{
private void Awake() {
    HealPoint= 6;
    Damage = 4;
    speed=4.5f; 
    ModifyDamage= 2f;
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

