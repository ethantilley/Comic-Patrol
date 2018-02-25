using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform target;

    public Vector3 offset;

    public static CameraMovement instance;
    private float smoothedSpeed = 0.155f;

    private float coolDown;
    public bool waitBetweenStrips;

    public float shake;
    public float shakeAmount = 0.7f;
    public float decreaseFactor = 1;

    private void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Update () {

        if (shake > 0)
        {
            Vector2 shakePos = Random.insideUnitCircle * shakeAmount;
            GetComponent<Camera>().transform.position = new Vector3(transform.position.x + shakePos.x, transform.position.y + shakePos.y, transform.position.z);
            shake -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shake = 0;
        }
    }
   
	// Update is called once per frame
	void FixedUpdate () {



        Vector3 desPos = target.position + offset;
        Vector3 smoothedPos = Vector3.Lerp(transform.position, desPos, smoothedSpeed);
        transform.position = smoothedPos;

        if (waitBetweenStrips)
        {
            coolDown += 2;
            waitBetweenStrips = false;
        }

        if (coolDown > 0)
        {
            target.gameObject.GetComponent<PlayerMovement>().moving = false;
            coolDown -= Time.deltaTime;
        }
        else
        {

            target.gameObject.GetComponent<PlayerMovement>().moving = true;
        }


        // transform.position = new Vector3(target.position.x + offset.x, transform.position.y + offset.y, offset.z);
    }
}
