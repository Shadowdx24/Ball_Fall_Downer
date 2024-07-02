using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void GameQuit()
    {
        Application.Quit();
    }

}
