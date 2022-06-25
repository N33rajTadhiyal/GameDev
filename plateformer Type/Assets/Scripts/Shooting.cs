using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform spawnpoint;
    public GameObject fireball;

    public void Shoot()
    {
        //GameObject bullets = Instantiate(fireball,spawnpoint.position,spawnpoint.rotation);
        StartCoroutine(pause());
    }
    public IEnumerator pause()
    {
                yield return new WaitForSeconds(0.5f);
                GameObject bullets = Instantiate(fireball,spawnpoint.position,spawnpoint.rotation);
    }


}
