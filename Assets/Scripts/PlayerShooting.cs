using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{

    public GameObject bullet;

    public Transform frontShootPosition;
    public Transform topShootPosition;

    public List<GameObject> bullets = new List<GameObject>();

    public float bulletSpeed;
    public float bulletLifeTime = 2;

    float frontGunCooldown = 0;
    float topGunCooldown = 0;


    public int bulletBurst = 4;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CheckShooting();
        MoveBullets();
    }

    void MoveBullets()
    {
        // Looping though all bullets that are existing, making sure they're parented to the player and moving them at a speed variable timesed by time
        for (int i = 0; i < bullets.Count; i++)
        {
            if (bullets[i] != null)
            {
                bullets[i].transform.parent = transform;
                bullets[i].transform.Translate((Vector3.right * bulletSpeed) * Time.deltaTime);
            }
            else
            {
                // removing the bullet from the list if its missing
                bullets.RemoveAt(i);
            }
        }
    }
    // function that check if players using the shoot button and the cooldown is at zero for both guns
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
                StartCoroutine(CoolDown());
            }
        }
    }

    IEnumerator CoolDown ()
    {
       
    
            if (bulletBurst <= 0)
            {
            
                yield return new WaitForSecondsRealtime(2f);
            bulletBurst = 4;
            }
            else
            {
            AudioManager.instance.PlaySound("PLshot");
            GameObject newBull = 
            Instantiate(bullet, topShootPosition.transform.position, 
            topShootPosition.transform.rotation);

                Destroy(newBull, bulletLifeTime);
                bullets.Add(newBull);
                topGunCooldown = 0.35f;
                --bulletBurst;
            }
              
    }

    // called when the player wants to shoot and also if the cooldown for this gun has ended
    void ShootFront()
    {
        AudioManager.instance.PlaySound("PLshot");
        GameObject newBull = Instantiate(bullet, frontShootPosition.transform.position, frontShootPosition.transform.rotation);

        Destroy(newBull, bulletLifeTime);

        bullets.Add(newBull);
        frontGunCooldown = 1.5f;
    }
    // called when the player wants to shoot and also if the cooldown for this gun has ended
    void ShootTop()
    {
        //GameObject newBull = Instantiate(bullet, topShootPosition.transform.position, topShootPosition.transform.rotation);
        //Destroy(newBull, bulletLifeTime);
        //bullets.Add(newBull);
        //topGunCooldown = 0.5f;
    }
}
