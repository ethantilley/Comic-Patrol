using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {
    public GameObject[] spriteEffects;

    public float bulletSpeed;
    public float bulletLifeTime = 2;
    public float effectLifeTime;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate((Vector3.right * bulletSpeed) * Time.deltaTime);
    }

    public void SpawnEffect()
    {
        int randSEffect = Random.Range(0, spriteEffects.Length);

        GameObject newEffect = (GameObject)Instantiate(spriteEffects[randSEffect], transform.position, spriteEffects[randSEffect].transform.rotation);
        Destroy(newEffect, effectLifeTime);
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Obstacle"))
        {
            // calls a function to add a amount of score that is passed through
            AudioManager.instance.PlayFX();
            Destroy(coll.gameObject);
            SpawnEffect();
            GameManagerScript.instance.ChangeScore(100);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
          
            Destroy(gameObject);
        }

        if (coll.gameObject.CompareTag("Enemy"))
        {
            AudioManager.instance.PlayFX();
            Destroy(coll.gameObject);
            SpawnEffect();
            GameManagerScript.instance.ChangeScore(100);

            
            Destroy(gameObject);
        }
    }
}
