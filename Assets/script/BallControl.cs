using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float speed = 10f;
    public bool isSpeedUp = false;
    public Vector2 resetPosition;
    private Rigidbody2D rig;
    private Vector2 initialSpeed;
    
    private void Start() 
    {
        InitialSpeed();
    }

        private void InitialSpeed()
    {
        rig = GetComponent<Rigidbody2D>();
        // random degree
        float randomY = Random.Range(-0.7f, 0.7f);
        // random direction
        float randomStart = Random.Range(0, 2) * 2f - 1f;
        Vector3 initialspeed = new Vector3(randomStart, randomY, 1).normalized * speed;
        rig.velocity = initialSpeed = initialspeed;
    }

    public void ResetBall()
    {
        transform.position = new Vector3(resetPosition.x, resetPosition.y, 2);
        InitialSpeed();
        isSpeedUp = false;
    }

    public void ActivatePUSpeedUp(float magnitude)
    {
        rig.velocity *= magnitude;
    }

    public void DeactivatePUSpeedUp(float magnitude)
    {
        if (isSpeedUp)
        {
            rig.velocity /= magnitude;
            isSpeedUp = false;
        }
    }
    
}
