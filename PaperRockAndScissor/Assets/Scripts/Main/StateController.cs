using System;
using Unity.VisualScripting;
using UnityEngine;

public interface ICard
{
   abstract float Attack(float HealPoints, ICard currentCard);
}
public class StateController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        var _Icard = GetComponent<ICard>();
        var enemyCard = other.GetComponent<ICard>();

        if (other.GetComponent<EnemyCard>() != null || other.GetComponentInChildren<EnemyCard>() != null)
        {
            var parentEnemyCard = other.GetComponent<EnemyCard>();

            if (enemyCard != null)parentEnemyCard._broadcastHealPoint = _Icard.Attack (parentEnemyCard._broadcastHealPoint, enemyCard );
        }
        else
        {
            var parentEnemyCard = other.GetComponent<Card>();
            
            if (enemyCard != null) parentEnemyCard._broadcastHealPoint = _Icard.Attack (parentEnemyCard._broadcastHealPoint, enemyCard);
        }  
        
    }
 
}
