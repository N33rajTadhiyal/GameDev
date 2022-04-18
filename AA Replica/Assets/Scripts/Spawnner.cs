using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    public GameObject prefab;


    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Spawn();
        }
    }
    public void Spawn()
    {
        Instantiate(prefab,transform.position,transform.rotation);
    }
}
