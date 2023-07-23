using UnityEngine;
using DG.Tweening;
using Storage;
using TMPro;
using UnityEngine.Serialization;

public class TowerManager : MonoBehaviour
{
  [FormerlySerializedAs("collectedHealText")] [SerializeField] private TMP_Text _collectedHealText;
  [FormerlySerializedAs("myCastleObject")] [SerializeField] private GameObject _myCastleObject;  
  static internal int HealPointTower = 5;
  private Vector3 _myFrontPosition = new Vector3(0.04f,0f,-19.298f);
  private Vector3 _myBackPosition = new Vector3(0f,0f,-19.66f);
  public Transform AllyPos{get;private set;} 
  private const int Zero = 0; 
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
          _myCastleObject.transform.DOMove(_myFrontPosition, 0f, false);
          _myCastleObject.transform.DOMove(_myBackPosition, 1f, false);
          CharacterManager.EnemyList.Remove(other.gameObject);
          Destroy(other.gameObject);
        
          if (HealPointTower > 0)
            HealPointTower--;
        
          UpdateHealText();
      }
  }

  public void UpdateHealText()
  {
      _collectedHealText.text = HealPointTower.ToString();
  }


}
