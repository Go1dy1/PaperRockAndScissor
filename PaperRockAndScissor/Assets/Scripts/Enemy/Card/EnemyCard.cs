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
public ParticleSystem Puff;
public AudioSource Death;
public float HealPoint ;
public float ENDamage ;
public float ModifyDamage;
public Transform Tower;
public float Speed;

[SerializeField] internal NavMeshAgent agent;
 private void Awake(){ 
    agent = GetComponent<NavMeshAgent>();
    ENcurrentState= StateUnit.WalkToCastle;

    
}
void Update() {

 if(HealPoint<=0f){
   
    CharacterManager.enemyList.Remove(gameObject);
    Destroy(gameObject);
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
            Instantiate(Puff,gameObject.transform.position,Quaternion.identity);
            Instantiate(Death,gameObject.transform.position,Quaternion.identity);
            CharacterManager.enemyList.Remove(enemyCard.gameObject);
            Destroy(enemyCard.gameObject);
        }
        if(other.tag=="Ally" && AllyCard.typeOfCard == CardType.Stone && enemyCard.ENtypeOfCard== CardType.Scissors){ 
        HealPoint= ModAttack(AllyCard.Damage,HealPoint,AllyCard.ModifyDamage);
        ComeBack();
        }
        else if(other.tag=="Ally" && AllyCard.typeOfCard == CardType.Stone){
        HealPoint= Attack(AllyCard.Damage,HealPoint); 
        ComeBack();
        }

        if(other.tag=="Ally" && AllyCard.typeOfCard == CardType.Paper && enemyCard.ENtypeOfCard== CardType.Stone){
        HealPoint= ModAttack(AllyCard.Damage,HealPoint,AllyCard.ModifyDamage);
        ComeBack();
        }
        else if(other.tag=="Ally" && AllyCard.typeOfCard == CardType.Paper){
        HealPoint= Attack(AllyCard.Damage,HealPoint);
        ComeBack();
        }
        
        if(other.tag=="Ally" && AllyCard.typeOfCard == CardType.Scissors && enemyCard.ENtypeOfCard== CardType.Paper){
        HealPoint= ModAttack(AllyCard.Damage,HealPoint,AllyCard.ModifyDamage);
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
   if(gameObject!=null)transform.DOMove(Pos.position,0.2f,false);
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
