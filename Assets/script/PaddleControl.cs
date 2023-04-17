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
    // Start is called before the first frame update
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
}
