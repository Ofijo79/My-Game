using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isGameOver;
    public bool canShoot;
    public float powerUpBullets = 10;
    public float powerUpScore = 0;

    private int score = 10;
    public Text bulletText;

    // Start is called before the first frame update
    /* void Start()
    {
        score = 0;
    } */

    public void Addbullets()
    {
        score--;
        bulletText.text = "x" + score;
    }

    // Update is called once per frame
    void Update()
    {
        ShootPowerUp();
    }
    void ShootPowerUp()
    {
        if(canShoot)
        {
            if(powerUpScore <= powerUpBullets)
            {
                powerUpScore += Time.deltaTime;
            }
            else
            {
                canShoot = false;
                powerUpScore = 0;
            }
        }
    }
}
