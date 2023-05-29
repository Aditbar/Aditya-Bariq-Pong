using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleSpeedUpControl : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public GameObject leftPaddle;
    public GameObject rightPaddle;
    public int magnitude = 2;
    public int duration = 5;
    private bool isPowerUpActive = false;
    private float powerUpTimer = 0;
    private GameObject targetPaddle;

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            bool isBallMovingRight = ball.GetComponent<Rigidbody2D>().velocity.x > 0;
            targetPaddle = isBallMovingRight ? leftPaddle : rightPaddle;

            if (!targetPaddle.GetComponent<PaddleControl>().isSpeedUp)
            {
                // Debug.Log($"{targetPaddle} cepet!!!");
                targetPaddle.GetComponent<PaddleControl>().isSpeedUp = true;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine(DeactivatePowerUp(targetPaddle, duration));
                isPowerUpActive = true;
                powerUpTimer = duration;
            }
            else
            {
                manager.RemovePowerUp(gameObject);
            }
        }
    }

    private IEnumerator DeactivatePowerUp(GameObject targetPaddle, int duration)
    {
        Debug.Log($"{targetPaddle.name} PU Paddle Speed Up activated");
        targetPaddle.GetComponent<PaddleControl>().IncreasePaddleSpeed(magnitude);
        yield return new WaitForSeconds(duration);
        targetPaddle.GetComponent<PaddleControl>().DecreasePaddleSpeed(magnitude);
        targetPaddle.GetComponent<PaddleControl>().isSpeedUp = false;
        manager.RemovePowerUp(gameObject);
        isPowerUpActive = false;
        Debug.Log($"{targetPaddle.name} PU Paddle Speed Up deactivated");
    }

    private void Update()
    {
        if (isPowerUpActive)
        {
            powerUpTimer -= Time.deltaTime;

            if (powerUpTimer <= 0)
            {
                // Power up duration has ended
                isPowerUpActive = false;
            }
            else
            {
                Debug.Log($"{targetPaddle.name} Speed disappear in: {powerUpTimer:F2} seconds");
            }
        }
    }
    

    
}
