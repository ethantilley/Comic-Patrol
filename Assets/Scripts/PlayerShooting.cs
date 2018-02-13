using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public GameObject bullet;

    public Transform[] shootPositions;

    public List<GameObject> bullets = new List<GameObject>();

    public float bulletSpeed;
    public float bulletLifeTime = 2;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CheckShooting();
        MoveBullets();
	}

    void MoveBullets()
    {
        for (int i = 0; i < bullets.Count; i++)
        {
            if (bullets[i] != null)
            {
                bullets[i].transform.parent = transform;
                bullets[i].transform.Translate((Vector3.right * bulletSpeed) * Time.deltaTime);
            }
        }
    }

    void CheckShooting()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        for (int i = 0; i < shootPositions.Length; i++)
        {
            GameObject newBull = Instantiate(bullet, shootPositions[i].transform.position, shootPositions[i].transform.rotation);
            Destroy(newBull, bulletLifeTime);
            bullets.Add(newBull);
            
        }
    }
}
