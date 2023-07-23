using DG.Tweening;
using Storage;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

    public class EnemyCard : MonoBehaviour
    {
        [SerializeField] internal CardType _eNtypeOfCard ;
        [SerializeField] private StateUnit _eNcurrentState;
        [SerializeField] private Transform _pos;
        [SerializeField] private ParticleSystem _puff;
        [SerializeField] private AudioSource _death;
        [SerializeField] protected float _healPoint;
        
        public float _broadcastHealPoint ;
        [SerializeField] protected float _enDamage ;
        [SerializeField] protected float _modifyDamage;
        [SerializeField] protected float _speed;
        [SerializeField] public Transform _tower;
        private float _tempHealPoint;
        private const int _zeroHp = 0;
        [SerializeField] protected NavMeshAgent _agent;
        private void Awake(){ 
            _agent = GetComponent<NavMeshAgent>();
            _eNcurrentState= StateUnit.WalkToCastle;
            _tempHealPoint = _healPoint;

        }
        void Update() {

            if(_healPoint<=0f){
   
                CharacterManager.EnemyList.Remove(gameObject);
                Destroy(gameObject);
            }

            if (_healPoint < _tempHealPoint)
            {
                ComeBack();
                _tempHealPoint = _healPoint;
            }
        }
        internal NavMeshAgent TempMethod(NavMeshAgent agent,Transform tower){
            if(_eNcurrentState == StateUnit.WalkToCastle) 
            {
                agent.SetDestination(tower.position);
            }
            return agent;
        }
        private void OnTriggerEnter(Collider other) 
        {
            
            if(_healPoint<=_zeroHp)
            {
                SpawnEffect();
                CharacterManager.EnemyList.Remove(gameObject);
                Destroy(gameObject);
            }

            
        }

        private void SpawnEffect()
        {
            var position = gameObject.transform.position;
            Instantiate(_puff, position,Quaternion.identity);
            Instantiate(_death, position,Quaternion.identity);

        }

        private float Attack(float damage, float health){
            health= health- damage;
            return health;
        }

        private float ModAttack(float damage, float health, float modifyDamage){
            health= health- (damage*modifyDamage);
            return health;
        }
        public void ComeBack(){
            if(gameObject!=null)transform.DOMove(_pos.position,0.2f,false);
        }
        public NavMeshAgent FollowAttack(NavMeshAgent agent, Transform allyPerson){
            agent.SetDestination(allyPerson.position);
            return agent;
        }
        NavMeshAgent NullAgent(NavMeshAgent agent){
            agent.isStopped = true;
            return agent;
        }

    }


















/*   if(other.CompareTag("Ally"))
            { 

                if(allyCard._typeOfCard== CardType.Stone)
                { 
                    if(enemyCard._eNtypeOfCard == CardType.Scissors)
                    {
                        _healPoint= ModAttack( enemyCard._enDamage,_healPoint,enemyCard._modifyDamage);
                    }
                    else
                    {
                        _healPoint = Attack(enemyCard._enDamage, _healPoint);
                    }
                }
                else if(allyCard._typeOfCard== CardType.Paper)
                {
                    if(enemyCard._eNtypeOfCard == CardType.Stone)
                    {
                        _healPoint= ModAttack( enemyCard._enDamage,_healPoint,enemyCard._modifyDamage);
                    }
                    else
                    {
                        _healPoint = Attack(enemyCard._enDamage, _healPoint);
                    }
                }
                else if (allyCard._typeOfCard== CardType.Scissors)
                {
                    if (enemyCard._eNtypeOfCard == CardType.Paper)
                    {
                        _healPoint = ModAttack(enemyCard._enDamage, _healPoint, enemyCard._modifyDamage);
                    }
                    else
                    {
                        _healPoint = Attack(enemyCard._enDamage, _healPoint);
                    }
        
                }
                ComeBack();
            }
            */