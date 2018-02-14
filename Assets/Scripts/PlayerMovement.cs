using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float baseSpeed = 5;
    public float currentSpeed = 5;
    public float changeSpeedPercent = 0.5f;

  
    public float jumpHeight = 1f;
    public float jumpSpeed = 2.5f;
    public bool jumping = false;

    float min = -2.5f, max = -1.5f;
    float step = 0;
    public Vector3 target;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        ConsistentMove();
        CheckInput();

        if (Input.GetKeyDown(KeyCode.UpArrow) && !jumping)
        {
            jumping = true;
        }

        transform.position = new Vector3(transform.position.x, Mathf.Lerp(min, max, step), 0);

        if (jumping)
        {
            step += jumpSpeed * Time.deltaTime;
        }

        if (step > 1)
        {
            float temp = max;
            max = min;
            min = temp;
            step = 0.0f;
            if (temp < -1.5f)
            {
                jumping = false;
                //Hack, player can inc speed.
            }
        }

    }

    void ConsistentMove()
    {
       transform.Translate((Vector3.right * currentSpeed) * Time.deltaTime);
    }

   

    void CheckInput()
    {
       
      


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
