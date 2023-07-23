using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Storage;
using TMPro;
using UnityEngine.Serialization;

public class EnemyCrush : MonoBehaviour
{
[FormerlySerializedAs("CollectedHeal")] [SerializeField] TMP_Text _collectedHeal;
static internal int HealPoint;
[FormerlySerializedAs("EnemyCastle")] [SerializeField] GameObject _enemyCastle;
private Vector3 _enemyfront = new Vector3(0.04f,0f,9.36f);
private Vector3 _enemyback = new Vector3(0f,0f,9.44f);
private const int Zero = 0; 

void Awake(){
      HealPoint= 5;
}
void OnTriggerEnter(Collider other)
{
if(other.tag == "Ally"){
  _enemyCastle.transform.DOMove(_enemyfront,0f,false );
  _enemyCastle.transform.DOMove(_enemyback,1f,false);
  CharacterManager.AllyList.Remove(other.gameObject);
  Destroy(other.gameObject);
  if(HealPoint>Zero){
    HealPoint= HealPoint-1;
    EnemyCreator.TimetoSpawn -=0.3f;
  }
  
  HealManager();
}


}
public void HealManager(){
  _collectedHeal.text= HealPoint.ToString();
}

}
