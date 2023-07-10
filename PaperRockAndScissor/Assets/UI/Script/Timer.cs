using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject menu, lose, win, tie;
    [SerializeField] private TMP_Text timerText;
    private float timeStart = 90f;
    private const float lowTime = 0;
    public PassADS ad;
    private bool showAds = false;

    void Start()
    {
        timerText.text = timeStart.ToString();
    }

    void Update()
    {
        timeStart -= Time.deltaTime;
        timerText.text = Mathf.Round(timeStart).ToString();

        if (timeStart <= lowTime || EnemyCrush.HealPoint <= lowTime || TowerManager.healPointTower <= lowTime)
        {
            timeStart = lowTime;
            menu.SetActive(true);

            if (EnemyCrush.HealPoint > TowerManager.healPointTower)
                lose.SetActive(true);
            else if (EnemyCrush.HealPoint < TowerManager.healPointTower)
                win.SetActive(true);
            else
                tie.SetActive(true);

            if (!showAds)
            {
                showAds = true;
                ad.ShowAd();
            }
        }
    }
}

