using ADS;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class Timer : MonoBehaviour
{
    [FormerlySerializedAs("menu")] [SerializeField] private GameObject _menu;
    [FormerlySerializedAs("lose")] [SerializeField] private GameObject _lose;
    [FormerlySerializedAs("win")] [SerializeField] private GameObject _win;
    [FormerlySerializedAs("tie")] [SerializeField] private GameObject _tie;
    [FormerlySerializedAs("timerText")] [SerializeField] private TMP_Text _timerText;
    private float _timeStart = 90f;
    private const float LowTime = 0;
    [FormerlySerializedAs("ad")] public PassAds _ad;
    private bool _showAds = false;

    void Start()
    {
        _timerText.text = _timeStart.ToString();
    }

    void Update()
    {
        _timeStart -= Time.deltaTime;
        _timerText.text = Mathf.Round(_timeStart).ToString();

        if (_timeStart <= LowTime || EnemyCrush.HealPoint <= LowTime || TowerManager.HealPointTower <= LowTime)
        {
            _timeStart = LowTime;
            _menu.SetActive(true);

            if (EnemyCrush.HealPoint > TowerManager.HealPointTower)
                _lose.SetActive(true);
            else if (EnemyCrush.HealPoint < TowerManager.HealPointTower)
                _win.SetActive(true);
            else
                _tie.SetActive(true);

            if (!_showAds)
            {
                _showAds = true;
                _ad.ShowAd();
            }
        }
    }
}

