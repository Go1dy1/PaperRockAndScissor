using System;
using System.Collections;
using System.Collections.Generic;
using Storage;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyCreator : MonoBehaviour
{
[FormerlySerializedAs("stone")] [SerializeField] GameObject _stone;
[FormerlySerializedAs("paper")] [SerializeField] GameObject _paper;
[FormerlySerializedAs("scissors")] [SerializeField] GameObject _scissors;
//internal CardType cardType;

internal static float TimetoSpawn = 5f;

private IEnumerator Start() {
    yield return new WaitForSeconds(1f);
    yield return StartCoroutine(SpawnEnemy());
}


    public GameObject GetRandomCardType(CardType cardType,Vector3 T){
    switch (cardType){   
        case CardType.Stone:
        GameObject stone = Instantiate(_stone,T,Quaternion.identity);
        CharacterManager.EnemyList.Add(stone.gameObject);
        return stone;
        case CardType.Paper:
        GameObject paper = Instantiate(_paper,T,Quaternion.identity);
        CharacterManager.EnemyList.Add(paper.gameObject);
        return paper;
        case CardType.Scissors:
        GameObject scissors = Instantiate(_scissors,T,Quaternion.identity);
        CharacterManager.EnemyList.Add(scissors.gameObject);
        return scissors;
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

        // Ждем TimetoSpawn секунд перед созданием следующего объекта
        yield return new WaitForSeconds(TimetoSpawn);
    }
}

}