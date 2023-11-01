using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{


    public TextMeshProUGUI gameOverText;
    public Button retryButton;


    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    private float score;

    public static GameManager Instance { get; private set; }


    public float initialGameSpeed = 2f;
    public float gameSpeedIncrease = .1f;
    public float gameSpeed { get; private set; }

    private PlayerMovement player;
    private SpawnerScript spawner;



    private void Awake()
    {
        if (Instance == null) { Instance = this; }
        else
        {
            DestroyImmediate(gameObject);
        }

    }


    private void OnDestroy()
    {
        if (Instance == null)
        {
            Instance = null;
        }
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        spawner = FindObjectOfType<SpawnerScript>();

        GameOver();
    }

    public void NewGame()
    {



        gameSpeed = initialGameSpeed;
        enabled = true;

        player.gameObject.SetActive(true);
        spawner.gameObject.SetActive(true);


        gameOverText.gameObject.SetActive(false);
        retryButton.gameObject.SetActive(false);

        UpdateHighScore();

        score = 0;

    }

    public void GameOver()
    {
        gameSpeed = 0f;
        enabled = false;

        player.gameObject.SetActive(false);
        spawner.gameObject.SetActive(false);


        gameOverText.gameObject.SetActive(true);
        retryButton.gameObject.SetActive(true);

        UpdateHighScore();

    }

    private void Update()
    {
        gameSpeed += gameSpeedIncrease * Time.deltaTime;

        score += gameSpeed * Time.deltaTime;

        scoreText.text = Mathf.FloorToInt(score).ToString("D5");


    }

    private void UpdateHighScore()
    {
        float highScore = PlayerPrefs.GetFloat("highScore", 0);

        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("highScore", highScore);
        }

        highScoreText.text = Mathf.FloorToInt(highScore).ToString("D5");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("ScoreMultiplier"))
        {

            //delete object from screen
            Destroy(collision.gameObject);

            //make this do something else later
            score = 0;

        }
    }

    public float getScore()
    {
        return score;
    }

    public void setScore(float newScore)
    {
        score = newScore;
    }
}
