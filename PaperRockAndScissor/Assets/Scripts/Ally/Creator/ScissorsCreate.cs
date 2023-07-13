using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScissorsCreate : MonoBehaviour
{
    [SerializeField] GameObject Scissors;
    bool IsLocked = false;
    
    public void CreateScissorsPrefab(GameObject Stone)
    {
        if(!IsLocked&& Unit.currentManaScore>=1)
        {
            Unit.currentManaScore--;
            GameObject scissors =Instantiate(Scissors,new Vector3(UnityEngine.Random.Range(-2f,2.15f), 1f, -15f),Quaternion.identity);
            CharacterManager.allyList.Add(scissors.gameObject);
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
