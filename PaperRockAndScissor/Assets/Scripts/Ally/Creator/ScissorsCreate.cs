using System.Collections;
using Storage;
using UnityEngine;
using UnityEngine.Serialization;

public class ScissorsCreate : MonoBehaviour
{
    [FormerlySerializedAs("Scissors")] [SerializeField] GameObject _scissors;
    bool _isLocked = false;
    
    public void CreateScissorsPrefab(GameObject stone)
    {
        if(!_isLocked&& Unit.CurrentManaScore>=1)
        {
            Unit.CurrentManaScore--;
            GameObject scissors =Instantiate(_scissors,new Vector3(UnityEngine.Random.Range(-2f,2.15f), 1f, -15f),Quaternion.identity);
            CharacterManager.AllyList.Add(scissors.gameObject);
            _isLocked = true;
            StartCoroutine(IsLockedButton());
            
        }   
        
    }
    IEnumerator IsLockedButton()
    {
        yield return new WaitForSeconds(1.5f);
        _isLocked = false;
    }

}
