using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float baseSpeed = 5;
    public float currentSpeed = 5;
    public float changeSpeedPercent = 0.5f;


    public float jumpHeight = 1f;
    public float jumpSpeed = 2.5f;
    public bool jumping = false;

    float min = -2.5f, max = -1.5f;
    float interp = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ConsistentMove();
        CheckInput();

        // lerps the player up and down using the min and max variables
        transform.position = new Vector3(transform.position.x, Mathf.Lerp(min, max, interp), 0);

        if (jumping)
        {
            interp += jumpSpeed * Time.deltaTime;
        }

        if (interp > 1)
        {
            float temp = max;
            max = min;
            min = temp;
            interp = 0.0f;
            if (temp < -1.5f)
            {
                jumping = false;
                //Hack, player can inc speed.
            }
        }

    }
    // func for the consistent and smooth movement from left to right
    void ConsistentMove()
    {
        transform.Translate((Vector3.right * currentSpeed) * Time.deltaTime);
    }


    // called to check input for the players movment 
    void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && !jumping)
        {
            jumping = true;
            return;
        }

        // changeing the current speed by taking away or adding a percentage
        if (Input.GetKeyDown(KeyCode.LeftArrow))
            currentSpeed -= (baseSpeed * changeSpeedPercent);
        if (Input.GetKeyUp(KeyCode.LeftArrow))
            currentSpeed = baseSpeed;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            currentSpeed += (baseSpeed * changeSpeedPercent);
        if (Input.GetKeyUp(KeyCode.RightArrow))
            currentSpeed = baseSpeed;
    }
}
