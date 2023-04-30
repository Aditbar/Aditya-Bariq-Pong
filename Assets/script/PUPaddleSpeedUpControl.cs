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

     private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision == ball)
        {
            bool isBallMovingRight = ball.GetComponent<Rigidbody2D>().velocity.x > 0;
            GameObject targetPaddle = isBallMovingRight ? leftPaddle : rightPaddle;

            if (!targetPaddle.GetComponent<PaddleControl>().isSpeedUp)
            {
                // Debug.Log($"{targetPaddle} cepet!!!");
                targetPaddle.GetComponent<PaddleControl>().isSpeedUp = true;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine(DeactivatePowerUp(targetPaddle, duration));
            }
            else
            {
                manager.RemovePowerUp(gameObject);
                targetPaddle.GetComponent<PaddleControl>().isSpeedUp = false;
            }
        }
    }

    private IEnumerator DeactivatePowerUp(GameObject targetPaddle, int duration)
    {
        targetPaddle.GetComponent<PaddleControl>().IncreasePaddleSpeed(magnitude);
        yield return new WaitForSeconds(duration);
        targetPaddle.GetComponent<PaddleControl>().DecreasePaddleSpeed(magnitude);
        // Debug.Log($"{targetPaddle} ngelambat");
        targetPaddle.GetComponent<PaddleControl>().isSpeedUp = false;
        manager.RemovePowerUp(gameObject);
    }
    

    
}
