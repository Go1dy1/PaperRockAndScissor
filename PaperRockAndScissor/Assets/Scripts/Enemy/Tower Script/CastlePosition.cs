using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastlePosition : MonoBehaviour
{
    internal Transform EnemyPos;
    public static CastlePosition Enemy;
    void Start()
    {
        Enemy= this;
        EnemyPos = gameObject.transform;

    }

//создать консруктор класса енеми с доступом протект 
    // Update is called once per frame
}
