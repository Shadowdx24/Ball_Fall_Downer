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

    private void ShowBallColor(int ColorName)
    {
        if (ColorName > ballMaterials.Length - 1)
        {
            ColorName = 0;
        }
        else if (ColorName < 0)
        {
            ColorName = ballMaterials.Length - 1;
        }

        ballIndex = ColorName;
        ballRenderer.material = ballMaterials[ballIndex];
        PlayerPrefs.SetInt("MainBall", ColorName);
    }

    public void GameHome()
    {
        gameTitleObj.SetActive(true);
        Time.timeScale = 1f;
        BallObj.SetActive(false);
        storeObj.SetActive(false);
        
    }

    public void GameStart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        BallObj.SetActive(false);
        storeObj.SetActive(false);
    }
}
