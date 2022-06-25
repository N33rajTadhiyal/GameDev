using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenue : MonoBehaviour
{
   public void Play()
   {
       SceneManager.LoadScene(1);
   }
   public void Quit()
   {
       Application.Quit();
   }
}
