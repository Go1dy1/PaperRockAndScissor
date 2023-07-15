using UnityEngine;
using DG.Tweening;
using TMPro;

public class TowerManager : MonoBehaviour
{
  [SerializeField] private TMP_Text collectedHealText;
  [SerializeField] private GameObject myCastleObject;  
  static internal int healPointTower = 5;
  private Vector3 myFrontPosition = new Vector3(0.04f,0f,-19.298f);
  private Vector3 myBackPosition = new Vector3(0f,0f,-19.66f);
  public Transform AllyPos{get;private set;} 
  private const int zero = 0; 
  internal static TowerManager Ally;


  private void Start()
  {
    Ally= this;
    AllyPos = gameObject.transform;
  }
  void OnTriggerEnter(Collider other)
  {
      if (other.tag == "Enemy")
      {
          myCastleObject.transform.DOMove(myFrontPosition, 0f, false);
          myCastleObject.transform.DOMove(myBackPosition, 1f, false);
          CharacterManager.enemyList.Remove(other.gameObject);
          Destroy(other.gameObject);
        
          if (healPointTower > 0)
            healPointTower--;
        
          UpdateHealText();
      }
  }

  public void UpdateHealText()
  {
      collectedHealText.text = healPointTower.ToString();
  }


}
