using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class UnitCreator : MonoBehaviour
{
  [SerializeField] Camera _camera;
  [SerializeField] private Button BStone,BScissors,BPaper;
  private Vector3 T;
   public GameObject Stone;
   public GameObject Scissors;
   public GameObject Paper;
   bool IsLocked = false;
   

private IEnumerator SpawnEnemy(){
  while(true){
      T = new Vector3(UnityEngine.Random.Range(-2f,2.15f), 1f, -10f);
    
    yield return new WaitForSeconds(5f);
  }

}
private void Awake() {
  BStone.onClick.AddListener(()=>ChoiceCard(CardType.Stone));
  BScissors.onClick.AddListener(()=>ChoiceCard(CardType.Scissors));
  BPaper.onClick.AddListener(()=>ChoiceCard(CardType.Paper));
}
private IEnumerator Start()
{
  yield return StartCoroutine(SpawnEnemy());

}
public void ChoiceCard(CardType card)
{
  if(!IsLocked){

           
            

     switch (card)
    {
        case CardType.Stone :
            if(Unit.CurrentManaScore>=3){
               IsLocked = true;
            StartCoroutine(UnlockButtonAfterDelay(1.5f));
              Unit.CurrentManaScore-=3;
          GameObject stone= Instantiate(Stone,T,Quaternion.identity);
          CharacterManager.allyList.Add(stone.gameObject);
            }
            break;
        case CardType.Scissors:
        if(Unit.CurrentManaScore>=1){
           IsLocked = true;
            StartCoroutine(UnlockButtonAfterDelay(1.5f));
          Unit.CurrentManaScore-=1;
          GameObject scissors=  Instantiate(Scissors,T,Quaternion.identity);
          CharacterManager.allyList.Add(scissors.gameObject);
            }
            break;
        case CardType.Paper:
        if(Unit.CurrentManaScore>=2){
           IsLocked = true;
            StartCoroutine(UnlockButtonAfterDelay(1.5f));
          Unit.CurrentManaScore-=2;
          GameObject paper= Instantiate(Paper,T,Quaternion.identity);
          CharacterManager.allyList.Add(paper.gameObject);
            }
            break;
        default:
            Debug.LogError("Кнопка не назначенна");
            break;
    }

  }
}
private IEnumerator UnlockButtonAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        IsLocked = false;
        
    }


}
public enum CardType{
    Stone,
    Scissors,
    Paper
  }


/*public void ChoiceCard(CardType card)
{
     switch (card)
    {
        case CardType.Stone :
            if(Unit.CurrentManaScore>=3){
              Unit.CurrentManaScore-=3;
          GameObject stone= Instantiate(Stone,T,Quaternion.identity);
          CharacterManager.allyList.Add(stone.gameObject);
            }
            break;
        case CardType.Scissors:
        if(Unit.CurrentManaScore>=1){
          Unit.CurrentManaScore-=1;
          GameObject scissors=  Instantiate(Scissors,T,Quaternion.identity);
          CharacterManager.allyList.Add(scissors.gameObject);
            }
            break;
        case CardType.Paper:
        if(Unit.CurrentManaScore>=2){
          Unit.CurrentManaScore-=2;
          GameObject paper= Instantiate(Paper,T,Quaternion.identity);
          CharacterManager.allyList.Add(paper.gameObject);
            }
            break;
        default:
            Debug.LogError("Кнопка не назначенна");
            break;
    }
}
*/