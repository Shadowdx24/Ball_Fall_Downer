using UnityEngine;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    [SerializeField] private GameObject storeObj;
    [SerializeField] private GameObject gameTitleObj;
    public void GameStart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }

    public void GameStore()
    {
        storeObj.SetActive(true);
        Time.timeScale = 1f;
        gameTitleObj.SetActive(false);
    }

    public void GameQuit()
    {
        Application.Quit();
    }

}
