using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour
{
    private int controls;
    [SerializeField] private GameObject Settingobj;

    public void BtnMouseClick()
    {
        controls = 1;
        PlayerPrefs.SetInt("currControls", controls);
    }
    public void BtnTouch()
    {
        controls = 2;
        PlayerPrefs.SetInt("currControls", controls);
    }

    public void GameHome()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
        Settingobj.SetActive(false);
    }
}
