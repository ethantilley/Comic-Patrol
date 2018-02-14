using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    public GameObject bullet;

    public Transform frontShootPosition;
    public Transform topShootPosition;

    public List<GameObject> bullets = new List<GameObject>();

    public float bulletSpeed;
    public float bulletLifeTime = 2;

    public float frontGunCooldown = 0;
    public float topGunCooldown = 0;

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
        frontGunCooldown -= Time.deltaTime;
        topGunCooldown -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (frontGunCooldown <= 0)
            {
                frontGunCooldown = 0;
                ShootFront();
            }
            if (topGunCooldown <= 0)
            {
                topGunCooldown = 0;
                ShootTop();
            }
        }
    }

    void ShootFront()
    {       
            GameObject newBull = Instantiate(bullet, frontShootPosition.transform.position, frontShootPosition.transform.rotation);
            
            Destroy(newBull, bulletLifeTime);
            
            bullets.Add(newBull);
        frontGunCooldown = 1.8f;
    }

    void ShootTop()
    {
        GameObject newBull = Instantiate(bullet, topShootPosition.transform.position, topShootPosition.transform.rotation);
        Destroy(newBull, bulletLifeTime);
        bullets.Add(newBull);
        topGunCooldown = 0.5f;
    }
}
