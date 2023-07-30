using UnityEngine;

public interface ICard
{
  float Attack(float healPoints, ICard currentCard);
}
public class StateController : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        var icard = GetComponent<ICard>();
        var enemyCard = other.GetComponent<ICard>();
        
        if (other.GetComponent<EnemyCard>() != null || other.GetComponentInChildren<EnemyCard>() != null)
        {
            var parentEnemyCard = other.GetComponent<EnemyCard>();

            if (enemyCard != null)parentEnemyCard._broadcastHealPoint = icard.Attack (parentEnemyCard._broadcastHealPoint, enemyCard );
        }
        else
        {
            var parentEnemyCard = other.GetComponent<Card>();
            
            if (enemyCard != null) parentEnemyCard._broadcastHealPoint = icard.Attack (parentEnemyCard._broadcastHealPoint, enemyCard);
        }  
        
    }
 
}
