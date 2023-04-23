using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyHeart : TowerManager
{
    public Animator anim;
private int MyHeartTower = 15;
    void Start()
    {
        anim.SetBool("Attaked",Attaked);
    }
void OnTriggerEnter(Collider other)
      {
    
        if(other.tag == "Enemy"){
         DOTower(MyHeartTower);
         
        }

       
      }
    void Update()
    {
        
    }
}
