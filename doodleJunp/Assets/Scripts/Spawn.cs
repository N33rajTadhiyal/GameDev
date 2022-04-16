using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
   public GameObject prefab;
   public float SpawnRate=1f;
   public float invoke=1f;
   public float minpos=-1,maxpos=1;

   
    public void OnEnable()
   {
        InvokeRepeating(nameof(spawn),SpawnRate,invoke);
   }
     public void OnDesable()
   {
       CancelInvoke(nameof(spawn));
   }
   public void spawn()
    {
         GameObject log=Instantiate(prefab,transform.position,Quaternion.identity);
         log.transform.position+=Vector3.right*Random.Range(minpos,maxpos);
     
    }
}
