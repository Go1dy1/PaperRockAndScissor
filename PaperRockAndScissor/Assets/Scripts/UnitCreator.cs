using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UnitCreator : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] private Button BStone,BScissors,BPaper;

  

  Vector3 T= new Vector3(0f,1f,-9.94f);
   public GameObject Stone;
   public GameObject Scissors;
   public GameObject Paper;
   

private void Start()
{
  BStone.onClick.AddListener(()=>ChoiceCard(CardType.Stone));
  BScissors.onClick.AddListener(()=>ChoiceCard(CardType.Scissors));
  BPaper.onClick.AddListener(()=>ChoiceCard(CardType.Paper));
}
public void ChoiceCard(CardType card)
{
     switch (card)
    {
        case CardType.Stone:
      GameObject stone= Instantiate(Stone,T,Quaternion.identity);
            break;
        case CardType.Scissors:
          GameObject scissors=  Instantiate(Scissors,T,Quaternion.identity);
            break;
        case CardType.Paper:
          GameObject paper= Instantiate(Paper,T,Quaternion.identity);
            break;
        default:
            Debug.LogError("Кнопка не назначенна");
            break;
    }
}
}
public enum CardType{
    Stone,
    Scissors,
    Paper
  }


