using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    [SerializeField] private GameObject storeObj;
    [SerializeField] private GameObject gameTitleObj;
    [SerializeField] private GameObject BallObj;

    public void GameStart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void GameStore()
    {
        storeObj.SetActive(true);
        BallObj.SetActive(true);
        Time.timeScale = 1f;
        gameTitleObj.SetActive(false);
    }

    public void GameQuit()
    {
        Application.Quit();
    }

}
