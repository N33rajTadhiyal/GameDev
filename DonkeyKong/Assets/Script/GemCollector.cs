using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemCollector : MonoBehaviour
{
  public Image[] GemArray;
  public Sprite fullGem;
  public Sprite EmptyGem;
   
  public int MaxGem=3;
  public static int currentGem=0;

  void Update()
  {
      
      GemSystem();
  }
  


  public  void GemSystem()
  {
      for(int i =0;i< GemArray.Length;i++)
      {
         if(i<currentGem)
        {
         GemArray[i].sprite=fullGem;
        }
        else{
          GemArray[i].sprite=EmptyGem;
        }
        if(i<MaxGem)
        {
           GemArray[i].enabled=true;
        }
        else{
             GemArray[i].enabled=false;
        }
      }
  }


}
