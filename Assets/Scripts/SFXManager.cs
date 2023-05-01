using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioClip characterDeath;

    public AudioClip zombieDeath;

    private AudioSource source;

    public AudioClip getGun;

    // Start is called before the first frame update
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    public void ZombieDeath()
    {
        source.PlayOneShot(zombieDeath);
    }
    
    public void CharacterDeath()
    {
        source.PlayOneShot(characterDeath);
    }
    public void GetGun()
    {
        source.PlayOneShot(getGun);
    }
}
