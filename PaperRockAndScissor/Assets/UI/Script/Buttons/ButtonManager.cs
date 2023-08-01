using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
 public enum ButtonType
 {
    Play,
    Options,
    Quit
 }

public class ButtonManager : MonoBehaviour
{
[SerializeField] private Button _play;
[SerializeField] private Button _options;
[SerializeField] private Button _quit;

private void Start()
    {
      _play.onClick.AddListener(()=> Menu(ButtonType.Play));
      _options.onClick.AddListener(()=> Menu(ButtonType.Options));
      _quit.onClick.AddListener(()=> Menu(ButtonType.Quit));
    }

private void Menu(ButtonType buttonType){
     switch (buttonType)
    {
        case ButtonType.Play:
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
           break;
        case ButtonType.Quit:
            Debug.Log("Game done");
            Application.Quit();
            break;
        case ButtonType.Options:
            break;
        default:
            Debug.LogError("Кнопка не назначенна");
            break;
    }
   }
}
