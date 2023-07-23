using System.Collections;
using System.Collections.Generic;
using Storage;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class EnemyTouching : MonoBehaviour
{
    private float tempDistanceBetObj;
   private float _minDist = Mathf.Infinity;
   [SerializeField] private NavMeshAgent _agent;
   private GameObject _currentPoint ;
   
    void Update()
    {
        foreach(GameObject ally in CharacterManager.AllyList){
            
         //Card allyCard = ally.GetComponent<Card>();
            if(ally!=null) tempDistanceBetObj= Vector3.Distance(transform.position, ally.transform.position);

            if(ally!=null && ally.activeSelf && tempDistanceBetObj < _minDist)
            {
                    _currentPoint = ally;
                    _minDist = tempDistanceBetObj;
            }

            if(_currentPoint != null && _minDist < CharacterManager.MinDistance){
                _agent.SetDestination(_currentPoint.transform.position);
            }
      
        
        }
    }
}
