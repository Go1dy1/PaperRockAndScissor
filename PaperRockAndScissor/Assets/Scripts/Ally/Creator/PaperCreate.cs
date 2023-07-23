using System.Collections;
using Storage;
using UnityEngine;
using UnityEngine.Serialization;

public class PaperCreate : MonoBehaviour
{
    [FormerlySerializedAs("Paper")] [SerializeField] GameObject _paper;
    bool _isLocked = false;
    
    public void CreatePaperPrefab(GameObject stone)
    {
        if(!_isLocked && Unit.CurrentManaScore>=2)
        {
            Unit.CurrentManaScore-=2;
            GameObject paper =Instantiate(_paper,new Vector3(UnityEngine.Random.Range(-2f,2.15f), 1f, -15f),Quaternion.identity);
            CharacterManager.AllyList.Add(paper.gameObject);
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
