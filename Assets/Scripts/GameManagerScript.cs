using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{

    public int playerScore, highScore;
    public float timeBetweenReward = 30; 

    public int playerLives;

    public float flashTime = 0.5f;
    public float immunityTime = 2;
    public bool playerImmunity = false;
    GameObject player;
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

        player = GameObject.Find("Player");

    }

    IEnumerator ScoreReward ()
    {
        yield return new WaitForSeconds(timeBetweenReward);
        ChangeScore(50);
    }

    // Use this for initialization
    void Start()
    {
        highScore = PlayerPrefs.GetInt("highScore", 0);
        Time.timeScale = 1;

    }

    public void SaveHighScore()
    {
        PlayerPrefs.SetInt("highScore", Mathf.Max(highScore, playerScore));
    }

    public void DeathState()
    {
        SaveHighScore();
        UIManager.instance.DisplayEndGameStats();
        player.GetComponent<PlayerMovement>().moving = false;
        player.GetComponent<BoxCollider2D>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (playerImmunity && immunityTime > 0)
        {
            player.GetComponent<BoxCollider2D>().enabled = false;       
            immunityTime -= Time.deltaTime;
        }
        else {
            player.GetComponent<BoxCollider2D>().enabled = true;
            playerImmunity = false;
        }
        if (playerLives <= 0)
        {
            DeathState();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         
        }
    }

    public void ChangeScore(int _AmtToChange)
    {
        playerScore += _AmtToChange;
    }

    // called elsewhere when player needs to respawn, lose a life and also flashes the players sprite an momentarialy pauses game to show the player was hit.
    public IEnumerator ReSpawnPlayer(SpriteRenderer playersRend)
    {
        ChangeScore(-50);

        playerImmunity = true;
        immunityTime = 1.8f;
        AudioManager.instance.PlaySound("PLtakeDmg");
        --playerLives;
        Time.timeScale = 0;
        playersRend.enabled = false;
        yield return new WaitForSecondsRealtime(flashTime);
        Time.timeScale = 1;
        playersRend.enabled = true;
       

    }

}
