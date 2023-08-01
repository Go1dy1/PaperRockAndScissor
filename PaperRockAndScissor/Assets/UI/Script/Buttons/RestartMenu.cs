using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class RestartMenu : MonoBehaviour
{
    private enum ButtonType
    {
    Restart,
    Home,
    }
    
    [SerializeField]private Button _restart;
    [SerializeField]private Button _home;

    private void Start()
    {
        _restart.onClick.AddListener(()=>Levels(ButtonType.Restart));
        _home.onClick.AddListener(()=>Levels(ButtonType.Home));
    }

    private void Levels(ButtonType buttonType)
    {
        switch (buttonType)
        {
        case ButtonType.Restart:
        Time.timeScale = 1f;
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+0);
           
            break;
        case ButtonType.Home:
        Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
            
            break;
        default:
            Debug.LogError("Кнопка не назначенна");
            break;
        }   
    }
   
}