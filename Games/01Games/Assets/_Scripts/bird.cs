using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bird : MonoBehaviour
{
    public GameObject birddieeffect;
    public static int birdAlive = 0;
    public AudioSource DieSound;


    void Start()
    {
        birdAlive++;
    }
    void OnCollisionEnter2D(Collision2D colinfo)
    {
        if (colinfo.gameObject.tag=="piggy")
        {
            DieSound.Play();
            Die();
            
        }
    }
    void Die()
    {
        Instantiate(birddieeffect, transform.position, Quaternion.identity);
        birdAlive--;
        

        Debug.Log("WON!");
        Destroy(gameObject,0.3f);
        

            
    }
}
