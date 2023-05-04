using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterManager : MonoBehaviour
{
    public static List<GameObject> enemyList = new List<GameObject>();
    public static List<GameObject> allyList = new List<GameObject>();

    [SerializeField] internal StateUnit State;
    GameObject closestEnemy = null;
    float minDistance = Mathf.Infinity;
   public float MinDistance= 3f;
   float EnemyMinDistance= 1f;
    public int enem ;
    
    void Update()
    {
     Debug.Log("Ally"+allyList.Count);
     Debug.Log("Enemy:"+enemyList.Count);
       foreach (GameObject Enemy in enemyList)
       {
        EnemyCard enemyAgent = Enemy.GetComponent<EnemyCard>();
        if (enemyAgent == null)  Debug.Log("NULL");
        
        foreach (GameObject Ally in allyList)
        {
          Card allyAgent = Ally.GetComponent<Card>();
          float tempDistanceBetObj= Vector3.Distance(Enemy.transform.position,Ally.transform.position);

            if(tempDistanceBetObj<MinDistance&&enemyAgent!=null&&allyAgent!=null){
              allyAgent._currentState= StateUnit.WalkToEnemy;
              allyAgent.agent.SetDestination(enemyAgent.transform.position);
             
              //enemyAgent.agent.SetDestination(allyAgent.transform.position);
            }
            
        
        }
       }

      // if(allyAgent._currentState== StateUnit.WalkToEnemy) 
    }

}
public enum StateUnit{Ide,WalkToCastle,WalkToEnemy}
