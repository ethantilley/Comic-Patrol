using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    public int playerScore;
    public int playerLives;

    public static GameManagerScript instance;

    private void Awake()
    {
        if (instance != this)
        {
            DestroyImmediate(instance);
            instance = this;
        }
        else
        {
            instance = this;
        }
    }


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ReSpawnPlayer(GameObject player)
    {
        print("aye?2");
        playerLives--;
        player.GetComponent<SpriteRenderer>().enabled = true;
        print("aye?3");
    }

}
