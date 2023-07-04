using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTouching : MonoBehaviour
{
   private float MinDist = Mathf.Infinity;
   [SerializeField] private NavMeshAgent agent;
   internal GameObject currentPoint ;
    void Update()
    {
        foreach(GameObject Ally in CharacterManager.allyList){
            
            Card AllyCard = Ally.GetComponent<Card>();
            
            float tempDistanceBetObj= Vector3.Distance(transform.position,Ally.transform.position);

            if(Ally.activeSelf &&tempDistanceBetObj<MinDist){
                    currentPoint = Ally;
                    MinDist = tempDistanceBetObj;
            }

         if(currentPoint != null && MinDist < CharacterManager.MinDistance){
            agent.SetDestination(currentPoint.transform.position);
        }
      
        
        }
    }
}
