using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int score=0;
    private float timer;   
    public Text Score;  

    private bool gameOver=false;    

    public void start()
    {
        
       Score.text=score.ToString();     
      
        
    }
    public void Update()
    {
        if(gameOver!=true)
        {
            timer+=Time.deltaTime;
        if(timer>1f)
        {
            score++;
            Score.text=score.ToString();
            PlayerPrefs.SetInt("HighScore",score);
            timer=0;
        }
        }
    }
public void GameOver(int Id)
{
    // FindObjectOfType<SCoreSetter>().point=score;
    SceneManager.LoadScene(Id);
    score=0;
   
}
public void Reset()
{
    PlayerPrefs.DeleteKey("HighScore");
}

}
