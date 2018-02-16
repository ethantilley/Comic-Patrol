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
		gameObject.GetComponent<SpriteRenderer> ().enabled = false;
        if (coll.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            Destroy(coll.gameObject);
        }

        if (coll.gameObject.CompareTag("Player"))
        {
            // respawn.

			if(GameManagerScript.instance.playerLives > 0)
			StartCoroutine(GameManagerScript.instance.ReSpawnPlayer(coll.gameObject.GetComponent<SpriteRenderer>()));
			else {
				Destroy (gameObject);
			}
			Destroy (gameObject, 1);
        }

    }

}
