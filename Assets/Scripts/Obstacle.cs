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
<<<<<<< HEAD
    // checking collisions with the player and bullet.
    private void OnTriggerEnter2D(Collider2D coll)
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
=======

	private void OnTriggerEnter2D(Collider2D coll)
    {
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
>>>>>>> origin/master
        if (coll.gameObject.CompareTag("Bullet"))
        {
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }

        if (coll.gameObject.CompareTag("Player"))
        {
<<<<<<< HEAD
        
            if (GameManagerScript.instance.playerLives > 0)
            {
              
              StartCoroutine(GameManagerScript.instance.ReSpawnPlayer(coll.gameObject.GetComponent<SpriteRenderer>()));
             
            }
            else
            {
                Destroy(coll.gameObject);
            }
            Destroy(gameObject, 1);
=======
            // respawn.

			if(GameManagerScript.instance.playerLives > 0)
			StartCoroutine(GameManagerScript.instance.ReSpawnPlayer(coll.gameObject.GetComponent<SpriteRenderer>()));
			else {
				Destroy (gameObject);
			}
			Destroy (gameObject, 1);
>>>>>>> origin/master
        }
      
    }

}
