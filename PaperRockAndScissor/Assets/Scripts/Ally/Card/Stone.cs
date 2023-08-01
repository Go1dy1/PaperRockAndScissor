using Enemy.Card;
using UnityEngine.AI;
using Storage;

namespace Ally.Card
{
    public class Stone : global::Card,ICard
    {
        private new void Start()
        {
            _broadcastHealPoint = _healPoint;
            
            _tower= CastlePosition.Enemy.EnemyPos;  
            Agent= GetComponent<NavMeshAgent>(); 
        }
        public void Update()
        {
            _healPoint = _broadcastHealPoint;
            WalkToTowerPosition(Agent, _tower);
            
            if (_healPoint < ZeroHp)
            {
                SpawnEffect();
                CharacterManager.AllyList.Remove(gameObject);
                Destroy(gameObject);
            }
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

