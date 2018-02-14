using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.CompareTag("Player"))
        {
            // respawn.
            GameManager.instance.ReSpawnPlayer();
        }

    }

}
