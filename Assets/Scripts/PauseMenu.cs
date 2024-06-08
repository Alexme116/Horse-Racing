using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;

    public void PauseGame() {
        PausePanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void ContinueGame() {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void RestartGame() {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SaveQuitGame() {
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync(0);
    }
}
