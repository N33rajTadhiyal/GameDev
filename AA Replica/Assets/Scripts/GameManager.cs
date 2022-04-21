using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
  private bool Ended=false;
  public AimRotator Ar;
  public Spawnner sp;
  public Animator anime;

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
}
