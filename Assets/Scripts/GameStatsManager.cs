using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public int playerScore;
    public int playerLives;

    public static GameManager instance;

    private void Awake()
    {
        if (instance != this)
        {
            DestroyImmediate(this);
           
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

    public void ReSpawnPlayer ()
    {

    }

}
