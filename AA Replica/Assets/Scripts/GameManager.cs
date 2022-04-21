using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  private bool Ended=false;
  public AimRotator Ar;
  public Spawnner sp;
  public Animator anime;
  public GameObject aim,shooter ;

  public Button re,qui;

  public Text Tex;

  void Update()
  {
    if(ScoreSetter.score==15)
  {
    Win();
  }
  }
  public void End()
  {
      if(Ended)
      {
          return;
      }
      
      anime.SetBool("Out",true);

      Ar.enabled=false;
      sp.enabled=false;

      Ended=true;     
  }
  public void Restart()
  {
     SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }

  public void Win()
  {
    aim.SetActive(false);
    shooter.SetActive(false);   
    
    anime.SetBool("winn",true);
    StartCoroutine(Change());
     
  }

  public void Replay()
  {
  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
  }

  public void Quit()
  {
    Application.Quit();
  }



  public IEnumerator Change()
  {
    yield return new WaitForSeconds(1);
    SceneManager.LoadScene(2);
  }

}
