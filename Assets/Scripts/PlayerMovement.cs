using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float baseSpeed = 5;
    public float currentSpeed = 5;
    public float changeSpeedPercent = 0.5f;
    public float jumpSpeed = 2;
    public bool jumping = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ConsistentMove();
        CheckInput();
	}

    void ConsistentMove()
    {
       transform.Translate((Vector3.right * currentSpeed) * Time.deltaTime);
    }

    void PlayerJump()
    {
        transform.Translate((Vector3.up * jumpSpeed) * Time.deltaTime);
    }

    void CheckInput()
    {
        //Hack, This Jump is not at-all what i want.... 
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            jumping = true;
            PlayerJump();
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
            jumping = false;

        if (jumping)
            return;

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
