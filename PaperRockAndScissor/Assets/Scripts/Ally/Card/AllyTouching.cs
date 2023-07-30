using Storage;
using UnityEngine;
using UnityEngine.AI;

public class AllyTouching : MonoBehaviour
{
float _minDist = Mathf.Infinity;
    [SerializeField] private NavMeshAgent _agent;
    private GameObject CurrentPoint ;
    void Update()
    {
        foreach(GameObject enemy in CharacterManager.EnemyList)
        {
          if (enemy!=null)
          {
            EnemyCard enemyCard = enemy.GetComponent<EnemyCard>();

            float tempDistanceBetObj= Vector3.Distance(transform.position,enemy.transform.position);

            if(enemy.activeSelf &&tempDistanceBetObj<_minDist)
            {
                CurrentPoint = enemy;
                _minDist = tempDistanceBetObj;
            }

            if(CurrentPoint != null && _minDist < CharacterManager.MinDistance)
            {
                _agent.SetDestination(CurrentPoint.transform.position);
            }
            else if(CurrentPoint != null&&!CurrentPoint.activeSelf)
            {
                CurrentPoint =null;
            }

            
            }
        }

    }
}
