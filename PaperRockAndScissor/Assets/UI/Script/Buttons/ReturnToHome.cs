using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ReturnToHome : MonoBehaviour
{
   public void ReturnHome(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex-1);
    }
}
