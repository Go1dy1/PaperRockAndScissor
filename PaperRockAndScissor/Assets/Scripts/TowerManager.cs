
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TowerManager : MonoBehaviour
{
  public bool Attaked =false;
  
void Start()
{
  
}
 public void OnBool(){
      Attaked =true;
    }

    void OFFBool(){
      Attaked =false;
    }
public int DOTower(int HeartTowerCount){
      OnBool();
      HeartTowerCount =-1;
      Debug.Log("count:");
      Invoke("OFFBool",0.3f);
      return HeartTowerCount;
  }

}
