using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
 public enum ButtonType{
    Play,
    Options,
    Quit
 }

public class ButtonManager : MonoBehaviour
{
[FormerlySerializedAs("Play")] [SerializeField] private Button _play;
[FormerlySerializedAs("Options")] [SerializeField] private Button _options;
[FormerlySerializedAs("Quit")] [SerializeField] private Button _quit;

void Start()
    {
      _play.onClick.AddListener(()=> Menu(ButtonType.Play));
      _options.onClick.AddListener(()=> Menu(ButtonType.Options));
      _quit.onClick.AddListener(()=> Menu(ButtonType.Quit));
    }

   public void Menu(ButtonType buttonType){
     switch (buttonType)
    {
        case ButtonType.Play:
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            break;
        case ButtonType.Options:
           // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+2);
            break;
        case ButtonType.Quit:
            Debug.Log("Game done");
            Application.Quit();
            break;
        default:
            Debug.LogError("Кнопка не назначенна");
            break;
    }
   }
}
