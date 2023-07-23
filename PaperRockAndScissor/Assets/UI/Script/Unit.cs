using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class Unit : MonoBehaviour
{
    [FormerlySerializedAs("collectedManaText")] [SerializeField] private TMP_Text _collectedManaText;
    private const int MaxManaScore = 10;
    internal static int CurrentManaScore = 1;
    private float _scoreSeconds = 3f;

    private IEnumerator Start()
    {
        yield return StartCoroutine(ManaScore());
    }

    private IEnumerator ManaScore()
    {
        while (true)
        {
            if (CurrentManaScore < MaxManaScore)
            {
                CurrentManaScore++;
            }
            yield return new WaitForSeconds(_scoreSeconds);
        }
    }

    private void Update()
    {
        _collectedManaText.text = CurrentManaScore.ToString();
    }
}

