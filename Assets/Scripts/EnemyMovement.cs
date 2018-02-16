using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {


	public float enemySpeed;

	public float minX = 3, maxX = 15;
	public float minY = 0.5f, maxY = 1.5f;

	public enum aiState
	{
		MovingLeft,
		MovingRight,
		MovingUp,
		MovingDown,

		Shoot
	}
	public aiState currState;
	public Vector2 targetX;
	public Vector2 startPos;
		// Use this for initialization
	void Start () {
		currState = aiState.MovingLeft;

		CheckStates ();
	}
	
	// Update is called once per frame
	void Update () {			
			

		if (transform.position.x == targetX.x) {
			currState = aiState.MovingUp;
			CheckStates ();
		}

			transform.position = Vector2.MoveTowards(transform.position, targetX, enemySpeed * Time.deltaTime);	

		if (transform.position.y == targetX.y) {
			currState = aiState.MovingRight;
			CheckStates ();
		}
	}

	void CheckStates ()
	{
		//var randstate = (aiState)Random.Range(0,4);

		switch (currState) {
		case aiState.MovingLeft:
			//currState = randstate;
			startPos = transform.position;
			float randXDist = Random.Range (minX, maxX);
			targetX = new Vector2 (transform.position.x - randXDist, transform.position.y);
			break;

		case aiState.MovingRight:
			//currState = randstate;
			randXDist = Random.Range (minX, maxX);
			targetX = startPos;		
			break;


		case aiState.MovingUp:

			float randYDist = Random.Range (minY, maxY);
			targetX = new Vector2 (transform.position.x, transform.position.y + randYDist);
			break;

		case aiState.MovingDown:

			randYDist = Random.Range (minY, maxY);
			targetX = new Vector2 (transform.position.x, transform.position.y - randYDist);
			break;
		}
	}

}
