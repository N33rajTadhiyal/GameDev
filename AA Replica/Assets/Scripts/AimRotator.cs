using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimRotator : MonoBehaviour
{
      public float speed=100f;
      public Animator anime;

  

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f,0f,speed*Time.deltaTime);
        
        if(ScoreSetter.score==5)
        {
            anime.SetBool("lv1",true);
        }
        else if( ScoreSetter.score==10)
        {
            anime.SetBool("lv1",false);
            anime.SetBool("lv2",true);
        }
    }

}
