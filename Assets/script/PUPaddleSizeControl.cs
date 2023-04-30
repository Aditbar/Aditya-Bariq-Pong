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
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision == ball)
        {
            bool isBallMovingRight = ball.GetComponent<Rigidbody2D>().velocity.x > 0;
            GameObject targetPaddle = isBallMovingRight ? leftPaddle : rightPaddle;
            
            if (!targetPaddle.GetComponent<PaddleControl>().isLengthen)
            {
                // Debug.Log($"{targetPaddle} Manjaanggg");
                targetPaddle.GetComponent<PaddleControl>().isLengthen = true;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                GetComponent<BoxCollider2D>().enabled = false;
                StartCoroutine(PowerUpDuration(targetPaddle, duration));
            }
            else
            {
                manager.RemovePowerUp(gameObject);
            }
        }
    }

    private IEnumerator PowerUpDuration(GameObject targetPaddle, int duration)
    {
        targetPaddle.GetComponent<PaddleControl>().IncreasePaddleSize(magnitude);
        yield return new WaitForSeconds(duration);
        targetPaddle.GetComponent<PaddleControl>().DecreasePaddleSize(magnitude);
        targetPaddle.GetComponent<PaddleControl>().isLengthen = false;
        // Debug.Log($"{targetPaddle} pendek");
        manager.RemovePowerUp(gameObject);
    }

}
