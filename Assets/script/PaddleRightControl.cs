using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleRightControl : MonoBehaviour
{
    public int speed = 5;
    public Rigidbody2D rig;
    public KeyCode UpKey = KeyCode.UpArrow;
    public KeyCode DownKey = KeyCode.DownArrow;
    // Start is called before the first frame update
    private void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 movement = GetInput();
        MoveObject(movement);
    }

    private Vector2 GetInput()
    {
        if (Input.GetKey(UpKey))
        {
            return Vector2.up * speed;
        }
        else if (Input.GetKey(DownKey))
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
