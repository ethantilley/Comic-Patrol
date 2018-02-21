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
    public Transform c;

    public bool isMoving;
    Transform player;
    // Use this for initialization
    void Awake()
    {
        
        holders = GameObject.FindGameObjectsWithTag("WayPointHolder");
        wayPointHolder = holders[Random.Range(0, holders.Length)].transform;
        c = GameObject.Find("Main Camera").transform;

        wayPoints = new Transform[wayPointHolder.childCount];
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = wayPointHolder.GetChild(i);
        }
    }

    void Start()
    {
        player = GameObject.Find("Player").transform;
        isMoving = false;
        target = wayPoints[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            float distFromPlyr = Vector2.Distance(player.position, transform.position);

            if (distFromPlyr < 6)
            {
                isMoving = true;
            }
            else
            {
               // isMoving = false;
            }

        }
        if (!isMoving)
            return;


        //foreach (var item in holders)
        //item.transform.position = new Vector2(c.position.x, c.position.y);

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

    void GetNextPointHolder()
    {
        wayPointHolder = holders[Random.Range(0, holders.Length)].transform;
        
        wayPoints = new Transform[wayPointHolder.childCount];
        for (int i = 0; i < wayPoints.Length; i++)
        {
            wayPoints[i] = wayPointHolder.GetChild(i);
        }

        target = wayPoints[0];
    }

    void GetNextWaypoint()
    {
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
