using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnner : MonoBehaviour
{
    public GameObject fireball;
    public void Spawn()
    {
           Instantiate(fireball,transform.position,transform.rotation);
    }
}
