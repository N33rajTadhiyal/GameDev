using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
     public GameObject prefab;
     public int max=4,min=2;

     private void Start()
     {
       SPawn();
     }

     public void SPawn()
     {
         Instantiate(prefab,transform.position,transform.rotation);
         Invoke(nameof(SPawn),Random.Range(min,max));

     }

}
