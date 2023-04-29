using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;
public class Paper : Card
{
private IEnumerator  Start(){
    yield return new WaitForEndOfFrame();
    Tower= CastlePosition.enemy.enemyPos;  
    agent= GetComponent<NavMeshAgent>();  

}
private void Awake() {
     HealPoint= 8; Damage = 3;speed=2; ModifyDamage= 2;
    if(gameObject.tag=="Ally"){
        
    }
}
    void Update()
    {
       TempMethod(agent,Tower);

      /* if(direction== true)
        {
            agent.SetDestination(CastlePosition.enemy.enemyPos.position);
        }
    */
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag== "Enemy"&& GameObject.Find("Scissors")){
                Debug.Log("dasd");
                Destroy(gameObject);
            
        }

    }
    
}
