using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SCoreSetter : MonoBehaviour
{
    public Text FinalWords;
    public int point;
    // Start is called before the first frame update
    void Start()
    {
        Set();
    }
    public void Set()
    {
      
       FinalWords.text="Your Score:"+PlayerPrefs.GetInt("HighScore").ToString();
    }



}
