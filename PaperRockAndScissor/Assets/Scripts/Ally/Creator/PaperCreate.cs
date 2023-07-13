using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperCreate : MonoBehaviour
{
    [SerializeField] GameObject Paper;
    bool IsLocked = false;
    
    public void CreatePaperPrefab(GameObject Stone)
    {
        if(!IsLocked && Unit.currentManaScore>=2)
        {
            Unit.currentManaScore-=2;
            GameObject paper =Instantiate(Paper,new Vector3(UnityEngine.Random.Range(-2f,2.15f), 1f, -15f),Quaternion.identity);
            CharacterManager.allyList.Add(paper.gameObject);
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
