using ADS;
using Ally.Tower;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class Timer : MonoBehaviour
{
[SerializeField] private GameObject _menu;
[SerializeField] private GameObject _lose;
[SerializeField] private GameObject _win;
[SerializeField] private GameObject _tie;
[SerializeField] private TMP_Text _timerText;
[SerializeField] private PassAds _ad;
[SerializeField] private float _timeStart = 90f;
    private const float LowTime = 0;
    private bool _showAds;

     void Start()
    {
        _timerText.text = _timeStart.ToString();
    }

    private void Update()
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

