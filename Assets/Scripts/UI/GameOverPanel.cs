using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField]
    private Button RestartBtn;
    [SerializeField]
    private Button ExitBtn;

    private void OnEnable()
    {
        RestartBtn.onClick.AddListener(Restart);
        ExitBtn.onClick.AddListener(Exit);
    }

    private void Restart()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
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
