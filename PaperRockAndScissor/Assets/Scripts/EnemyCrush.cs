using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class EnemyCrush : MonoBehaviour
{
    public TMP_Text CollectedHeal;
    private int HealPoint;
    public GameObject EnemyCastle;
    private Vector3 enemyfront = new Vector3(0.04f,0.913f,7.08f);
    private Vector3 enemyback = new Vector3(0f,0.913f,7.02f);
    void Awake()
    {
      HealPoint= 15;
    }
void OnTriggerEnter(Collider other)
{
if(other.tag == "Ally"){
  EnemyCastle.transform.DOMove(enemyfront,0f,false );
  EnemyCastle.transform.DOMove(enemyback,1f,false);
  Destroy(other.gameObject);
  
  HealPoint= HealPoint-1;
  HealManager();
}
}
public void HealManager(){
  CollectedHeal.text= HealPoint.ToString();
}
}
