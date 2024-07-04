using UnityEngine;
using UnityEngine.SceneManagement;

public class BallControler : MonoBehaviour
{
    [SerializeField] private Rigidbody ballRb;
    [SerializeField] private float speed;
    [SerializeField] private GameObject gameOverObj;
    [SerializeField] private GameObject levelWinObj;
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ring"))
        {
            ballRb.AddForce(Vector3.up * speed,ForceMode.Impulse);   
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
    }

    private void LevelWin()
    {
        levelWinObj.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        gameOverObj.SetActive(false);
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
    }

    public void GameQuit()
    {
        Application.Quit();
    }

}

