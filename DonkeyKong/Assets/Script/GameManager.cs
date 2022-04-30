using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public int lifes = 3;
    public GameObject hitsound;
    public Animator anime;
    

    void Start()
    {
       
       // anime.SetTrigger("Start");

    }
    public void Restart()
    {    
        lifes= lifes-1;

        if(lifes==0){
            GemCollector.currentGem=0;
            Instantiate(hitsound,transform.position,transform.rotation);
            StartCoroutine(Pause());
            
        }
       

    }
    public  void NextLevel()
    {
        if((SceneManager.GetActiveScene().buildIndex+1<SceneManager.sceneCountInBuildSettings) && GemCollector.currentGem==3)
        {
          GemCollector.currentGem=0;
          SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        else{
            if(GemCollector.currentGem==3)
            {
                GemCollector.currentGem=0;
                SceneManager.LoadScene(0);
            }
        }
       
    }

    public IEnumerator Pause()
    {
        anime.SetTrigger("end");
        FindObjectOfType<PlayerMovement>().enabled=false;
        FindObjectOfType<Spawner>().enabled=false;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

   


}
