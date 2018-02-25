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
    private void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {
		
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
