using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
 public enum ButtonType{
    Play,
    Options,
    Quit
 }

public class ButtonManager : MonoBehaviour
{
[SerializeField] private Button Play,Options,Quit;
    
    void Start()
    {
      Play.onClick.AddListener(()=> Menu(ButtonType.Play));
      Options.onClick.AddListener(()=> Menu(ButtonType.Options));
      Quit.onClick.AddListener(()=> Menu(ButtonType.Quit));
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
