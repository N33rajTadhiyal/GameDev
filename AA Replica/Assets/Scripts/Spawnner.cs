using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    public GameObject prefab,sound;



    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Spawn();
            Instantiate(sound,transform.position,transform.rotation);
        }
    }
    public void Spawn()
    {
        Instantiate(prefab,transform.position,transform.rotation);
    }
}
