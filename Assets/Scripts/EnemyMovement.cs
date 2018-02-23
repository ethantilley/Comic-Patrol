using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    public float enemySpeed;

    public int waypointIndex = 0;

    [SerializeField]
    public Transform target;

    public float distanceFromPointAcceptable;
    public Transform[] wayPoints;

    public GameObject[] holders;
    public Transform wayPointHolder;
    public Transform cam;

    public bool isActive;
    Transform player;
    // Use this for initialization

    void Start()
    {
        holders = GameObject.FindGameObjectsWithTag("WayPointHolder");
        cam = GameObject.Find("Main Camera").transform;
        GetNextPointHolder();
        player = GameObject.Find("Player").transform;
        isActive = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // checks the distance it's from the player and changes is status 
            float distFromPlyr = Vector2.Distance(player.position, transform.position);

           
            if (distFromPlyr < 6)
            {
                isActive = true;
            }
            else if (distFromPlyr > 10)
            {
                isActive = false;
            }

        }
        if (!isActive)
            return;


        //foreach (var item in holders)
        //item.transform.position = new Vector2(c.position.x, c.position.y);

        float distance = distanceFromPointAcceptable / 10;

        if (isActive)
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
    // called when the enemy finishes a waypoint section and moves onto the next section
    void GetNextPointHolder()
    {
        wayPointHolder = holders[Random.Range(0, holders.Length)].transform;
        
        wayPoints = new Transform[wayPointHolder.childCount];
        for (int i = 0; i < wayPoints.Length; i++)
        {
            // assigns the waypoints child to the randomly selected holder
            wayPoints[i] = wayPointHolder.GetChild(i);
        }
        // sets the enemys target the waypoints
        target = wayPoints[0];
    }

    void GetNextWaypoint()
    {
        // check to see if the enemy nees to move to the next holder
        if (waypointIndex == 3)
        {
            print("Finished waypoints");
            waypointIndex = 0;
            GetNextPointHolder();

        }
        else
            ++waypointIndex;

        target = wayPoints[waypointIndex];
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
       
        if (coll.gameObject.CompareTag("Bullet"))
        {
            GameManagerScript.instance.ChangeScore(100);

            Destroy(coll.gameObject);
            Destroy(gameObject);
        }
    }

    }
