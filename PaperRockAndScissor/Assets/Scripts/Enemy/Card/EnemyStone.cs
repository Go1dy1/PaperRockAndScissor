using Ally.Card;
using UnityEngine.AI;

namespace Enemy.Card
{
    public class EnemyStone : global:: EnemyCard,ICard
    {
        private void Start()
        {
            _broadcastHealPoint = _healPoint;
            
            _tower= TowerManager.Ally.AllyPos;  
            _agent= GetComponent<NavMeshAgent>(); 
        }

        private void Update()
        {
            _healPoint = _broadcastHealPoint;
            WalkToTheCastle(_agent,_tower);
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
}
