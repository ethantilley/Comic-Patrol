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
    // checking collisions with the player and bullet.
    private void OnTriggerEnter2D(Collider2D coll)
    {
        
        if (coll.gameObject.CompareTag("Bullet"))
        {
            GameManagerScript.instance.ChangeScore(100);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }

        if (coll.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            if (GameManagerScript.instance.playerLives > 0)
            {
              
              StartCoroutine(GameManagerScript.instance.ReSpawnPlayer(coll.gameObject.GetComponent<SpriteRenderer>()));
             
            }
            else
            {
                AudioManager.instance.PlaySound("PLDeath");
                Time.timeScale = 0;
            }
            Destroy(gameObject, 1);
        }
      
    }

}
