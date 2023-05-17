
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class TowerManager : MonoBehaviour
{
[SerializeField] TMP_Text CollectedHeal;
private int HealPoint;
[SerializeField] GameObject MyCastle;  
private Vector3 myfront = new Vector3(0.04f,0.913f,-14.298f);
private Vector3 myback = new Vector3(0f,0.913f,-14.304f);
internal Transform AllyPos;
internal static TowerManager Ally;
    void Start()
    {
        Ally= this;
        AllyPos = gameObject.transform;
      

    }
void Awake()
{
  HealPoint= 15;
}
void OnTriggerEnter(Collider other)
{
  if(other.tag == "Enemy"){
    MyCastle.transform.DOMove(myfront,0f,false );
    MyCastle.transform.DOMove(myback,1f,false);
    CharacterManager.enemyList.Remove(other.gameObject);
    Destroy(other.gameObject);
      
    HealPoint= HealPoint-1;
    HealManager();
  }
}
public void HealManager(){
  CollectedHeal.text= HealPoint.ToString();
}

}
