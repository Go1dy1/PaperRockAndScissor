
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TowerManager : MonoBehaviour
{
  bool Attaked =false;
  public Animator anim;
    private int EnemyHeartTower = 15;
    private int MyHeartTower = 15;

    void OnBool(){
      Attaked =true;
    }

    void OFFBool(){
      Attaked =false;
    }
    void Update()
    {
      anim.SetBool("Attaked",Attaked);
    }
   void OnTriggerEnter(Collider other)
   {
    
     if(other.tag == "Enemy"){
         
      OnBool();

      Invoke("OFFBool",0.3f);
        
       
    }
   }
  
    
}
