using System.Collections;
using System.Collections.Generic;
using Storage;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

public class EnemyTouching : MonoBehaviour
{ 
   private float _tempDistanceBetObj;
   private float _minDist = Mathf.Infinity;
   [SerializeField] private NavMeshAgent _agent;
   private GameObject _currentPoint ;

   private void Update()
    {
        foreach(var ally in CharacterManager.AllyList){
            
            if(ally!=null) _tempDistanceBetObj= Vector3.Distance(transform.position, ally.transform.position);

            if(ally!=null && ally.activeSelf && _tempDistanceBetObj < _minDist)
            {
                    _currentPoint = ally;
                    _minDist = _tempDistanceBetObj;
            }

            if(_currentPoint != null && _minDist < CharacterManager.MinDistance){
                _agent.SetDestination(_currentPoint.transform.position);
            }
      
        
        }
    }
}
