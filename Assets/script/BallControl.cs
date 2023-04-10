using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rig;
    private float startX = 0f;
    public float speed = 6f;
    private void Start()
    {
        InitialSpeed();
    }

    private void InitialSpeed()
    {
        rig = GetComponent<Rigidbody2D>();
        // bikin sudut random diawal game
        float randomY = Random.Range(-0.7f, 0.7f);
        int randomStart = Random.Range(0, 2) * 2 - 1;
        Vector2 initialspeed = new Vector2(randomStart, randomY).normalized * speed;
        rig.velocity = initialspeed;
    }

    private void ResetBall()
    {
        float posY = Random.Range(-3f, 3f);
        Vector2 position = new Vector2(startX, posY);
        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        ResetBall();
        InitialSpeed();
    }
}
