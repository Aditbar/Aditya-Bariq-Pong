using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpControl : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public float magnitude = 2;
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision == ball)
        {
            ball.GetComponent<BallControl>().ActivatePUSpeedUp(magnitude);
            manager.RemovePowerUp(gameObject);
        }    
    }
}
