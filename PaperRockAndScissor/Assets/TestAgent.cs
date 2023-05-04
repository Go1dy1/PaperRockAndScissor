using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class TestAgent : MonoBehaviour
{

    public GameObject Enemy;

    public GameObject Ally;

    public NavMeshAgent agent ; 

    // Update is called once per frame
    void Awake()
    {
        
        
    }
    void Update()
    {
        if(Input.GetMouseButton(0)){
        agent.SetDestination(Enemy.transform.position);
        }

        if(Input.GetMouseButton(1)){
        agent.SetDestination(Ally.transform.position);
        }
    }
}
