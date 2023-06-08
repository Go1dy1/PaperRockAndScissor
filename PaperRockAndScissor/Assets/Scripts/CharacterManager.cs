using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterManager : MonoBehaviour
{
    static internal float MinDistance = 3f;
    public static List<GameObject> enemyList = new List<GameObject>();
    public static List<GameObject> allyList = new List<GameObject>();
}
public enum StateUnit{Ide,WalkToCastle,WalkToEnemy}
