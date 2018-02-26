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
    public bool moving = true;

    public float min = -2.5f, max = -1.5f;
    float interp = 0;

    public Animator anim;
    private float maxSpeed, minSpeed ;

    // Use this for initialization
    void Start()
    {
        maxSpeed = baseSpeed + (baseSpeed * changeSpeedPercent);
        minSpeed = baseSpeed - (baseSpeed * changeSpeedPercent);

        InvokeRepeating("checkSpeed", 1f,1f);
    }
    void checkSpeed()
    {
        print(currentSpeed);
    }
    // Update is called once per frame
    void Update()
    {
        CheckInput();
        // stoping the speed from ever going too high
        if (currentSpeed > maxSpeed)
        {
            currentSpeed = maxSpeed;
        }

        if (currentSpeed < minSpeed)
        {
            currentSpeed = minSpeed;
        }

       
       
    }
    void FixedUpdate()
    {

        if (moving)
            ConsistentMove();

        if (jumping)
        {
            // lerps the player up and down using the min and max variables
            transform.position = new Vector3(transform.position.x, Mathf.Lerp(min, max, interp), 0);
            interp += jumpSpeed * Time.deltaTime;

        }

        if (interp > 1)
        {
            
            anim.SetBool("Jumping", false);
            float temp = max;
            max = min;
            min = temp;
            interp = 0.0f;
            if (temp < jumpHeight)
            {
               
                jumping = false;
                //currentSpeed = baseSpeed;
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
            anim.SetBool("Jumping", true);
            jumping = true;

        }
        if (jumping)
            return;

        // changeing the current speed by taking away or adding a percentage
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentSpeed -= (baseSpeed * changeSpeedPercent);
            return;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentSpeed += (baseSpeed * changeSpeedPercent);
            return;
        }
        currentSpeed = baseSpeed;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("EnemyBullet") && !GameManagerScript.instance.playerImmunity)
        {
            
            StartCoroutine(GameManagerScript.instance.ReSpawnPlayer(GetComponent<SpriteRenderer>()));
        }
    }

}
