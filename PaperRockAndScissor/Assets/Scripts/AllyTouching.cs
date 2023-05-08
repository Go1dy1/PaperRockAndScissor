using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AllyTouching : MonoBehaviour
{
float MinDist = Mathf.Infinity;
   [SerializeField] NavMeshAgent agent;
   internal GameObject currentPoint ;
    void Update()
    {
        foreach(GameObject Enemy in CharacterManager.enemyList){
            EnemyCard EnemyCard = Enemy.GetComponent<EnemyCard>();

        float tempDistanceBetObj= Vector3.Distance(transform.position,Enemy.transform.position);


        if(Enemy.activeSelf &&tempDistanceBetObj<MinDist){
                    currentPoint = Enemy;
                    MinDist = tempDistanceBetObj;
            }

        if(currentPoint != null && MinDist < CharacterManager.MinDistance){
            agent.SetDestination(currentPoint.transform.position);
        }
        }

    }
}
