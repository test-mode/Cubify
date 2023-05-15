using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{

    public GameObject gameOverScreen;
    public Text secondsSurvivedUI;
    bool gameOver;

    void Start()
    {
        FindObjectOfType <Player> ().OnPlayerDeath += OnGameOver;
    }

    void Update()
    {
        if (gameOver)
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    SceneManager.LoadScene (0);
            //}

            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
            {
                SceneManager.LoadScene(0);

            }
        }
    }

    void OnGameOver ()
    {
        gameOverScreen.SetActive (true);
        string seconds = Mathf.RoundToInt(Time.timeSinceLevelLoad).ToString();
        secondsSurvivedUI.text = "You survived for " + seconds + " seconds.";
        gameOver = true;
    }

}
