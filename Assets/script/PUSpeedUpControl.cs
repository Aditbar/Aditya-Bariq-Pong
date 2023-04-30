using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PUSpeedUpControl : MonoBehaviour
{
    public PowerUpManager manager;
    public Collider2D ball;
    public int duration = 5;
    public float magnitude = 2f;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision == ball)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<BoxCollider2D>().enabled = false;
            StartCoroutine(DeactivatePowerUp(duration));
        }    
    }

    private IEnumerator DeactivatePowerUp(int duration)
    {
        ball.GetComponent<BallControl>().ActivatePUSpeedUp(magnitude);
        yield return new WaitForSeconds(duration);
        ball.GetComponent<BallControl>().DeactivatePUSpeedUp(magnitude);
        manager.RemovePowerUp(gameObject);
    }
}
