using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         
        }
    }
    // called elsewhere when player needs to respawn, lose a life and also flashes the players sprite an momentarialy pauses game to show the player was hit.
    public IEnumerator ReSpawnPlayer(SpriteRenderer playersRend)
    {
        AudioManager.instance.PlaySound("PLtakeDmg");
        --playerLives;
        Time.timeScale = 0;
        playersRend.enabled = false;
        yield return new WaitForSecondsRealtime(flashTime);
        Time.timeScale = 1;
        playersRend.enabled = true;

    }

}
