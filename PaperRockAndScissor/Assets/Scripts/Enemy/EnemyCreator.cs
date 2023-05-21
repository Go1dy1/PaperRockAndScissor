using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
private Vector3 T ;
[SerializeField] GameObject stone;
[SerializeField] GameObject paper;
[SerializeField] GameObject scissors;
internal CardType cardType;

//= new Vector3(0,0.44f,2.6f)
private IEnumerator Start() {
    yield return new WaitForSeconds(1f);
    yield return StartCoroutine(SpawnEnemy());
}


    void Update()
    {
      //  StartCoroutine("GetRandomCardType");
 
   
       
    }

    public GameObject GetRandomCardType(CardType cardType,Vector3 T){
    switch (cardType){   
        case CardType.Stone:
        GameObject Stone = Instantiate(stone,T,Quaternion.identity);
        CharacterManager.enemyList.Add(Stone.gameObject);
        return Stone;
        case CardType.Paper:
        GameObject Paper = Instantiate(paper,T,Quaternion.identity);
        CharacterManager.enemyList.Add(Paper.gameObject);
        return Paper;
        case CardType.Scissors:
        GameObject Scissors = Instantiate(scissors,T,Quaternion.identity);
        CharacterManager.enemyList.Add(Scissors.gameObject);
        return Scissors;
           default: Debug.LogError("Неизвестный тип карты");
           return null;
   }
    }
private IEnumerator SpawnEnemy()
{
    while (true)
    {
        // Генерируем случайный тип карты и позицию спауна
        CardType cardType = (CardType)UnityEngine.Random.Range(0, 3);
        Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-6.4f, 5.75f), 0.44f, UnityEngine.Random.Range(-2.5f, 7.62f));

        // Создаем новый объект в зависимости от типа карты
        GameObject newEnemy = GetRandomCardType(cardType, spawnPosition);

        // Ждем 5 секунд перед созданием следующего объекта
        yield return new WaitForSeconds(5f);
    }
}

}