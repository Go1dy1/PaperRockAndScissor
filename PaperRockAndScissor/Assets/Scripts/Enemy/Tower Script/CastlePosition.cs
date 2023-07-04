using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastlePosition : MonoBehaviour
{
    internal Transform enemyPos;
    public static CastlePosition enemy;
    void Start()
    {
        enemy= this;
        enemyPos = gameObject.transform;

    }

//создать консруктор класса енеми с доступом протект 
    // Update is called once per frame
}
