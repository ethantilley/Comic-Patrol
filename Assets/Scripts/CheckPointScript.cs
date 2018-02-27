using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour {

    public bool endLevelOnColl = false;

    private void OnTriggerStay2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            
            MovePlayer(coll.gameObject.GetComponent<PlayerMovement>());
        }
    }

    void MovePlayer(PlayerMovement player)
    {

        if (player.jumping)
            return;
        if (endLevelOnColl)
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            player.min = -3f;
            player.max = player.min + 1.2f;
            player.jumpHeight = -2.2f;
            player.transform.position = new Vector2(0, player.min);

            SpawnManager.instance.SpawnMap();
            CameraMovement.instance.waitBetweenStrips = true;

        }
        else
        {
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            AudioManager.instance.PlaySound("PLStripOver");
            player.transform.position = new Vector2(0, player.transform.position.y - SpawnManager.instance.stripGapDistance);
            CameraMovement.instance.waitBetweenStrips = true;
            player.min -= SpawnManager.instance.stripGapDistance;
            player.max = player.min + 1.2f;
            player.jumpHeight -= SpawnManager.instance.stripGapDistance;
        }
    }

}
