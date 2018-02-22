using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    // checking collisions with the player and bullet.
    private void OnTriggerEnter2D(Collider2D coll)
    {

        if (coll.gameObject.CompareTag("Bullet"))
        {
            // calls a function to add a amount of score that is passed through
            GameManagerScript.instance.ChangeScore(100);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(coll.gameObject);
            Destroy(gameObject);
        }

        if (coll.gameObject.CompareTag("Player"))
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //check to see if the player has lives
            if (GameManagerScript.instance.playerLives > 0)  
                // runs a corutine in the game manager that take away a life from the player and flashes the players life and gives the player temp immunity
                StartCoroutine(GameManagerScript.instance.ReSpawnPlayer(coll.gameObject.GetComponent<SpriteRenderer>()));            
            else
            {
                AudioManager.instance.PlaySound("PLDeath");
                Time.timeScale = 0;
            }
            Destroy(gameObject, 1);
        }

    }

}
