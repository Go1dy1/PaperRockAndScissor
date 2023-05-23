using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
public class EnemyCrush : MonoBehaviour
{
[SerializeField] TMP_Text CollectedHeal;
static internal int HealPoint;
[SerializeField] GameObject EnemyCastle;
private Vector3 enemyfront = new Vector3(0.04f,0.913f,7.08f);
private Vector3 enemyback = new Vector3(0f,0.913f,7.02f);
private const int zero = 0; 

void Awake(){
      HealPoint= 5;
}
void OnTriggerEnter(Collider other)
{
if(other.tag == "Ally"){
  EnemyCastle.transform.DOMove(enemyfront,0f,false );
  EnemyCastle.transform.DOMove(enemyback,1f,false);
  CharacterManager.allyList.Remove(other.gameObject);
  Destroy(other.gameObject);
  if(HealPoint>zero){
    HealPoint= HealPoint-1;
    EnemyCreator.TimetoSpawn -=0.3f;
  }
  
  HealManager();
}


}
public void HealManager(){
  CollectedHeal.text= HealPoint.ToString();
}

}
