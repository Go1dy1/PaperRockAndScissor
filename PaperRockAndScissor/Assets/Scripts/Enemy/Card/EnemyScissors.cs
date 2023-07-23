using System.Collections;
using Ally.Card;
using UnityEngine;
using UnityEngine.AI;
public class EnemyScissors : EnemyCard,ICard
{
    private IEnumerator Start()
{
    _broadcastHealPoint = _healPoint;
    
    yield return new WaitForEndOfFrame();
    _tower= TowerManager.Ally.AllyPos;  
    _agent= GetComponent<NavMeshAgent>(); 
}
void Update()
{
    _healPoint = _broadcastHealPoint;
    TempMethod(_agent,_tower);
}
public float Attack(float healPoints, ICard currentCard)
{
    if (currentCard as Paper)
    {
        healPoints -= (_enDamage + _modifyDamage);
    }
    else
    {
        healPoints -= _enDamage;
    }
        
    ComeBack();

    return healPoints;
}

}
