using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField]
    private Button RestartBtn;
    [SerializeField]
    private Button ExitBtn;
    [SerializeField]
    private Button ClosePanelBtn;

    private void OnEnable()
    {
        RestartBtn.onClick.AddListener(Restart);
        ExitBtn.onClick.AddListener(Exit);
        ClosePanelBtn.onClick.AddListener(ClosePanel);
    }

    private void Restart()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    private void ClosePanel()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    private void Exit()
    {
        Application.Quit();
    }

    private void OnDisable()
    {
        RestartBtn.onClick.RemoveListener(Restart);
        ExitBtn.onClick.RemoveListener(Exit);
    }
}
