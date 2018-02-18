using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointScript : MonoBehaviour {

    public bool endLevelOnColl = false;

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
        
//            coll.transform.position = new Vector2(coll.transform.position.x, coll.GetComponent<PlayerMovement>().min);
            if (!endLevelOnColl)
            {
                AudioManager.instance.PlaySound("PLStripOver");
                coll.gameObject.transform.position = new Vector2(0, coll.gameObject.transform.position.y - SpawnManager.instance.stripGapDistance);
            }
            else
            {
                coll.gameObject.transform.position = new Vector2(0, -2.5f);
            }
            ChangeJumpBounds(coll.gameObject.GetComponent<PlayerMovement>());
        }
    }

    void ChangeJumpBounds(PlayerMovement player)
    {
        
        if(player.jumping == false)
            player.transform.position = new Vector2(player.transform.position.x, player.min);
        if (endLevelOnColl)
        {
            player.min = -2.5f;
            player.max = player.min + 1;
            player.jumpHeight = -1.5f;
        }
        else
        {
            player.min -= SpawnManager.instance.stripGapDistance;
            player.max = player.min + 1;
            player.jumpHeight -= SpawnManager.instance.stripGapDistance;
        }
    }

}
