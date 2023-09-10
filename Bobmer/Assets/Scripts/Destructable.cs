using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    public float time=1.50f;
    
    [Range(0.0f,1.0f)]
    public float SpawnRate =0.2f;
    public GameObject[] SpawnableItms;
    void Start()
    {
        Destroy(this.gameObject,time);
    }
   
    private void OnDestroy()
    {
      if(SpawnableItms.Length>0 && Random.value< SpawnRate)
      {

        int randomeIndex=Random.Range(0,SpawnableItms.Length);
        Instantiate(SpawnableItms[randomeIndex],transform.position,Quaternion.identity);
      }
    }

   
}
