using System.Collections;
using Ally.Card;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.Card
{
    public class EnemyPaper : EnemyCard,ICard
    {
        private void Start()
        {
            _broadcastHealPoint = _healPoint;
            
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
            if (currentCard as Stone)
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
}
