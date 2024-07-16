using UnityEngine;
using UnityEngine.SceneManagement;

public class StoreManager : MonoBehaviour
{
    [SerializeField] private MeshRenderer ballRenderer;
    [SerializeField] private Material[] ballMaterials;
    [SerializeField] private GameObject gameTitleObj;
    [SerializeField] private GameObject storeObj;
    [SerializeField] private GameObject BallObj;
    private int ballIndex;

    void Start()
    {
        ballIndex = 0;
    }

    public void BallPrev()
    {
        ballIndex--;
        ShowBallColor(ballIndex);
    }

    public void BallNext()
    {
        ballIndex++;
        ShowBallColor(ballIndex);
    }

    private void ShowBallColor(int colorName)
    {
        if (colorName > ballMaterials.Length - 1)
        {
            colorName = 0;
        }
        else if (colorName < 0)
        {
            colorName = ballMaterials.Length - 1;
        }

        ballIndex = colorName;
        ballRenderer.material = ballMaterials[ballIndex];
        PlayerPrefs.SetInt("MainBall", colorName);
    }
    public void GameStart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        BallObj.SetActive(false);
        storeObj.SetActive(false);
    }

    public void GameHome()
    {
        gameTitleObj.SetActive(true);
        Time.timeScale = 1f;
        BallObj.SetActive(false);
        storeObj.SetActive(false);
        
    }

}
