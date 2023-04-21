using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UnitCreator : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] private Button BStone,BScissors,BPaper;

  public enum CardType{
    Stone,
    Scissors,
    Paper
  }
    public Transform T;
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
           Instantiate(Stone,T);
            break;
        case CardType.Scissors:
           Instantiate(Scissors,T);
            break;
        case CardType.Paper:
           Instantiate(Paper,T);
            break;
        default:
            Debug.LogError("Кнопка не назначенна");
            break;
    }
}
}

