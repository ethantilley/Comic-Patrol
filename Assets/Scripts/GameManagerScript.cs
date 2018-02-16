using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class GameManagerScript : MonoBehaviour
{

    public int playerScore;
    public int playerLives;

    public float flashTime = 0.5f;

    // making this script be the only one to exist and making it accesable in other scripts without referance. 
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
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    // called elsewhere when player needs to respawn, lose a life and also flashes the players sprite an momentarialy pauses game to show the player was hit.
    public IEnumerator ReSpawnPlayer(SpriteRenderer playersRend)
    {
        --playerLives;
        Time.timeScale = 0;
        playersRend.enabled = false;
        yield return new WaitForSecondsRealtime(flashTime);
        Time.timeScale = 1;
        playersRend.enabled = true;

    }

=======
public class GameManagerScript : MonoBehaviour {

	public int playerScore;
	public int playerLives;

	public float flashTime;

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

	public IEnumerator ReSpawnPlayer (SpriteRenderer ps)
	{
		--playerLives;
		ps.enabled = false;
		Time.timeScale = 0;
		yield return new WaitForSecondsRealtime (flashTime);
		ps.enabled = true;
		Time.timeScale = 1;

	}
>>>>>>> origin/master
}
