using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private Transform target;
    public Vector3 offset;
    // Vectores para limitar el movimiento de la camara en Y y X
    public Vector2 limitX;
    public Vector2 limitY;

    public float interpolationRatio; 

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Character").GetComponent<Transform>(); 
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();     
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(target != null && gameManager.isGameOver == false)
        {
            transform.position = target.position + offset;
            // posicion deseada de la camara
            Vector3 desiredPosition = target.position + offset;

            // limitamos en la posicion x
            float clampX = Mathf.Clamp(desiredPosition.x, limitX.x, limitX.y);

            // limitamos en la posicion y
            float clampY = Mathf.Clamp(desiredPosition.y, limitY.x, limitY.y);

            // posicion limitada en X e Y
            Vector3 clampedPosition = new Vector3(clampX, clampY, desiredPosition.z);

            Vector3 lerpedPosition = Vector3.Lerp(transform.position, clampedPosition, interpolationRatio);
        
            transform.position = lerpedPosition;
        }
    }
}
