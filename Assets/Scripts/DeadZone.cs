using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    BoxCollider2D boxCollider;
    SFXManager sfxManager;
    SoundManager soundManager;
    
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        
        sfxManager = GameObject.Find("SFXManager"). GetComponent<SFXManager>();
        soundManager = GameObject.Find("SoundManager").GetComponent<SoundManager>();

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Destroy(collider.gameObject);
            sfxManager.CharacterDeath();
            soundManager.StopBGM();
        }
    }
}
