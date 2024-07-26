using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallControler : MonoBehaviour
{
    [SerializeField] private Rigidbody ballRb;
    [SerializeField] private float speed;
    [SerializeField] private float bounceForce;
    [SerializeField] private GameObject gameOverObj;
    [SerializeField] private GameObject levelWinObj;
    [SerializeField] private GameObject gamePauseObj;
    [SerializeField] private MeshRenderer ballRenderer;
    [SerializeField] private Material[] ballMaterials;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private TextMeshProUGUI scoreText1;
    [SerializeField] private TextMeshProUGUI highScoreText1;   
    [SerializeField] private TextMeshProUGUI scoreText2;
    [SerializeField] private TextMeshProUGUI highScoreText2;
    private int currball;
    private int score;
    private int highScore;

    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Level 1")
        {
            score = 0;
            scoreText.text = "" + score;
        }
        else if (SceneManager.GetActiveScene().name == "Level 2")
        {
            score = PlayerPrefs.GetInt("Score");
            scoreText.text = "" + score;
        }
        else if (SceneManager.GetActiveScene().name == "Level 3")
        {
            score = PlayerPrefs.GetInt("Score");
            scoreText.text = "" + score;
        }
        else
        {
            score = 0;
        }

        highScore = PlayerPrefs.GetInt("Highscore");
        highScoreText.text = "" + highScore;
        //addScore = 0;
        currball = PlayerPrefs.GetInt("MainBall");
        ballRenderer.material = ballMaterials[currball];
    }

    public void AddScore(int s)
    {
        score += s;
        scoreText.text = "" + score;
        Debug.Log(score);
        PlayerPrefs.SetInt("Score", score);
        CheckHighScore();
    }

    private void CheckHighScore()
    {
        if (highScore < score)
        {
            highScore = score;
            PlayerPrefs.SetInt("Highscore", highScore);
            highScoreText.text = "" + highScore;
            Debug.Log(highScore);

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ring"))
        {
            ballRb.velocity = new Vector3(ballRb.velocity.x, bounceForce * Time.deltaTime, ballRb.velocity.z);
            //ballRb.AddForce(Vector3.up * speed,ForceMode.Impulse);
        }

        else if (collision.gameObject.CompareTag("DangerRing"))
        {
            GameOver();
            Debug.Log("Game Over");
        }

        else if (collision.gameObject.CompareTag("WinRing"))
        {
            LevelWin();
            Debug.Log("Level Complete");
        }
    }

    private void GameOver()
    {
        gameOverObj.SetActive(true);
        Time.timeScale = 0f;
        scoreText1.text = "Score : " + score;
        highScoreText1.text = "High Score : " + highScore;
    }

    public void GamePause()
    {
        gamePauseObj.SetActive(true);
        Time.timeScale = 0f;
    }

    private void LevelWin()
    {
        levelWinObj.SetActive(true);
        Time.timeScale = 0f;
        scoreText2.text = "Score : " + score;
        highScoreText2.text = "High Score : " + highScore;
    }

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        gameOverObj.SetActive(false);
        score = 0;
    }

    public void GameResume()
    {
        gamePauseObj.SetActive(false);
        Time.timeScale = 1f;
        score = 0;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Time.timeScale = 1f;
        levelWinObj.SetActive(false);
    }

    public void GameHome()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        gameOverObj.SetActive(false);
        levelWinObj.SetActive(false);
    }

    public void GameQuit()
    {
        Application.Quit();
    }

}

