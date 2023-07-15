using System.Collections;
using UnityEngine;
using UnityEngine.AI;
public class Stone : Card
{
private void Awake()
{
    HealPoint= 10;
    Damage = 3;
    speed=2;
    ModifyDamage= 3f;  
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
