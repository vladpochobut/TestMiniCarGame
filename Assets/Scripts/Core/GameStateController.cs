using System;
using UnityEngine;
using UnityEngine.UI;

public class GameStateController : MonoBehaviour
{
    public static GameStateController instance;
    public static event Action OnGameStart;
    public static event Action OnGameEnds;

    [SerializeField]
    private GameObject _pauseWindow; 
    [SerializeField]
    private GameObject _gameOverWindow;
    [SerializeField]
    private Button _pauseButton; 

    private void OnEnable()
    {
        Health.OnGameEnds += GameOver;
        _pauseButton.onClick.AddListener(PauseGame);
    }

    private void Start()
    {
        Time.timeScale = 1;
        OnGameStart?.Invoke();
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0f;
        _pauseWindow.SetActive(true);
    }

    private void GameOver()
    {
        Time.timeScale = 0f;
        OnGameEnds?.Invoke();
        _gameOverWindow.SetActive(true); 
    }

    private void OnDisable()
    {
        Health.OnGameEnds -= GameOver;
    }
}
