using System.Collections;
using Storage;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UnitCreator : MonoBehaviour
{
  [FormerlySerializedAs("BStone")] [SerializeField] private Button _bStone;
  [FormerlySerializedAs("BScissors")] [SerializeField] private Button _bScissors;
  [FormerlySerializedAs("BPaper")] [SerializeField] private Button _bPaper;
  [FormerlySerializedAs("Stone")] [SerializeField] private GameObject _stone;
  [FormerlySerializedAs("Scissors")] [SerializeField] private GameObject _scissors;
  [FormerlySerializedAs("Paper")] [SerializeField] private GameObject _paper;
  private Vector3 _spawnPositionCard;
  bool _isLocked = false;
   
private void Awake() {
  _bStone.onClick.AddListener(()=>ChoiceCard(CardType.Stone));
  _bScissors.onClick.AddListener(()=>ChoiceCard(CardType.Scissors));
  _bPaper.onClick.AddListener(()=>ChoiceCard(CardType.Paper));
}
private void Start()
{
  StartCoroutine(SpawnEnemy());
}
public void ChoiceCard(CardType card)
{
  if(!_isLocked){

     switch (card)
    {
        case CardType.Stone :
            if(Unit.CurrentManaScore>=2){
               _isLocked = true;
            StartCoroutine(UnlockButtonAfterDelay(1.5f));
              Unit.CurrentManaScore-=2;
          GameObject stone= Instantiate(_stone,_spawnPositionCard,Quaternion.identity);
          CharacterManager.AllyList.Add(stone.gameObject);
            }
            break;
        case CardType.Scissors:
        if(Unit.CurrentManaScore>=1){
           _isLocked = true;
            StartCoroutine(UnlockButtonAfterDelay(1.5f));
          Unit.CurrentManaScore-=1;
          GameObject scissors=  Instantiate(_scissors,_spawnPositionCard,Quaternion.identity);
          CharacterManager.AllyList.Add(scissors.gameObject);
            }
            break;
        case CardType.Paper:
        if(Unit.CurrentManaScore>=2){
           _isLocked = true;
            StartCoroutine(UnlockButtonAfterDelay(1.5f));
          Unit.CurrentManaScore-=2;
          GameObject paper= Instantiate(_paper,_spawnPositionCard,Quaternion.identity);
          CharacterManager.AllyList.Add(paper.gameObject);
            }
            break;
        default:
            Debug.LogError("Кнопка не назначенна");
            break;
    }

  }
}
private IEnumerator SpawnEnemy(){
  while(true){
    _spawnPositionCard = new Vector3(UnityEngine.Random.Range(-2f,2.15f), 1f, -15f);

    yield return new WaitForSeconds(5f);
  }

}
private IEnumerator UnlockButtonAfterDelay(float delay){
        yield return new WaitForSeconds(delay);
        _isLocked = false;
        
    }

}

public enum CardType
{
  Stone,
  Scissors,
  Paper
}










/*public abstract class StorageCard: MonoBehaviour
{
  [SerializeField] private GameObject Stone,Paper,Scissors;
  [SerializeField] private Button ButtonStone,ButtonScissors,ButtonPaper;
  [SerializeField] private Camera _camera;
  private Vector3 SpawnPositionCard;
  protected bool IsLocked = false;
  protected abstract GameObject CreateUnit(CardType card);
}
public class UnitCreator 
{
  



private void Start()
{
  
}

}

public enum CardType
{
  Stone,
  Scissors,
  Paper
}




/*public abstract class StorageCard: MonoBehaviour
{
  [SerializeField] private GameObject Stone,Paper,Scissors;
  [SerializeField] private Button ButtonStone,ButtonScissors,ButtonPaper;
  [SerializeField] private Camera _camera;
  private Vector3 SpawnPositionCard;
  protected bool IsLocked = false;
  protected abstract GameObject CreateUnit(CardType card);
}
public class UnitCreator 
{
  



private void Start()
{
  
}

}

public enum CardType
{
  Stone,
  Scissors,
  Paper
}













































/*
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public abstract class UnitCreator : MonoBehaviour
{
    [SerializeField] Camera _camera;
    [SerializeField] private Button BStone, BScissors, BPaper;
    private Vector3 T;
    protected bool IsLocked = false;

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            T = new Vector3(UnityEngine.Random.Range(-2f, 2.15f), 1f, -15f);
            yield return new WaitForSeconds(5f);
        }
    }

    private void Awake()
    {
        BStone.onClick.AddListener(() => ChoiceCard(CardType.Stone));
        BScissors.onClick.AddListener(() => ChoiceCard(CardType.Scissors));
        BPaper.onClick.AddListener(() => ChoiceCard(CardType.Paper));
    }

    private IEnumerator Start()
    {
        yield return StartCoroutine(SpawnEnemy());
    }

    protected abstract GameObject CreateUnit(CardType card);

    public void ChoiceCard(CardType card)
    {
        if (!IsLocked)
        {
            GameObject unit = CreateUnit(card);
            if (unit != null)
            {
                IsLocked = true;
                StartCoroutine(UnlockButtonAfterDelay(1.5f));
                Unit.currentManaScore -= unit.GetComponent<Unit>().ManaCost;
                CharacterManager.allyList.Add(unit);
            }
            else
            {
                Debug.LogError("Не удалось создать юнит для карты " + card);
            }
        }
    }

    private IEnumerator UnlockButtonAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        IsLocked = false;
    }
}

public class StoneCreator : UnitCreator
{
    public GameObject StonePrefab;
    
    protected override GameObject CreateUnit(CardType card)
    {
        if (card == CardType.Stone && Unit.currentManaScore >= 2)
        {
            return Instantiate(StonePrefab, T, Quaternion.identity);
        }
        return null;
    }
}

public class ScissorsCreator : UnitCreator
{
    public GameObject ScissorsPrefab;
    
    protected override GameObject CreateUnit(CardType card)
    {
        if (card == CardType.Scissors && Unit.currentManaScore >= 1)
        {
            return Instantiate(ScissorsPrefab, T, Quaternion.identity);
        }
        return null;
    }
}

public class PaperCreator : UnitCreator
{
    public GameObject PaperPrefab;
    
    protected override GameObject CreateUnit(CardType card)
    {
        if (card == CardType.Paper && Unit.currentManaScore >= 2)
        {
            return Instantiate(PaperPrefab, T, Quaternion.identity);
        }
        return null;
    }
}

public enum CardType
{
    Stone,
    Scissors,
    Paper
}

*/



// ОСНОВА
/*

using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UnitCreator : MonoBehaviour
{
  [SerializeField] private Camera _camera;
  [SerializeField] private Button BStone,BScissors,BPaper;
  private Vector3 SpawnPositionCard;
  public GameObject Stone;
  public GameObject Scissors;
  public GameObject Paper;
  bool IsLocked = false;
   

private IEnumerator SpawnEnemy(){
  while(true){
    SpawnPositionCard = new Vector3(UnityEngine.Random.Range(-2f,2.15f), 1f, -15f);

    yield return new WaitForSeconds(5f);
  }

}
private void Awake() {
  BStone.onClick.AddListener(()=>ChoiceCard(CardType.Stone));
  BScissors.onClick.AddListener(()=>ChoiceCard(CardType.Scissors));
  BPaper.onClick.AddListener(()=>ChoiceCard(CardType.Paper));
}
private void Start()
{
  StartCoroutine(SpawnEnemy());
}
public void ChoiceCard(CardType card)
{
  if(!IsLocked){

     switch (card)
    {
        case CardType.Stone :
            if(Unit.currentManaScore>=2){
               IsLocked = true;
            StartCoroutine(UnlockButtonAfterDelay(1.5f));
              Unit.currentManaScore-=2;
          GameObject stone= Instantiate(Stone,SpawnPositionCard,Quaternion.identity);
          CharacterManager.allyList.Add(stone.gameObject);
            }
            break;
        case CardType.Scissors:
        if(Unit.currentManaScore>=1){
           IsLocked = true;
            StartCoroutine(UnlockButtonAfterDelay(1.5f));
          Unit.currentManaScore-=1;
          GameObject scissors=  Instantiate(Scissors,SpawnPositionCard,Quaternion.identity);
          CharacterManager.allyList.Add(scissors.gameObject);
            }
            break;
        case CardType.Paper:
        if(Unit.currentManaScore>=2){
           IsLocked = true;
            StartCoroutine(UnlockButtonAfterDelay(1.5f));
          Unit.currentManaScore-=2;
          GameObject paper= Instantiate(Paper,SpawnPositionCard,Quaternion.identity);
          CharacterManager.allyList.Add(paper.gameObject);
            }
            break;
        default:
            Debug.LogError("Кнопка не назначенна");
            break;
    }

  }
}

private IEnumerator UnlockButtonAfterDelay(float delay){
        yield return new WaitForSeconds(delay);
        IsLocked = false;
        
    }

}

public enum CardType
{
  Stone,
  Scissors,
  Paper
}





*/




/*public abstract class StorageCard: MonoBehaviour
{
  [SerializeField] private GameObject Stone,Paper,Scissors;
  [SerializeField] private Button ButtonStone,ButtonScissors,ButtonPaper;
  [SerializeField] private Camera _camera;
  private Vector3 SpawnPositionCard;
  protected bool IsLocked = false;
  protected abstract GameObject CreateUnit(CardType card);
}
public class UnitCreator 
{
  



private void Start()
{
  
}

}

public enum CardType
{
  Stone,
  Scissors,
  Paper
}
*/