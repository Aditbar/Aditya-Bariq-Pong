using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    public int speed = 5;
    public bool isRight;
    public Rigidbody2D rig;
    public KeyCode upKey;
    public KeyCode downKey;
    public bool isSpeedUp = false;
    public bool isLengthen = false;
    // Start is called before the first frame update
    public static float DefaultSize { get; private set; } = 2.5f;
    void Awake()
    {
    DefaultSize = transform.localScale.y;
    }
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        if (isRight)
        {
            Debug.Log($"Paddle Right speed: {speed}");
        }
        else
        {
            Debug.Log($"Paddle left speed: {speed}");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 movement = GetInput();
        MoveObject(movement);
    }

private Vector2 GetInput()
{
    KeyCode currentUpKey = upKey != KeyCode.None ? upKey : (isRight ? KeyCode.UpArrow : KeyCode.W);
    KeyCode currentDownKey = downKey != KeyCode.None ? downKey : (isRight ? KeyCode.DownArrow : KeyCode.S);

    if (Input.GetKey(currentUpKey))
    {
        return Vector2.up * speed;
    }
    else if (Input.GetKey(currentDownKey))
    {
        return Vector2.down * speed;
    }

    return Vector2.zero;
}

    private void MoveObject(Vector2 movement)
    {
        rig.velocity = movement;
    }

    public void IncreasePaddleSize(float magnitude)
    {
    Vector3 scale = transform.localScale;
    scale.y *= magnitude;
    transform.localScale = scale;
    }

    public void DecreasePaddleSize(float magnitude)
    {
    Vector3 scale = transform.localScale;
    scale.y /= magnitude;
    if (PaddleControl.DefaultSize > scale.y) 
    {
        scale.y = PaddleControl.DefaultSize;
    }
    transform.localScale = scale;
    }

    public void IncreasePaddleSpeed(int magnitude)
    {
        speed *= magnitude;
    }

    public void DecreasePaddleSpeed(int magnitude)
    {
        speed /= magnitude;
    }

}
