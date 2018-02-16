using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

<<<<<<< HEAD
    public float enemySpeed;

    int waypointIndex = 0;

    [SerializeField]
    public Transform target;

    public float distanceFromPointAcceptable;
    public Transform[] wayPoints;

    public Transform wayPointHolder;
    public Transform c;

    public bool isMoving;

    // Use this for initialization
    void Awake()
    {


        wayPoints = new Transform[wayPointHolder.childCount];
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = wayPointHolder.GetChild(i);
        }
    }

    void Start()
    {
        target = wayPoints[0];
    }

    // Update is called once per frame
    void Update()
    {

        wayPointHolder.transform.position = new Vector2(c.position.x, c.position.y);


        float distance = distanceFromPointAcceptable / 10;

        if (isMoving)
        {

            Vector3 dir = target.position - transform.position;
            transform.Translate(dir.normalized * enemySpeed * Time.deltaTime, Space.World);
        }
        // If within  units of the target pos,
        if (Vector3.Distance(transform.position, target.position) <= distance)
        {
            // Get the new waypoiont and move to it.
            GetNextWaypoint();
        }


    }

    void GetNextWaypoint()
    {
        if (waypointIndex == 3)
        {
            waypointIndex = 0;

        }
        else
            ++waypointIndex;

        target = wayPoints[waypointIndex];
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
       
        if (coll.gameObject.CompareTag("Bullet"))
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }

    }
=======

	public float enemySpeed;

	int waypointIndex = 0;

	[SerializeField]
	public Transform target;

	public float distanceFromPointAcceptable;
	public Transform[] wayPoints;

	public Transform wayPointHolder;
	public Transform c;

	public bool isMoving;

		// Use this for initialization
	void Awake () {
		

		wayPoints = new Transform[wayPointHolder.childCount];
		for (int i = 0; i < wayPoints.Length; i++)
		{
			wayPoints[i] = wayPointHolder.GetChild(i);
		}
	}

	void Start()
	{
		target = wayPoints[0];
	}

	// Update is called once per frame
	void Update () {

		wayPointHolder.transform.position = new Vector2(c.position.x, c.position.y);


		float distance = distanceFromPointAcceptable / 10;

		if (isMoving) {
			
			Vector3 dir = target.position - transform.position;
			transform.Translate (dir.normalized * enemySpeed * Time.deltaTime, Space.World);
		}
		// If within  units of the target pos,
		if (Vector3.Distance(transform.position, target.position) <= distance)
		{
			// Get the ne waypoiont and move to it.
			GetNextWaypoint();
		}


	}

	void GetNextWaypoint()
	{
		if (waypointIndex == 3) {
			waypointIndex = 0;
		
		}else	
		++waypointIndex;
		
		target = wayPoints[waypointIndex];
	}


}
>>>>>>> origin/master
