using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUPaddleSizeControl : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public GameObject leftPaddle;
    public GameObject rightPaddle;
    public float magnitude = 2f;
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
            
            if (!targetPaddle.GetComponent<PaddleControl>().isLengthen)
            {
                // Debug.Log($"{targetPaddle} Manjaanggg");
                targetPaddle.GetComponent<PaddleControl>().isLengthen = true;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine(PowerUpDuration(targetPaddle, duration));
                isPowerUpActive = true;
                powerUpTimer = duration;
            }
            else
            {
                manager.RemovePowerUp(gameObject);
            }
        }
    }

    private IEnumerator PowerUpDuration(GameObject targetPaddle, int duration)
    {
        Debug.Log($"{targetPaddle.name} PU Paddle Size activated");
        targetPaddle.GetComponent<PaddleControl>().IncreasePaddleSize(magnitude);
        yield return new WaitForSeconds(duration);
        targetPaddle.GetComponent<PaddleControl>().DecreasePaddleSize(magnitude);
        targetPaddle.GetComponent<PaddleControl>().isLengthen = false;
        manager.RemovePowerUp(gameObject);
        isPowerUpActive = false;
        Debug.Log($"{targetPaddle.name} PU Paddle Size deactivated");
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
                Debug.Log($"{targetPaddle.name} Size disappear in: {powerUpTimer:F2} seconds");
            }
        }
    }

}
