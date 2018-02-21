using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    public Text livesText;
    public Text scoreText;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        livesText.text = GameManagerScript.instance.playerLives.ToString();
        scoreText.text = GameManagerScript.instance.playerScore.ToString();
    }
}
