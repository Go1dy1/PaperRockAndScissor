using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Scissors : Card
{
 int direction = 1;
private int HealPoint= 8;
private int Damage = 3;
private int Price= 3;
public float speed;
private float ModifyDamage= 2;
    void Update()
    {
       TempMethod();
    }

    void TempMethod(){
        if(Input.GetMouseButton(0) && direction>=0 ){
           direction -= 1;
            transform.DOMove(GetMousePosition(),1);
        }
    }
}
