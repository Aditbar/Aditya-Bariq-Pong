using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpControl : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public float magnitude = 2f;
    public int duration = 5;
    private bool isPowerUpActive = false;
    private float powerUpTimer = 0;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision == ball && !ball.GetComponent<BallControl>().isSpeedUp)
        {
            ball.GetComponent<BallControl>().isSpeedUp = true;
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(DeactivatePowerUp(duration));
            isPowerUpActive = true;
            powerUpTimer = duration;
        }
        else
        {
            manager.RemovePowerUp(gameObject);
        }
    }

    private IEnumerator DeactivatePowerUp(int duration)
    {
        ball.GetComponent<BallControl>().ActivatePUSpeedUp(magnitude);
        yield return new WaitForSeconds(duration);
        ball.GetComponent<BallControl>().DeactivatePUSpeedUp(magnitude);
        ball.GetComponent<BallControl>().isSpeedUp = false;
        manager.RemovePowerUp(gameObject);
        isPowerUpActive = false;
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
                Debug.Log($"Speed Ball disappear in: {powerUpTimer:F2} seconds");
            }
        }
    }
}
