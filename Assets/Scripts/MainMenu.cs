using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject infoPanel;
    public GameObject mainMenuPanel;

    public void StartGame()
    {
        SceneManager.LoadScene("rollaball");
    }

    public void OpenInfo()
    {
        infoPanel.SetActive(true);
        mainMenuPanel.SetActive(false);
    }

    public void CloseInfo()
    {
        infoPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}