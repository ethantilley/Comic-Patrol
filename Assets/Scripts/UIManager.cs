using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public Text livesText;
    public Text scoreText;

    public GameObject EndStateObj;

    public Text highScoreText;
    public Text totalScoreText;

    public static UIManager instance;

    public GameObject splash;

    // Use this for Before initialization
    void Awake()
    {
        if (instance != null)
        {
            DestroyImmediate(this);
        }
        else
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (splash.activeInHierarchy)
        {
            if (Input.anyKeyDown)
            {
                splash.SetActive(false);
            }
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }


        livesText.text = "Lives: " + GameManagerScript.instance.playerLives.ToString();
        scoreText.text = "Score: " + GameManagerScript.instance.playerScore.ToString();

        highScoreText.text = GameManagerScript.instance.highScore.ToString();
        totalScoreText.text = GameManagerScript.instance.playerScore.ToString();
    }

    public void DisplayEndGameStats ()
    {
        livesText.enabled = false;
        scoreText.enabled = false;

        EndStateObj.SetActive(true);
        
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
