using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public bool gameOver = false;
    public float score = 0;
    public bool obstacleActive = false;
    [SerializeField]
    private GameObject[] obstacles;
    [SerializeField]
    private GameObject gameOverText;
    [SerializeField]
    private GameObject winText;
    [SerializeField]
    private TMP_Text scoreText;
    [SerializeField]
    private TMP_Text timerText;
    public float currentDiff = 1;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject puaseObjects;
    [SerializeField]
    private GameObject ball;
    [SerializeField]
    private GameObject ballExplosion;
    private bool exploded = false;
    [SerializeField]
    private bool gameModeEndless;
    [SerializeField]
    private float timeLeft;
    [SerializeField]
    private string sceneToGoTo;
    [SerializeField]
    private bool ballMode;
    private float ballTimer = 10;

    [SerializeField]
    private GameObject[] spawns;
    [SerializeField]
    private GameObject[] balls;

    [SerializeField]
    private TMP_Text livesText;
    public int lives;
    private float ballDiff;

    private float randomBallTimer;

    public bool lost;
    public bool won;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameModeEndless == true)
        {
            int spawnOb = Random.Range(0, obstacles.Length);

            //Random random = new Random();        
            if (gameOver == false)
            {
                score += Time.deltaTime;
                if (!Input.GetMouseButton(0))
                {
                    puaseObjects.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    puaseObjects.SetActive(false);
                    Time.timeScale = 1;
                }
            }
            else
            {
                Time.timeScale = 1;
                float floorScore = Mathf.Floor(score);
                gameOverText.SetActive(true);
                scoreText.text = "Score: " + floorScore.ToString();
                Destroy(player);
                if (!exploded)
                {
                    Instantiate(ballExplosion, ball.transform.position, Quaternion.identity);
                    exploded = true;
                }
                Destroy(ball);
            }

            if (obstacleActive == false && gameOver == false)
            {
                Instantiate(obstacles[spawnOb], obstacles[spawnOb].transform.position, transform.rotation);
                currentDiff += .002f;
            }
        }
        else if (ballMode)
        {
            if (gameOver == false)
            {
                ballDiff += .01f * Time.deltaTime;
                ballTimer += Time.deltaTime;
                livesText.text = "Lives: " + lives.ToString();
                if (!Input.GetMouseButton(0))
                {
                    puaseObjects.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    puaseObjects.SetActive(false);
                    Time.timeScale = 1;
                }
            }
            else
            {
                Time.timeScale = 1;
                float floorScore = Mathf.Floor(score);
                gameOverText.SetActive(true);
                scoreText.text = "Score: " + floorScore.ToString();
                Destroy(player);
                
            }

            if (lives <= 0)
            {
                if (lives != 0)
                {
                    lives = 0;
                }
                gameOver = true;
            }

            

            
            if (ballTimer >= (5 - ballDiff) + randomBallTimer)
            {
                Instantiate(balls[Random.Range(0, balls.Length)], spawns[Random.Range(0, spawns.Length)].transform.position, Quaternion.identity);
                ballTimer = 0;
                randomBallTimer = Random.Range(-3, 5);
            }
        }
        else
        {
            if (gameOver == false)
            {
                score += Time.deltaTime;
                if (!Input.GetMouseButton(0))
                {
                    puaseObjects.SetActive(true);
                    Time.timeScale = 0;
                }
                else
                {
                    puaseObjects.SetActive(false);
                    Time.timeScale = 1;
                }

                if (timerText != null)
                {
                    timeLeft -= Time.deltaTime;
                    float floorTimeLeft = Mathf.Floor(timeLeft);
                    timerText.text = "Survive for " + floorTimeLeft.ToString();
                    if (timeLeft <= 0)
                    {
                        timerText.gameObject.SetActive(false);
                        gameOver = true;
                        won = true;
                    }
                }

            }
            else
            {
                Time.timeScale = 1;

                if (lost)
                {
                    gameOverText.SetActive(true);

                    Destroy(player);
                    if (!exploded)
                    {
                        Instantiate(ballExplosion, ball.transform.position, Quaternion.identity);
                        exploded = true;
                    }
                    Destroy(ball);
                }

                else if (won)
                {
                    winText.SetActive(true);
                    if (!exploded)
                    {
                        Instantiate(ballExplosion, ball.transform.position, Quaternion.identity);
                        exploded = true;
                    }
                    Destroy(ball);
                }
            }
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GoToScene()
    {
        SceneManager.LoadScene(sceneToGoTo);
    }
}
