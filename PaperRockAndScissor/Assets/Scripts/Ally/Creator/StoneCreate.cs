using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneCreate : MonoBehaviour
{
    [SerializeField] GameObject Stone;
    bool IsLocked = false;
    
    public void CreateStonePrefab(GameObject Stone)
    {
        if(!IsLocked&& Unit.currentManaScore>=2)
        {
            Unit.currentManaScore-=2;
            GameObject stone =Instantiate(Stone,new Vector3(UnityEngine.Random.Range(-2f,2.15f), 1f, -15f),Quaternion.identity);
            CharacterManager.allyList.Add(stone.gameObject);
            IsLocked = true;
            StartCoroutine(IsLockedButton());
            
        }   
        
    }
    IEnumerator IsLockedButton()
    {
        yield return new WaitForSeconds(1.5f);
        IsLocked = false;
    }

}
