using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    public bool canShoot;
    public int powerUpBullets;
    //public float powerUpScore = 0;

    //private int score = 10;
    public Text bulletText;

    // Start is called before the first frame update
    /* void Start()
    {
        score = 0;
    } */

    public void Start() 
    {
        powerUpBullets = 0;
        bulletText.text = "x" + powerUpBullets;
    }

    public void GameOver()
    {
        isGameOver = true;

        // LoadScene();

        //Invoke("LoadScene", 2.5f);

        // empezar corutina
        StartCoroutine("LoadScene");
    }
    
    
    public void Reload()
    {
        powerUpBullets += 10;
        bulletText.text = "x" + powerUpBullets;
    }

    public void Shoot()
    {
        powerUpBullets --;
        bulletText.text = "x" + powerUpBullets;
    }

    

    public void ShootPowerUp()
    {
        if(powerUpBullets > 0)
        {
            /*if(powerUpScore <= powerUpBullets)
            {
                powerUpScore += Time.deltaTime;
            }
            else
            {
                canShoot = false;
                powerUpScore = 0;
            }*/

            Shoot();
        }
    }
}
