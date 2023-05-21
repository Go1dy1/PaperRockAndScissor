using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartMenu : MonoBehaviour
{
    public enum ButtonType{
    Restart,
    Home,
    }
    [SerializeField]private Button Restart, Home;

    void Start()
    {
        Restart.onClick.AddListener(()=>LEVELS(ButtonType.Restart));
        Home.onClick.AddListener(()=>LEVELS(ButtonType.Home));
    }

public void LEVELS(ButtonType buttonType){
     switch (buttonType)
    {
        case ButtonType.Restart:
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+0);
           Time.timeScale = 1f;
            break;
        case ButtonType.Home:
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
            Time.timeScale = 1f;
            break;
        default:
            Debug.LogError("Кнопка не назначенна");
            break;
    }
}
   
}
