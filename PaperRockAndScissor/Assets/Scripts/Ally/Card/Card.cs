using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;

public class Card : MonoBehaviour
{
[SerializeField] internal CardType typeOfCard ;
[SerializeField] private StateUnit _currentState;
[SerializeField] private Transform Pos;
[SerializeField] private ParticleSystem Puff;
[SerializeField] private AudioSource Death;
[SerializeField] internal Transform Tower;
public float HealPoint;
internal float Damage;
internal float speed;
internal float ModifyDamage;
private int ZeroHP = 0;
private bool direction= false;
internal NavMeshAgent agent;

void Awake()
{ 

    _currentState = StateUnit.Ide;
    agent = GetComponent<NavMeshAgent>();    

}
void Update()
{
    if(HealPoint<=0f)
    {
        CharacterManager.enemyList.Remove(gameObject);
        Destroy(gameObject);     
    }

}
private Vector3 GetMousePosition()
{

    Camera MainCamera= Camera.main;
    Ray ray =MainCamera.ScreenPointToRay(Input.mousePosition);
    Plane plane = new Plane(Vector3.up,new Vector3 (0,0.5f,0));
    plane.Raycast(ray,out float enter);
        
    return ray.GetPoint(enter);
  
}
public NavMeshAgent TempMethod(NavMeshAgent agent, Transform Tower)
{
    if (Input.GetMouseButton(0) && !direction && gameObject != null)
    {
        _currentState = StateUnit.WalkToCastle;
        if (PosCollider.AccsesPoint == true && gameObject != null)
        {
            direction = true;
            transform.DOMove(GetMousePosition(), 1);
        }
    }

    if (direction && _currentState == StateUnit.WalkToCastle)
    {
        agent.SetDestination(Tower.position);
    }

    return agent;
}

private void OnTriggerEnter(Collider other)
{
    
    EnemyCard enemyCard= other.gameObject.GetComponent<EnemyCard>();
    Card AllyCard= gameObject.GetComponent<Card>();
    
   if(AllyCard.HealPoint<=ZeroHP)
    {
        SpawnEffect();
        CharacterManager.allyList.Remove(AllyCard.gameObject);
        Destroy(AllyCard.gameObject);
            
    }
       
    if (other.tag == "Enemy")
    {    

        if(enemyCard.ENtypeOfCard == CardType.Stone)
        { 
            if(AllyCard.typeOfCard== CardType.Scissors)
            {
                HealPoint= ModAttack( enemyCard.ENDamage,HealPoint,enemyCard.ModifyDamage);
            }
            else
            {
                HealPoint = Attack(enemyCard.ENDamage, HealPoint);
            }
        }
        else if(enemyCard.ENtypeOfCard == CardType.Paper)
        {
            if(AllyCard.typeOfCard== CardType.Stone)
            {
                HealPoint= ModAttack( enemyCard.ENDamage,HealPoint,enemyCard.ModifyDamage);
            }
            else
            {
                HealPoint = Attack(enemyCard.ENDamage, HealPoint);
            }
        }
        else if (enemyCard.ENtypeOfCard == CardType.Scissors)
        {
            if (AllyCard.typeOfCard== CardType.Paper)
            {
                HealPoint = ModAttack(enemyCard.ENDamage, HealPoint, enemyCard.ModifyDamage);
            }
            else
            {
                HealPoint = Attack(enemyCard.ENDamage, HealPoint);
            }
        
        }
        ComeBack();
    }

}
public void SpawnEffect()
{   
    Instantiate(Puff,gameObject.transform.position,Quaternion.identity);
    Instantiate(Death,gameObject.transform.position,Quaternion.identity);

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

    if(gameObject!=null)transform.DOMove(Pos.position,0.2f,false);
    StartCoroutine(NavmeshStart());

}
IEnumerator NavmeshStart()
{

    yield return new WaitForSeconds(0.2f);
    agent.isStopped = false;

}
NavMeshAgent NullAgent(NavMeshAgent agent)
{
    agent.isStopped = true;
    return agent;
}

}


