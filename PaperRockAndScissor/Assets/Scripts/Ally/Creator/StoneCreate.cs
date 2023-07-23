using System.Collections;
using Storage;
using UnityEngine;
using UnityEngine.Serialization;

public class StoneCreate : MonoBehaviour
{
    [FormerlySerializedAs("Stone")] [SerializeField] GameObject _stone;
    bool _isLocked = false;
    
    public void CreateStonePrefab(GameObject _stone)
    {
        if(!_isLocked&& Unit.CurrentManaScore>=2)
        {
            Unit.CurrentManaScore-=2;
            GameObject stonePrefab =Instantiate(_stone,new Vector3(UnityEngine.Random.Range(-2f,2.15f), 1f, -15f),Quaternion.identity);
            CharacterManager.AllyList.Add(stonePrefab.gameObject);
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
