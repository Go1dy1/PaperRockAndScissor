using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;
public class Scissors : Card
{
private int HealPoint= 8;
private int Damage = 3;
private int Price= 3;
public float speed;
private float ModifyDamage= 2;

private IEnumerator  Start(){
   yield return new WaitForEndOfFrame();
    Tower= CastlePosition.enemy.enemyPos;  
    agent= GetComponent<NavMeshAgent>(); 

}
   void Update()
    {
       TempMethod(agent,Tower);

      /* if(direction== true)
        {
            agent.SetDestination(Tower.position);
        }
*/
    }

    
}
