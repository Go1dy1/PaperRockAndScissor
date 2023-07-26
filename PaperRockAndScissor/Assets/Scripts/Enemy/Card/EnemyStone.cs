using System.Collections;
using Ally.Card;
using Ally.Tower;
using UnityEngine;
using UnityEngine.AI;
public class EnemyStone : global:: EnemyCard,ICard
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
        WalkToTowerPosition(_agent,_tower);
    }
    public float Attack(float healPoints, ICard currentCard)
    {
        if (currentCard as Scissors)
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
