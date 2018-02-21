using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour {

    public float cooldown;
    public float fireRate;
    public float bulletSpeed;
    public float enemBulletLifeTime;

    public GameObject enemyBulletPrefab;
    public Transform firePos;

    public List<GameObject> enemBullets = new List<GameObject>();

    // Use this for initialization
    void Start () {
        StartCoroutine(GunTimer());
	}
	
    public IEnumerator GunTimer ()
    {
        int amtToShoot = Random.Range(1, 3);
       
        yield return new WaitForSecondsRealtime(cooldown);
        if (amtToShoot > 1)
        {
            for (int i = 0; i < amtToShoot; i++)
            {
                yield return new WaitForSecondsRealtime(fireRate);
                Shoot();
            }
        }
        else
        {
            Shoot();
        }
        StartCoroutine(GunTimer());
    }

    void Shoot()
    {
        if (GetComponent<EnemyMovement>().isMoving)
        {
            AudioManager.instance.PlaySound("enemShot");

            GameObject newBullet = Instantiate(enemyBulletPrefab, firePos.position, enemyBulletPrefab.transform.rotation);
            enemBullets.Add(newBullet);


            Destroy(newBullet, enemBulletLifeTime);
        }
    }

    private void Update()
    {
        for (int i = 0; i < enemBullets.Count; i++)
        {
            if (enemBullets[i] != null)
            {
                enemBullets[i].transform.parent = transform;
                enemBullets[i].transform.Translate((Vector3.right * bulletSpeed) * Time.deltaTime);
            }
            else
            {
                // removing the bullet from the list if its missing
                enemBullets.RemoveAt(i);
            }
        }
    }
}
