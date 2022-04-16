using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backGroundMusic : MonoBehaviour
{
   private static backGroundMusic bm;
    void Awake()
    {
        if(bm==null)
        {
            bm= this;
            DontDestroyOnLoad(bm);
        }
        else{
            Destroy(gameObject);
        }
    }
}
