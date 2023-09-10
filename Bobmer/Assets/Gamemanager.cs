using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gamemanager : MonoBehaviour
{
   public GameObject[] players;

   public void CheckWins()
   {
       int alive=0;
       foreach(GameObject player in players )
       {
           if(player.activeSelf)
           {
               alive++;
           }
       }
       if(alive<=1)
       {
         Invoke(nameof(NewRound),3);
       }
   }

   private void NewRound()
   {
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
   }

}
