using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
  public ParticleSystem explosion;
  public Playermovement pm;
  public int lives=3;
  public float ImmortalTime=3.0f;
  public float RespawnTime=2.0f;
  public int Score=0;

  public Text ScoreText,noOfLife;
  public Image l1,l2,l3;


  public void AstroidDied(Astroids astroid)
  {
    this.explosion.transform.position=astroid.transform.position;
    this.explosion.Play();

    if(astroid.size<0.8)
    {
      this.Score+=100;
    }
    else if(astroid.size<1.30f)
    {
      this.Score+=50;
    }else{
      this.Score+=10;
    }
    setScore();
  }

  public void PlayerDied()
  {
      this.explosion.transform.position=this.pm.transform.position;
      this.explosion.Play();
      this.lives--;
      noOfLife.text=lives.ToString();
      SetLive();
      if(lives<=0)
      {
        
        Invoke(nameof(GameOver),2);
       
      }
      else{
          Invoke(nameof(Respawn),RespawnTime);
      }
  }

  public void Respawn()
  {
    pm.transform.position=Vector3.zero;
    pm.gameObject.layer=LayerMask.NameToLayer("Immortal");   
    pm.gameObject.SetActive(true);
    Invoke(nameof(BackToHuman),ImmortalTime);

  }
  private void BackToHuman()
  {
      pm.gameObject.layer=LayerMask.NameToLayer("player");
  }

  public void GameOver()
  {
    this.Score=0;
    this.lives=3;
    Respawn();
    noOfLife.text=lives.ToString();
    setScore();
    SetLive();
  }

  private void setScore()
  {
    ScoreText.text=Score.ToString();
  }
  private void SetLive()
  {
    if(lives==3)
    {
        l1.gameObject.SetActive(true);
        l2.gameObject.SetActive(true);
        l3.gameObject.SetActive(true);
        
    }else if(lives==2)
    {
        l1.gameObject.SetActive(false);
        
    }
    else if(lives==1)
    {
        l1.gameObject.SetActive(false);
        l2.gameObject.SetActive(false);
        
    }
    else{
         l1.gameObject.SetActive(false);
         l2.gameObject.SetActive(false);
         l3.gameObject.SetActive(false);
    }
  }
}
