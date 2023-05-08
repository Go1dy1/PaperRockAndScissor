using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class EnemyCard : MonoBehaviour
{
[SerializeField] internal CardType ENtypeOfCard ;
[SerializeField] internal StateUnit ENcurrentState;
[SerializeField] internal Transform Pos;
public float HealPoint ;
public float ENDamage ;
public float ModifyDamage;
public Transform Tower;
[SerializeField] internal NavMeshAgent agent;
 private void Awake(){ 

ENcurrentState= StateUnit.WalkToCastle;
}
private void Update() {
 if(ENcurrentState == StateUnit.WalkToCastle){
    agent.SetDestination(Tower.position);   
}   
 if(HealPoint<=0f){
    Destroy(gameObject);
     CharacterManager.enemyList.Remove(gameObject);
 } 
}
internal NavMeshAgent TempMethod(NavMeshAgent agent,Transform Tower){
    if(ENcurrentState == StateUnit.WalkToCastle){
            agent.SetDestination(Tower.position);
        }
         return agent;
}
private void OnTriggerEnter(Collider other) {
    EnemyCard enemyCard= gameObject.GetComponent<EnemyCard>();
    Card AllyCard= other.gameObject.GetComponent<Card>();

  if(enemyCard.HealPoint<=0f){
            Destroy(enemyCard.gameObject);
            CharacterManager.enemyList.Remove(enemyCard.gameObject);
        }
        if(other.tag=="Ally" && AllyCard.typeOfCard == CardType.Stone && enemyCard.ENtypeOfCard== CardType.Scissors){ 
        HealPoint= ModAttack(AllyCard.Damage,HealPoint,ModifyDamage);
        ComeBack();
        }
        else if(other.tag=="Ally" && AllyCard.typeOfCard == CardType.Stone){
        HealPoint= Attack(AllyCard.Damage,HealPoint); 
        ComeBack();
        }

        if(other.tag=="Ally" && AllyCard.typeOfCard == CardType.Paper && enemyCard.ENtypeOfCard== CardType.Stone){
        HealPoint= ModAttack(AllyCard.Damage,HealPoint,ModifyDamage);
        ComeBack();
        }
        else if(other.tag=="Ally" && AllyCard.typeOfCard == CardType.Paper){
        HealPoint= Attack(AllyCard.Damage,HealPoint);
        ComeBack();
        }
        
        if(other.tag=="Ally" && AllyCard.typeOfCard == CardType.Scissors && enemyCard.ENtypeOfCard== CardType.Paper){
        HealPoint= ModAttack(AllyCard.Damage,HealPoint,ModifyDamage);
        ComeBack(); 
        }
        else if(other.tag=="Ally" && AllyCard.typeOfCard == CardType.Scissors){
        HealPoint= Attack(AllyCard.Damage,HealPoint);   
        ComeBack();
        }
 }
public float Attack(float damage, float health){
        health= health- damage;
        return health;
    }
public float ModAttack(float damage, float health, float modifyDamage){
     health= health- (damage*modifyDamage);
        return health;
}
private void ComeBack(){
    transform.DOMove(Pos.position,0.2f,false);
}
public NavMeshAgent FollowAttack(NavMeshAgent agent, Transform AllyPerson){
    agent.SetDestination(AllyPerson.position);
    return agent;
}
NavMeshAgent NullAgent(NavMeshAgent agent){
    agent.isStopped = true;
    return agent;
}

}
