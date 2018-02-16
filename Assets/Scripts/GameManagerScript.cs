using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
