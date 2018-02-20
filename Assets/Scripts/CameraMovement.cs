using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

    public Transform target;

    public Vector3 offset;
    public static CameraMovement instance;
    private void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(target.position.x + offset.x, transform.position.y + offset.y, offset.z);
	}
}
