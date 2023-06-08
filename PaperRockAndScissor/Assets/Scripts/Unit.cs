using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Unit : MonoBehaviour
{
 [SerializeField] TMP_Text CollectedMana;
 private float ScoreSeconds = 3f;

 static internal int CurrentManaScore =1;  
 private const int MaxScore = 10;
 private IEnumerator Start() {
    yield return StartCoroutine(ManaScore());;
}
void Awake()
{
    
}

    private IEnumerator ManaScore() {
        while(true){ 
        if(CurrentManaScore<MaxScore){
            CurrentManaScore =CurrentManaScore+1;
        }
        yield return new WaitForSeconds(ScoreSeconds);
        }
    }
    void Update()
    {
        CollectedMana.text= CurrentManaScore.ToString();
    }

}
