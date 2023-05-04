using System.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class Card : MonoBehaviour
{
[SerializeField] internal CardType typeOfCard ;
[SerializeField] internal StateUnit _currentState;
[SerializeField] Collider Ally;
[SerializeField] Transform Pos;
public float HealPoint;
public float Damage;
public float speed;
public float ModifyDamage;
private bool isAttacking; 
public bool direction= false;
private int tempAttack ;
public Transform Tower;
public NavMeshAgent agent;

    void Awake(){   
    _currentState = StateUnit.Ide;
}
private void Update(){
        if(Input.GetMouseButton(0)){
            transform.DOMove(GetMousePosition(),1);
        }      
}
public  Vector3 GetMousePosition()
{
    Camera MainCamera= Camera.main;
      Ray ray =MainCamera.ScreenPointToRay(Input.mousePosition);
       Plane plane = new Plane(Vector3.up,new Vector3 (0,0.5f,0));
       plane.Raycast(ray,out float enter);
        
       return ray.GetPoint(enter);
  }
public NavMeshAgent TempMethod(NavMeshAgent agent, Transform Tower){
        if(Input.GetMouseButton(0)&&!direction){
            _currentState=StateUnit.WalkToCastle;
            direction = true;
            transform.DOMove(GetMousePosition(),1);
            
        }
        if(direction &&_currentState == StateUnit.WalkToCastle){
            agent.SetDestination(Tower.position);
        }
         return agent;
    }
 private void OnTriggerEnter(Collider other) {
    EnemyCard enemyCard= other.gameObject.GetComponent<EnemyCard>();
    Card AllyCard= gameObject.GetComponent<Card>();

         if(AllyCard.HealPoint<=0){
            enemyCard.ENcurrentState = StateUnit.WalkToCastle;
            Destroy(AllyCard.gameObject);
            CharacterManager.allyList.Remove(AllyCard.gameObject);
            

        }
        if( other.tag=="Enemy" && enemyCard.ENtypeOfCard == CardType.Stone && AllyCard.typeOfCard== CardType.Scissors){ 
        HealPoint= ModAttack( enemyCard.ENDamage,HealPoint,ModifyDamage);
          ComeBack();
        }
        else if(other.tag=="Enemy" && enemyCard.ENtypeOfCard == CardType.Stone){
        HealPoint= Attack(enemyCard.ENDamage,HealPoint); 
        ComeBack();
        }
        
        if(other.tag=="Enemy" && enemyCard.ENtypeOfCard == CardType.Paper&&AllyCard.typeOfCard== CardType.Stone){
        HealPoint= ModAttack( enemyCard.ENDamage,HealPoint,ModifyDamage);
        ComeBack();
        }
        else if(other.tag=="Enemy" && enemyCard.ENtypeOfCard == CardType.Paper){
        HealPoint= Attack(enemyCard.ENDamage,HealPoint);
        ComeBack();
        }

        if(other.tag=="Enemy" && enemyCard.ENtypeOfCard == CardType.Scissors&& AllyCard.typeOfCard== CardType.Paper){
         HealPoint= ModAttack( enemyCard.ENDamage,HealPoint,ModifyDamage);
        ComeBack(); 
        }
        else if(other.tag=="Enemy" && enemyCard.ENtypeOfCard == CardType.Scissors){
        HealPoint= Attack(enemyCard.ENDamage,HealPoint);
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
    StartCoroutine(NavmeshStart());
}
IEnumerator NavmeshStart()
{
    yield return new WaitForSeconds(0.2f);
    agent.isStopped = false;

}
NavMeshAgent NullAgent(NavMeshAgent agent){
    agent.isStopped = true;
    return agent;
}
}
