using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class EnemyCard : MonoBehaviour
{
[SerializeField] internal CardType ENtypeOfCard ;
[SerializeField] internal StateUnit ENcurrentState;
[SerializeField] Transform Pos;
[SerializeField] Collider Enemy;
[SerializeField ]float AttackDistance;
public float HealPoint ;
public float ENDamage ;
public float speed;
public float ModifyDamage;
public Transform AllyPerson;
public Transform Tower;
public NavMeshAgent agent;
public Rigidbody rb;

  void Awake(){    
ENcurrentState= StateUnit.WalkToCastle;
}
private void Update() {
 if(ENcurrentState == StateUnit.WalkToCastle){
    agent.SetDestination(Tower.position);   
}   
}
private void OnTriggerEnter(Collider other) {
    EnemyCard enemyCard= gameObject.GetComponent<EnemyCard>();
    Card AllyCard= other.gameObject.GetComponent<Card>();

  if(enemyCard.HealPoint<=0){
            AllyCard._currentState = StateUnit.WalkToCastle;
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
