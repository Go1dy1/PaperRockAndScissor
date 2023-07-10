using System.Collections;
using UnityEngine;
using TMPro;

public class Unit : MonoBehaviour
{
    [SerializeField] private TMP_Text collectedManaText;
    private const int maxManaScore = 10;
    internal static int currentManaScore = 1;
    private float scoreSeconds = 3f;

    private IEnumerator Start()
    {
        yield return StartCoroutine(ManaScore());
    }

    private IEnumerator ManaScore()
    {
        while (true)
        {
            if (currentManaScore < maxManaScore)
            {
                currentManaScore++;
            }
            yield return new WaitForSeconds(scoreSeconds);
        }
    }

    private void Update()
    {
        collectedManaText.text = currentManaScore.ToString();
    }
}

