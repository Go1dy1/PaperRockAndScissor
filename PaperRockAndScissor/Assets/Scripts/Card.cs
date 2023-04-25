using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;
public class Card : MonoBehaviour
{
  public enum StateUnit{
        Ide,
        WalkToCastle,
        WalkToEnemy
        
    }
    [SerializeField] StateUnit _currentState;
public bool direction= false;
public Transform Tower;
protected NavMeshAgent agent;

    void Awake()
{    _currentState = StateUnit.Ide;
   /* if(Uniqtag=="Enemy"){
    }
    else if(Uniqtag=="Ally"){
    }
   */ 
}
    private void Update()
    {
        if(Input.GetMouseButton(0)){
            transform.DOMove(GetMousePosition(),1);
        }
        if(_currentState==StateUnit.WalkToCastle){

        }
    }
public  Vector3 GetMousePosition()
{
    Camera MainCamera= Camera.main;
      Ray ray =MainCamera.ScreenPointToRay(Input.mousePosition);
       Plane plane = new Plane(Vector3.up,new Vector3 (0,0.5f,0));
       plane.Raycast(ray,out float enter);
        
       return ray.GetPoint(enter);
  }
public NavMeshAgent TempMethod(NavMeshAgent agent, Transform Tower){
        if(Input.GetMouseButton(0)&&!direction){
            _currentState=StateUnit.WalkToCastle;
           direction = true;
            transform.DOMove(GetMousePosition(),1);
            agent.SetDestination(Tower.position);
        }
         
         return agent;
    }


}
