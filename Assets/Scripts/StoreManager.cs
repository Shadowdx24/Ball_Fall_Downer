using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private GameObject gameTitleObj;
    [SerializeField] private GameObject storeObj;

    public void GameHome()
    {
        gameTitleObj.SetActive(true);
        Time.timeScale = 1f;
        storeObj.SetActive(false);
    }

    public void GameStart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        storeObj.SetActive(false);
    }
}
