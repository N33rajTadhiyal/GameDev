using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Pause : MonoBehaviour
{
    public bool stop=false;
    public Text word;
    // Start is called before the first frame update
    void Start()
    {
        word.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
          if(Input.GetKeyDown(KeyCode.A) && stop==false)
          {
              PauseMenue();
          }
          else if(Input.GetKeyDown(KeyCode.A) && stop==true)
          {
              unpause();
          }
    }

    public void PauseMenue()
    {
        stop=true;
        Time.timeScale=0;
        word.gameObject.SetActive(true);
    }

    public void unpause()
    {
        stop=false;
        Time.timeScale=1;
        word.gameObject.SetActive(false);
    }
}
