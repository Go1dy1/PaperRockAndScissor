using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterManager : MonoBehaviour
{
    public static List<GameObject> enemyList = new List<GameObject>();
    public static List<GameObject> allyList = new List<GameObject>();


    static public float MinDistance= 3f;  
    void Update()
    {
     //Debug.Log("Ally"+allyList.Count);
    // Debug.Log("Enemy:"+enemyList.Count);
     
    }

}
public enum StateUnit{Ide,WalkToCastle,WalkToEnemy}
