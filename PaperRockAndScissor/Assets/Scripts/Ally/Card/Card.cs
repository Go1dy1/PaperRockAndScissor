using System.Collections;
using UnityEngine;
using DG.Tweening;
using Storage;
using Unity.VisualScripting;
using UnityEngine.AI;
using UnityEngine.Serialization;
using StateUnit = Storage.StateUnit;

public class Card : MonoBehaviour
{
[SerializeField] private StateUnit _currentState;
[SerializeField] private Transform _pos;
[SerializeField] private ParticleSystem _puff;
[SerializeField] private AudioSource _death;
[SerializeField] protected Transform _tower;
[SerializeField] protected float _healPoint;

public float _broadcastHealPoint ;
[SerializeField] protected float _Damage;
[SerializeField] protected float _ModifyDamage;
private Card allyCard;
private int _zeroHp = 0;
private bool _direction;
internal NavMeshAgent Agent;

private void Awake()
{ 
    _broadcastHealPoint = _healPoint;
    _currentState = StateUnit.Ide;
    Agent = GetComponent <NavMeshAgent>();    

}
private void Update()
{
   
    if(allyCard._healPoint<=_zeroHp)
    { 
        SpawnEffect();
        CharacterManager.AllyList.Remove(allyCard.gameObject);
        Destroy(allyCard.gameObject);
            
    }

}
private Vector3 GetMousePosition()
{

    var mainCamera= Camera.main;
    if (mainCamera != null)
    {
        var ray =mainCamera.ScreenPointToRay (Input.mousePosition);
        var plane = new Plane(Vector3.up, new Vector3 (0,0.5f,0));
        plane.Raycast(ray, out float enter);
        
        return ray.GetPoint(enter);
    }

    return default;
}

protected void WalkToTowerPosition(NavMeshAgent agent, Transform tower)
{
    if (Input.GetMouseButton(0) && !_direction && gameObject != null)
    {
        _currentState = StateUnit.WalkToCastle;
        if (PosCollider.AccsesPoint == true && gameObject != null)
        {
            _direction = true;
            transform.DOMove(GetMousePosition(), 1);
        }
    }

    if (_direction && _currentState == StateUnit.WalkToCastle)
    {
        agent.SetDestination(tower.position);
    }
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



public void SpawnEffect()
{   
    Instantiate(_puff,gameObject.transform.position,Quaternion.identity);
    Instantiate(_death,gameObject.transform.position,Quaternion.identity);

}
public void ComeBack()
{

    if(gameObject!=null)transform.DOMove(_pos.position,0.2f,false);
    StartCoroutine(NavmeshStart());

}
IEnumerator NavmeshStart()
{

    yield return new WaitForSeconds(0.2f);
    Agent.isStopped = false;

}
}





















/*
using System.Collections;
using UnityEngine;
using DG.Tweening;
using Storage;
using UnityEngine.AI;
using UnityEngine.Serialization;

interface ICard
{
    abstract void Atack(int heath, ICard enemyCard);
    
}
public class Card : MonoBehaviour
{
[SerializeField] internal CardType _typeOfCard ;
[SerializeField] private StateUnit _currentState;
[SerializeField] private Transform _pos;
[SerializeField] private ParticleSystem _puff;
[SerializeField] private AudioSource _death;
[SerializeField] internal Transform _tower;
[SerializeField] private float _healPoint;
[SerializeField] private float _Damage;
[SerializeField] private float _Speed;
[SerializeField] private float _ModifyDamage;
private int _zeroHp = 0;
private bool _direction= false;
internal NavMeshAgent Agent;

private void Awake()
{ 

    _currentState = StateUnit.Ide;
    Agent = GetComponent <NavMeshAgent>();    

}

private void Update()
{
    if(_healPoint<=0f)
    {
        CharacterManager.EnemyList.Remove (gameObject);
        Destroy (gameObject);     
    }

}
private Vector3 GetMousePosition()
{

    var mainCamera= Camera.main;
    if (mainCamera != null)
    {
        var ray =mainCamera.ScreenPointToRay (Input.mousePosition);
        var plane = new Plane(Vector3.up, new Vector3 (0,0.5f,0));
        plane.Raycast(ray, out float enter);
        
        return ray.GetPoint(enter);
    }

    return default;
}

protected NavMeshAgent WalkToTowerPosition(NavMeshAgent agent, Transform tower)
{
    if (Input.GetMouseButton(0) && !_direction && gameObject != null)
    {
        _currentState = StateUnit.WalkToCastle;
        if (PosCollider.AccsesPoint == true && gameObject != null)
        {
            _direction = true;
            transform.DOMove(GetMousePosition(), 1);
        }
    }

    if (_direction && _currentState == StateUnit.WalkToCastle)
    {
        agent.SetDestination(tower.position);
    }

    return agent;
}

private void OnTriggerEnter(Collider other)
{
    
    EnemyCard enemyCard= other.gameObject.GetComponent<EnemyCard>();
    Card allyCard= gameObject.GetComponent<Card>();
    
   if(allyCard._healPoint<=_zeroHp)
    {
        SpawnEffect();
        CharacterManager.AllyList.Remove(allyCard.gameObject);
        Destroy(allyCard.gameObject);
            
    }
       
    if (other.tag == "Enemy")
    {    

        if(enemyCard._eNtypeOfCard == CardType.Stone)
        { 
            if(allyCard._typeOfCard== CardType.Scissors)
            {
                _healPoint= ModAttack( enemyCard._enDamage,_healPoint,enemyCard._modifyDamage);
            }
            else
            {
                _healPoint = Attack(enemyCard._enDamage, _healPoint);
            }
        }
        else if(enemyCard._eNtypeOfCard == CardType.Paper)
        {
            if(allyCard._typeOfCard== CardType.Stone)
            {
                _healPoint= ModAttack( enemyCard._enDamage,_healPoint,enemyCard._modifyDamage);
            }
            else
            {
                _healPoint = Attack(enemyCard._enDamage, _healPoint);
            }
        }
        else if (enemyCard._eNtypeOfCard == CardType.Scissors)
        {
            if (allyCard._typeOfCard== CardType.Paper)
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

}
public void SpawnEffect()
{   
    Instantiate(_puff,gameObject.transform.position,Quaternion.identity);
    Instantiate(_death,gameObject.transform.position,Quaternion.identity);

}
public float Attack(float damage, float health)
{

    health= health- damage;
    return health;

}
public float ModAttack(float damage, float health, float modifyDamage)
{

    health= health- (damage*modifyDamage);
    return health;

}
private void ComeBack()
{

    if(gameObject!=null)transform.DOMove(_pos.position,0.2f,false);
    StartCoroutine(NavmeshStart());

}
IEnumerator NavmeshStart()
{

    yield return new WaitForSeconds(0.2f);
    Agent.isStopped = false;

}
NavMeshAgent NullAgent(NavMeshAgent agent)
{
    agent.isStopped = true;
    return agent;
}

}

*/


