using DG.Tweening;
using Storage;
using UnityEngine;
using UnityEngine.AI;

public class EnemyCard : MonoBehaviour
    {
        [SerializeField] private StateUnit _eNcurrentState;
        [SerializeField] private Transform _pos;
        [SerializeField] private ParticleSystem _puff;
        [SerializeField] private AudioSource _death;
        [SerializeField] protected float _healPoint;
        [SerializeField] protected float _enDamage ;
        [SerializeField] protected float _modifyDamage;
        [SerializeField] public Transform _tower;
        [SerializeField] protected NavMeshAgent _agent;
        public float _broadcastHealPoint ;
        private float _tempHealPoint;
        private const int ZeroHp = 0;

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
        internal void WalkToTowerPosition(NavMeshAgent agent, Transform tower){
            if(_eNcurrentState == StateUnit.WalkToCastle) 
            {
                agent.SetDestination(tower.position);
            }
        }
        private void OnTriggerEnter(Collider other) 
        {
            
            if(_healPoint<=ZeroHp)
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
        public void ComeBack(){
            if(gameObject!=null)transform.DOMove(_pos.position,0.2f,false);
        }
    }
    