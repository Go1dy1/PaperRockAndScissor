using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Ally.Card
{
    public class Stone : global::Card,ICard
    {
        private IEnumerator Start()
        {
            _broadcastHealPoint = _healPoint;
            
            yield return new WaitForEndOfFrame();
            _tower= CastlePosition.Enemy.EnemyPos;  
            Agent= GetComponent<NavMeshAgent>(); 
        }
        void Update()
        {
            _healPoint = _broadcastHealPoint;
            WalkToTowerPosition(Agent, _tower);
        }
        
        public float Attack(float healPoints, ICard currentCard)
        {
            if (currentCard as EnemyScissors)
            {
                healPoints -= (_Damage + _ModifyDamage);
            }
            else
            {
                healPoints -= _Damage;
            }
        
            ComeBack();

            return healPoints;
        }
        
    }
    
}
