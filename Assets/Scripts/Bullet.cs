using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rBody2D;

    public float bulletSpeed = 5;

    SFXManager sfxManager;
    SoundManager soundManager;


    // Start is called before the first frame update
    void Start()
    {
        rBody2D = GetComponent<Rigidbody2D>();

        rBody2D.AddForce(transform.right * bulletSpeed, ForceMode2D.Impulse);
        sfxManager = GameObject.Find("SFXManager"). GetComponent<SFXManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
       if(collider.gameObject.layer == 6)
       {
        Zombie zombie = collider.gameObject.GetComponent<Zombie>();
        zombie.Die();
        sfxManager.ZombieDeath();
       } 

       if(collider.gameObject.tag == "Player" || collider.gameObject.tag == "Bullet")
       {
            return;
       }
       Destroy(this.gameObject); 

    }
}
