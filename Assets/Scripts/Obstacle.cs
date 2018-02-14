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

    private void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.CompareTag("Bullet"))
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }

        if (coll.gameObject.CompareTag("Player"))
        {
            // respawn.

            if (GameManagerScript.instance.playerLives > 0)
            {
                print("aye?");
                GameManagerScript.instance.ReSpawnPlayer(coll.gameObject);
                coll.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            }
            else
            {
                Destroy(coll.gameObject);
            }
            Destroy(gameObject);
        }

    }

}
